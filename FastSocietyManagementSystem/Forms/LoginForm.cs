using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Services;

namespace FastSocietyManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            if (!FastSocietyManagementSystem.Utilities.ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            AuthService authService = new AuthService();

            User? user = authService.LoginUser(email, password);

            if (user == null)
            {
                MessageBox.Show("Invalid login details or inactive account.");
                return;
            }

            MessageBox.Show($"Welcome {user.FullName}!");

            this.Hide();

            if (user.Role == "Admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
            }
            else if (user.Role == "Student")
            {
                SocietyService societyService = new SocietyService();

                bool isSocietyHead =
                    societyService.IsSocietyHead(user.UserId);

                if (isSocietyHead)
                {
                    SocietyDashboard societyDashboard = new SocietyDashboard();
                    societyDashboard.Show();
                }
                else
                {
                    StudentDashboard studentDashboard = new StudentDashboard(user);
                    studentDashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("Unknown user role. Please contact admin.");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
