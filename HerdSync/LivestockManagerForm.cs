using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class LivestockManagerForm : Form
    {
        private DatabaseHelper _databaseHelper;
        private HomePageForm _homePageForm;

        public LivestockManagerForm(HomePageForm homePageForm)
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
            _homePageForm = homePageForm;
        }

        private void LivestockManagerForm_Load(object sender, EventArgs e)
        {
            LoadLivestockData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLivestockData();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            _homePageForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLivestockData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            dataGridView1.BeginEdit(true);
        }

        private void LoadLivestockData()
        {
            using (var connection = new SQLiteConnection("Data Source=HerdSyncDatabase.db;Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Animals;";
                using (var adapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void SaveLivestockData()
        {
            using (var connection = new SQLiteConnection("Data Source=HerdSyncDatabase.db;Version=3;"))
            {
                connection.Open();
                DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

                if (changes != null)
                {
                    foreach (DataRow row in changes.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            string updateQuery = @"
                                UPDATE Animals
                                SET Name = @Name, Species = @Species, Origin = @Origin, DateOfBirth = @DateOfBirth, Sex = @Sex, Mother = @Mother, Father = @Father, StatusUponArrival = @StatusUponArrival, ArrivalDate = @ArrivalDate, StatusOfAnimal = @StatusOfAnimal
                                WHERE Rfid = @Rfid;
                            ";
                            using (var command = new SQLiteCommand(updateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Rfid", row["Rfid"]);
                                command.Parameters.AddWithValue("@Name", row["Name"]);
                                command.Parameters.AddWithValue("@Species", row["Species"]);
                                command.Parameters.AddWithValue("@Origin", row["Origin"]);
                                command.Parameters.AddWithValue("@DateOfBirth", row["DateOfBirth"]);
                                command.Parameters.AddWithValue("@Sex", row["Sex"]);
                                command.Parameters.AddWithValue("@Mother", row["Mother"]);
                                command.Parameters.AddWithValue("@Father", row["Father"]);
                                command.Parameters.AddWithValue("@StatusUponArrival", row["StatusUponArrival"]);
                                command.Parameters.AddWithValue("@ArrivalDate", row["ArrivalDate"]);
                                command.Parameters.AddWithValue("@StatusOfAnimal", row["StatusOfAnimal"]);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            string rfid = selectedRow.Cells["Rfid"].Value.ToString();

            // Confirm deletion
            var result = MessageBox.Show($"Are you sure you want to delete the record with RFID: {rfid}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteRecord(rfid);
                LoadLivestockData();
            }
        }

        private void DeleteRecord(string rfid)
        {
            using (var connection = new SQLiteConnection("Data Source=HerdSyncDatabase.db;Version=3;"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Animals WHERE Rfid = @Rfid;";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
