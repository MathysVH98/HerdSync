using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class SignInForm : Form
    {
        private int attemptCount = 0;
        private DateTime lockoutEndTime;
        private MainForm mainForm;

        public SignInForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (attemptCount >= 4 && DateTime.Now < lockoutEndTime)
            {
                MessageBox.Show("Please try again in 5 minutes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string emailOrUsername = txtEmail.Text;
            string password = txtPassword.Text;

            Console.WriteLine($"Attempting login with {emailOrUsername}");

            if (SignUpForm.userCredentials.TryGetValue(emailOrUsername, out var userDetails) &&
                VerifyPasswordHash(password, userDetails.Password)) // Initialization of password verification
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainForm.Hide();

                // Open Home Page and pass reference to MainForm and username
                HomePageForm homePageForm = HomePageForm.GetInstance(mainForm, userDetails.Username);
                homePageForm.Show();

                this.Hide();
            }
            else
            {
                attemptCount++;
                if (attemptCount >= 4)
                {
                    lockoutEndTime = DateTime.Now.AddMinutes(5);
                }
                MessageBox.Show("Incorrect details, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool VerifyPasswordHash(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                return hashedPassword == storedHash;
            }
        }
    }
}
