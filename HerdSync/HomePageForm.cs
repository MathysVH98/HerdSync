using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmMap;
using Newtonsoft.Json.Linq;

namespace HerdSync
{
    public partial class HomePageForm : Form
    {
        private MainForm _mainForm;
        private string _currentUser;
        private DatabaseHelper _databaseHelper;
        private static HomePageForm _instance;
        private FarmMapForm farmMapForm;
        private AnimalRecordForm animalRecordForm;
        private LivestockMonitor _livestockMonitorForm;

        public HomePageForm(MainForm form, string username)
        {
            InitializeComponent();
            _mainForm = form;
            _currentUser = username;
            _databaseHelper = new DatabaseHelper();

            // Initialize the LivestockMonitor form
            _livestockMonitorForm = new LivestockMonitor(this); // Pass 'this' to the constructor if needed
            SerialPortManager.Instance.Initialize(this); // Initialize SerialPortManager with HomePageForm
        }

        public MainForm MainFormInstance => _mainForm;
        public string CurrentUser => _currentUser;

        public static HomePageForm GetInstance(MainForm form, string username)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new HomePageForm(form, username);
            }
            return _instance;
        }

        private async void HomePageForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = $"Current User: {_currentUser}";
            await UpdateWeatherAsync("Pretoria"); // Specify the city
            UpdateAnimalsOutsideSummary(); // Ensure the label is updated on load
            UpdateNewAnimalsList(); // Update the new animals list on load
        }

        private async Task UpdateWeatherAsync(string city)
        {
            string apiKey = "614af136ae77d287600190caaaca11a2"; // Replace with your OpenWeatherMap API key
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        lblWeather.Text = $"Error: Unable to fetch weather data ({response.StatusCode})";
                        return;
                    }

                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic weatherData = JObject.Parse(responseBody);
                    string weatherDescription = weatherData.weather[0].description;
                    double temperature = weatherData.main.temp;

                    lblWeather.Text = $"Weather: {weatherDescription}, Temp: {temperature}°C";
                }
                catch (HttpRequestException httpEx)
                {
                    lblWeather.Text = "Error fetching weather data.";
                    Console.WriteLine($"HttpRequestException: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    lblWeather.Text = "An error occurred.";
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        public void UpdateAnimalsOutsideSummary()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { UpdateAnimalsOutsideSummary(); });
                return;
            }

            var animalsOutside = _livestockMonitorForm.GetAnimalsOutsideFromGrid(); // Get data from LivestockMonitor grid

            int totalAnimals = _databaseHelper.GetTotalAnimalCount();
            int animalsOutsideCount = animalsOutside.Count; // Count of animals outside

            lblAnimalsOutside.Text = $"{animalsOutsideCount}/{totalAnimals}";

            gBoxAnimalsOutside.Controls.Clear(); // Clear existing controls

            Label countLabel = new Label
            {
                Text = $"Animals Outside: {animalsOutsideCount} / {totalAnimals}",
                AutoSize = true,
                Location = new Point(10, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            gBoxAnimalsOutside.Controls.Add(countLabel);

            int yOffset = 50;
            foreach (var animal in animalsOutside)
            {
                Label animalLabel = new Label
                {
                    Text = $"{animal.Rfid} - {animal.Status}",
                    AutoSize = true,
                    Location = new Point(10, yOffset)
                };
                gBoxAnimalsOutside.Controls.Add(animalLabel);
                yOffset += 25;
            }
        }

        public void UpdateNewAnimalsList()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { UpdateNewAnimalsList(); });
                return;
            }

            gBoxNewAnimals.Controls.Clear(); // Clear existing items

            var newAnimals = _databaseHelper.GetNewAnimalsForCurrentMonth();
            Label monthLabel = new Label
            {
                Text = DateTime.Now.ToString("MMMM yyyy"),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 20)
            };
            gBoxNewAnimals.Controls.Add(monthLabel);

            if (newAnimals.Count == 0) // Check if no new animals were added this month
            {
                Label noAnimalsLabel = new Label
                {
                    Text = "No new animals this month",
                    AutoSize = true,
                    Location = new Point(10, 50)
                };
                gBoxNewAnimals.Controls.Add(noAnimalsLabel);
            }
            else
            {
                int yOffset = 50;
                for (int i = 0; i < newAnimals.Count; i++)
                {
                    var animal = newAnimals[i];
                    Label animalLabel = new Label
                    {
                        Text = $"{i + 1}. {animal.Name}, {animal.Species}",
                        AutoSize = true,
                        Location = new Point(10, yOffset)
                    };
                    gBoxNewAnimals.Controls.Add(animalLabel);
                    yOffset += 30;
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }

        private void btnLivestockMonitor_Click(object sender, EventArgs e)
        {
            SerialPortManager.Instance.Unsubscribe(HandleRfidScan);
            LivestockMonitor livestockMonitorForm = LivestockMonitor.GetInstance(this); // Pass the current instance of HomePageForm
            livestockMonitorForm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SerialPortManager.Instance.ClosePort();
            this.Hide();
            HomePageForm homePageForm = GetInstance(_mainForm, _currentUser);
            homePageForm.Show();
        }

        private void btnAddAnimals_Click(object sender, EventArgs e)
        {
            AddAnimalForm addAnimalForm = new AddAnimalForm(this);
            addAnimalForm.Show();
            this.Hide();
        }

        private void btnLivestockManager_Click(object sender, EventArgs e)
        {
            LivestockManagerForm livestockManagerForm = new LivestockManagerForm(this);
            livestockManagerForm.Show();
            this.Hide();
        }

        private void btnFarmMap_Click(object sender, EventArgs e)
        {
            if (farmMapForm == null || farmMapForm.IsDisposed)
            {
                farmMapForm = new FarmMapForm(_mainForm, _currentUser);
                farmMapForm.Show();
            }
            else
            {
                farmMapForm.BringToFront();
            }
            this.Hide(); // Hide the HomePageForm when FarmMapForm is shown
        }

        private void btnAnimalRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnimalRecordForm animalRecordForm = new AnimalRecordForm(this);
            animalRecordForm.Show();
        }

        public void HandleRfidScan(object sender, RfidEventArgs e)
        {
            _databaseHelper.InsertOrUpdateScanEvent(e.Rfid);
            UpdateAnimalsOutsideSummary();
        }

        private void gBoxNewAnimals_Enter(object sender, EventArgs e)
        {

        }
    }
}
