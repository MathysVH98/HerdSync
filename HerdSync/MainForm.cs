using System;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class MainForm : Form
    {
        private DatabaseHelper _databaseHelper;
        public MainForm()
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignInForm signInForm = new SignInForm(this);
            signInForm.ShowDialog();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            ContactUsForm contactUsForm = new ContactUsForm();
            contactUsForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFeatures_Click(object sender, EventArgs e)
        {
            string featuresSummary =
                "HerdSync Application Features:\n\n" +
                "1. Animal Records Management: Track detailed information about each animal, including RFID, name, species, origin, date of birth, and more.\n" +
                "2. RFID Integration: Efficiently manage animals using RFID technology for accurate tracking and monitoring.\n" +
                "3. Scan Event Management: Record and manage entry and exit events for animals with RFID tags.\n" +
                "4. Farm Map Management: Use Google Maps integration to manage different areas of your farm, save and view polygons representing farm sections.\n" +
                "5. Weight Management: Track and set weight goals for each animal.\n" +
                "6. Photo Management: Upload and manage photos for each animal.\n" +
                "7. Data Synchronization: Synchronize and back up your farm data effectively.\n" +
                "8. User Management: User sign-up and sign-in functionality with secure data management.\n" +
                "9. Contact Support: Directly reach out to support for any queries or issues.\n";

            MessageBox.Show(featuresSummary, "Application Features", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
