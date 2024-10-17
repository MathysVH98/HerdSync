using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class AnimalRecordForm : Form
    {
        private DatabaseHelper _databaseHelper;
        private HomePageForm _homePageForm;
        private string _currentPhotoPath;

        public AnimalRecordForm(HomePageForm homePageForm)
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
            _homePageForm = homePageForm;
            cmbSearchType.SelectedIndexChanged += CmbSearchType_SelectedIndexChanged;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtAnimalSearch.Text;
            string searchType = cmbSearchType.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(searchQuery) && !string.IsNullOrWhiteSpace(searchType))
            {
                LoadAnimalDetails(searchQuery, searchType);
            }
            else
            {
                MessageBox.Show("Please enter a valid RFID or Name and select a search type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAnimalDetails(string searchText, string searchType)
        {
            Animal animal = null;

            if (searchType == "RFID")
            {
                animal = _databaseHelper.GetAnimalByRfid(searchText);
            }
            else if (searchType == "Name")
            {
                animal = _databaseHelper.GetAnimalByName(searchText);
            }

            if (animal != null)
            {
                // Lifecycle Information
                lblSpeciesValue.Text = animal.Species;
                lblGenderValue.Text = animal.Sex;
                lblAgeValue.Text = (DateTime.Now.Year - animal.DateOfBirth.Year).ToString();
                lblOriginValue.Text = animal.Origin;
                lblPurchaseDateValue.Text = animal.PurchaseDate.HasValue
    ? animal.PurchaseDate.Value.ToString("dd/MM/yyyy") : "N/A";

                // Weight Records
                lblInitialWeightValue.Text = animal.InitialWeight.ToString();
                lblCurrentWeightValue.Text = animal.CurrentWeight.ToString();
                lblWeightGoalValue.Text = animal.WeightGoal.ToString();

                // Identification
                lblRFIDValue.Text = animal.Rfid;
                lblTagIDValue.Text = animal.TagId;

                // Load and display the image
                _currentPhotoPath = animal.PhotoPath;
                if (!string.IsNullOrEmpty(_currentPhotoPath) && File.Exists(_currentPhotoPath))
                {
                    pbAnimalPhoto.Image = Image.FromFile(_currentPhotoPath);
                }
                else
                {
                    pbAnimalPhoto.Image = null; // Clear if no image
                }
            }
            else
            {
                MessageBox.Show("Animal not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            _homePageForm.Show();
        }

        private void CmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbSearchType.SelectedItem?.ToString();
            if (selectedType == "Name")
            {
                txtAnimalSearch.DataSource = _databaseHelper.GetAllUniqueNames();
                txtAnimalSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtAnimalSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else if (selectedType == "RFID")
            {
                txtAnimalSearch.DataSource = _databaseHelper.GetAllUniqueRfids();
                txtAnimalSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtAnimalSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    pbAnimalPhoto.Image = Image.FromFile(filePath);

                    // Save the path to the database
                    _currentPhotoPath = filePath;
                    _databaseHelper.UpdateAnimalPhotoPath(lblRFIDValue.Text, filePath);
                }
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            pbAnimalPhoto.Image = null;
            _currentPhotoPath = string.Empty;

            // Remove the path from the database
            _databaseHelper.UpdateAnimalPhotoPath(lblRFIDValue.Text, null);
        }
    }
}
