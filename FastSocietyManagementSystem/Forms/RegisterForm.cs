using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastSocietyManagementSystem.Services;
using FastSocietyManagementSystem.Utilities;

namespace FastSocietyManagementSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "";

            if (
                ValidationHelper.IsEmpty(fullName) ||
                ValidationHelper.IsEmpty(email) ||
                ValidationHelper.IsEmpty(password) ||
                ValidationHelper.IsEmpty(role)
            )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!ValidationHelper.IsValidName(fullName))
            {
                MessageBox.Show("Full name must be at least 3 characters.");
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (!ValidationHelper.IsStrongEnoughPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to register this user?\n\n" +
                $"Name: {fullName}\n" +
                $"Email: {email}\n" +
                $"Role: {role}",
                "Confirm User Registration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            AuthService authService = new AuthService();

            bool isRegistered =
                authService.RegisterUser(
                    fullName,
                    email,
                    password,
                    role
                );

            if (isRegistered)
            {
                MessageBox.Show("User registered successfully.");

                txtFullName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                cmbRole.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("This email is already registered.");
            }
        }
    }
}
