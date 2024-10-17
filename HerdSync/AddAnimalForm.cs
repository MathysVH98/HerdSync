using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class AddAnimalForm : Form
    {
        private DatabaseHelper _databaseHelper;
        private HomePageForm _homePageForm;

        List<Species> speciesList = new List<Species>
        {
            new Species("LIVESTOCK", "", true),
            new Species("Cattle", "LIVESTOCK"),
            new Species("Goat", "LIVESTOCK"),
            new Species("Pig", "LIVESTOCK"),
            new Species("Sheep", "LIVESTOCK"),
            new Species("PET", "", true),
            new Species("Cat", "PET"),
            new Species("Dog", "PET"),
            new Species("WILDLIFE", "", true),
            new Species("Aardwolf", "WILDLIFE"),
            new Species("African buffalo", "WILDLIFE"),
            new Species("African civet", "WILDLIFE"),
            new Species("African clawless otter", "WILDLIFE"),
            new Species("African Elephant", "WILDLIFE"),
            new Species("African palm civet", "WILDLIFE"),
            new Species("African wildcat", "WILDLIFE"),
            new Species("African wild dog", "WILDLIFE"),
            new Species("Alpaca", "WILDLIFE"),
            new Species("Angolan genet", "WILDLIFE"),
            // Add more species as needed
        };

        public AddAnimalForm(HomePageForm homePageForm)
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
            _homePageForm = homePageForm;
            LoadComboBoxData();
            SerialPortManager.Instance.RfidScanned += Instance_RfidScanned; // Subscribe to the event
            SerialPortManager.Instance.OpenPort("COM3"); // Ensure COM port is correct
        }

        private void LoadComboBoxData()
        {
            // Populate cmbBoxOrigin
            cmbBoxOrigin.Items.Add("Select Origin");
            cmbBoxOrigin.Items.Add("Born in the farm");
            cmbBoxOrigin.Items.Add("Bought");
            cmbBoxOrigin.Items.Add("Donated");
            cmbBoxOrigin.Items.Add("Found");
            cmbBoxOrigin.Items.Add("Other");
            cmbBoxOrigin.SelectedIndex = 0;

            // Populate cmbBoxSex
            cmbBoxSex.Items.Add("Male");
            cmbBoxSex.Items.Add("Female");
            cmbBoxSex.SelectedIndex = -1;

            // Populate cmbBoxStatusOArrival
            cmbBoxStatusOArrival.Items.Add("Excellent");
            cmbBoxStatusOArrival.Items.Add("Fair");
            cmbBoxStatusOArrival.Items.Add("Bad");
            cmbBoxStatusOArrival.SelectedIndex = -1;

            // Populate cmbBoxStatusOfAnimal
            cmbBoxStatusOfAnimal.Items.Add("Dead");
            cmbBoxStatusOfAnimal.Items.Add("Donated");
            cmbBoxStatusOfAnimal.Items.Add("Lost");
            cmbBoxStatusOfAnimal.Items.Add("On the farm");
            cmbBoxStatusOfAnimal.Items.Add("Slaughtered");
            cmbBoxStatusOfAnimal.Items.Add("Sold");
            cmbBoxStatusOfAnimal.SelectedIndex = -1;

            // Populate cmbBoxSpecies with existing data
            foreach (var species in speciesList)
            {
                cmbBoxSpecies.Items.Add(species);
            }
            cmbBoxSpecies.DrawMode = DrawMode.OwnerDrawFixed;
            cmbBoxSpecies.DrawItem += new DrawItemEventHandler(cmbBoxSpecies_DrawItem);
        }

        private void cmbBoxSpecies_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Species species = (Species)cmbBoxSpecies.Items[e.Index];

            if (species.IsCategory)
            {
                e.Graphics.DrawString(species.Name, new Font(e.Font, FontStyle.Bold), Brushes.Black, e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(species.Name, e.Font, Brushes.Black, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SerialPortManager.Instance.ClosePort();
            this.Close();
            _homePageForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rfid = lblRfidValue.Text; // Update to use lblRfidValue.Text
            string name = txtName.Text;
            string species = cmbBoxSpecies.SelectedItem?.ToString();
            string origin = cmbBoxOrigin.SelectedItem?.ToString();
            DateTime dateOfBirth = dateTimePicker1.Value;
            string sex = cmbBoxSex.SelectedItem?.ToString();
            string mother = txtMother.Text;
            string father = txtFather.Text;
            string statusUponArrival = cmbBoxStatusOArrival.SelectedItem?.ToString();
            DateTime arrivalDate = dateTimePicker2.Value;
            string statusOfAnimal = cmbBoxStatusOfAnimal.SelectedItem?.ToString();
            string addedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Added date
            double initialWeight = double.Parse(txtInitialWeight.Text);
            double currentWeight = double.Parse(txtCurrentWeight.Text);
            double weightGoal = double.Parse(txtWeightGoal.Text);
            string tagId = txtTagID.Text;

            // Ensure that all necessary fields are filled before saving
            if (string.IsNullOrWhiteSpace(rfid) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(species) ||
                string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(sex) || string.IsNullOrWhiteSpace(statusUponArrival) ||
                string.IsNullOrWhiteSpace(statusOfAnimal) || initialWeight <= 0 || currentWeight <= 0 || weightGoal <= 0)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Check for duplicate RFID
            if (IsRfidRegistered(rfid))
            {
                MessageBox.Show("Rfid already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save data to the database
            SaveAnimalToDatabase(rfid, name, species, origin, dateOfBirth, sex, mother, father, statusUponArrival, arrivalDate, statusOfAnimal, addedDate, initialWeight, currentWeight, weightGoal, tagId);
            MessageBox.Show("Animal information saved successfully.");
            _homePageForm.UpdateNewAnimalsList(); // Update the new animals list on the home page
        }

        private bool IsRfidRegistered(string rfid)
        {
            using (var connection = new SQLiteConnection("Data Source=HerdSyncDatabase.db;Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM Animals WHERE Rfid = @Rfid;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        private void SaveAnimalToDatabase(string rfid, string name, string species, string origin, DateTime dateOfBirth, string sex, string mother, string father, string statusUponArrival, DateTime arrivalDate, string statusOfAnimal, string addedDate, double initialWeight, double currentWeight, double weightGoal, string tagId)
        {
            using (var connection = new SQLiteConnection("Data Source=HerdSyncDatabase.db;Version=3;"))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO Animals (Rfid, Name, Species, Origin, DateOfBirth, Sex, Mother, Father, StatusUponArrival, ArrivalDate, StatusOfAnimal, AddedDate, InitialWeight, CurrentWeight, WeightGoal, TagId)
                    VALUES (@Rfid, @Name, @Species, @Origin, @DateOfBirth, @Sex, @Mother, @Father, @StatusUponArrival, @ArrivalDate, @StatusOfAnimal, @AddedDate, @InitialWeight, @CurrentWeight, @WeightGoal, @TagId);
                ";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Species", species);
                    command.Parameters.AddWithValue("@Origin", origin);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Sex", sex);
                    command.Parameters.AddWithValue("@Mother", mother);
                    command.Parameters.AddWithValue("@Father", father);
                    command.Parameters.AddWithValue("@StatusUponArrival", statusUponArrival);
                    command.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                    command.Parameters.AddWithValue("@StatusOfAnimal", statusOfAnimal);
                    command.Parameters.AddWithValue("@AddedDate", addedDate);
                    command.Parameters.AddWithValue("@InitialWeight", initialWeight);
                    command.Parameters.AddWithValue("@CurrentWeight", currentWeight);
                    command.Parameters.AddWithValue("@WeightGoal", weightGoal);
                    command.Parameters.AddWithValue("@TagId", tagId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Instance_RfidScanned(object sender, RfidEventArgs e)
        {
            try
            {
                if (lblRfidValue.InvokeRequired)
                {
                    lblRfidValue.Invoke(new Action(() =>
                    {
                        lblRfidValue.Text = e.Rfid;
                        Console.WriteLine($"RFID Value Updated: {e.Rfid}");
                    }));
                }
                else
                {
                    lblRfidValue.Text = e.Rfid;
                    Console.WriteLine($"RFID Value Updated: {e.Rfid}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }

    public class Species
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsCategory { get; set; }

        public Species(string name, string category, bool isCategory = false)
        {
            Name = name;
            Category = category;
            IsCategory = isCategory;
        }

        public override string ToString()
        {
            return IsCategory ? Name : "  " + Name;
        }
    }
}
