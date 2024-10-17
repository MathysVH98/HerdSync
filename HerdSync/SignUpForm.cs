using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class SignUpForm : Form
    {
        private static readonly string UserCredentialsFilePath = "userCredentials.json";
        public static Dictionary<string, UserCredential> userCredentials = LoadUserCredentials();

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var userCredential = new UserCredential
            {
                Email = email,
                Username = username,
                Password = HashPassword(password) // Initialization of password hashing
            };

            if (!userCredential.IsValidEmail())
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!userCredential.IsValidUsername())
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userCredentials.ContainsKey(email) || userCredentials.ContainsKey(username))
            {
                MessageBox.Show("Email or Username already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password too short.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userCredentials[email] = userCredential;
            userCredentials[username] = userCredential;

            SaveUserCredentials();

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        private static Dictionary<string, UserCredential> LoadUserCredentials()
        {
            try
            {
                if (File.Exists(UserCredentialsFilePath))
                {
                    string json = File.ReadAllText(UserCredentialsFilePath);
                    Console.WriteLine($"Loaded data: {json}");
                    return JsonSerializer.Deserialize<Dictionary<string, UserCredential>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load user credentials: {ex.Message}");
            }

            return new Dictionary<string, UserCredential>();
        }

        private static void SaveUserCredentials()
        {
            try
            {
                string json = JsonSerializer.Serialize(userCredentials);
                File.WriteAllText(UserCredentialsFilePath, json);
                Console.WriteLine($"Saved data: {json}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save user credentials: {ex.Message}");
            }
        }

        public class UserCredential
        {
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            // Method to validate the email format
            public bool IsValidEmail()
            {
                return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }

            // Method to validate the username format
            public bool IsValidUsername()
            {
                return !string.IsNullOrEmpty(Username) && Username.Length >= 3;
            }
        }
    }
}
