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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSuspendSociety_Click(object sender, EventArgs e)
        {
            if (dgvSocieties.CurrentRow == null)
            {
                MessageBox.Show("Please select a society.");
                return;
            }

            int societyId = Convert.ToInt32(
                dgvSocieties.CurrentRow.Cells["SocietyId"].Value
            );

            SocietyService societyService = new SocietyService();

            societyService.SuspendSociety(societyId);

            MessageBox.Show("Society suspended successfully.");

            LoadSocieties();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadSocieties();
            LoadStudents();
            LoadPendingEvents();
        }

        private void LoadSocieties()
        {
            SocietyService societyService = new SocietyService();

            dgvSocieties.DataSource = societyService.GetAllSocieties();
        }

        private void btnAddSociety_Click(object sender, EventArgs e)
        {
            if (
                txtSocietyName.Text.Trim() == "" ||
                txtSocietyDescription.Text.Trim() == "" ||
                txtSocietyCategory.Text.Trim() == "" ||
                txtHeadUserId.Text.Trim() == ""
            )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(txtHeadUserId.Text.Trim(), out int headUserId))
            {
                MessageBox.Show("Head User ID must be a number.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to create this society?\n\n" +
                $"Society: {txtSocietyName.Text}\n" +
                $"Category: {txtSocietyCategory.Text}\n" +
                $"Head User ID: {headUserId}",
                "Confirm Society Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            Society society = new Society
            {
                SocietyName = txtSocietyName.Text.Trim(),
                Description = txtSocietyDescription.Text.Trim(),
                Category = txtSocietyCategory.Text.Trim(),
                HeadUserId = headUserId,
                Status = "Pending"
            };

            SocietyService societyService = new SocietyService();

            societyService.AddSociety(society);

            MessageBox.Show("Society created successfully.");

            LoadSocieties();
        }

        private void btnApproveSociety_Click(object sender, EventArgs e)
        {
            if (dgvSocieties.CurrentRow == null)
            {
                MessageBox.Show("Please select a society.");
                return;
            }

            int societyId = Convert.ToInt32(
                dgvSocieties.CurrentRow.Cells["SocietyId"].Value
            );

            SocietyService societyService = new SocietyService();

            societyService.ApproveSociety(societyId);

            MessageBox.Show("Society approved successfully.");

            LoadSocieties();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadStudents()
        {
            UserService userService = new UserService();

            dgvStudents.DataSource = userService.GetAllStudents();
        }

        private void LoadPendingEvents()
        {
            SocietyService societyService = new SocietyService();

            dgvPendingEvents.DataSource = societyService.GetPendingEvents();
        }

        private void btnActivateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            int userId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["UserId"].Value);

            new UserService().ActivateUser(userId);

            MessageBox.Show("Student activated.");

            LoadStudents();
        }

        private void btnDeactivateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            int userId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["UserId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to deactivate this student?",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            new UserService().DeactivateUser(userId);

            MessageBox.Show("Student deactivated.");

            LoadStudents();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            int userId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["UserId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            new UserService().DeleteUser(userId);

            MessageBox.Show("Student deleted.");

            LoadStudents();
        }

        private void btnApproveEvent_Click(object sender, EventArgs e)
        {
            if (dgvPendingEvents.CurrentRow == null)
            {
                MessageBox.Show("Please select an event.");
                return;
            }

            int eventId = Convert.ToInt32(
                dgvPendingEvents.CurrentRow.Cells["EventId"].Value
            );

            string eventTitle =
                dgvPendingEvents.CurrentRow.Cells["Title"].Value.ToString()!;

            SocietyService societyService =
                new SocietyService();

            bool canApprove =
                societyService.CanAdminApproveEvent(
                    eventId,
                    out string validationMessage
                );

            if (!canApprove)
            {
                MessageBox.Show(validationMessage);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to approve this event?\n\nEvent: {eventTitle}",
                "Confirm Event Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            societyService.ApproveEvent(eventId);

            MessageBox.Show("Event approved successfully.");

            LoadPendingEvents();
        }

        private void btnRejectEvent_Click(object sender, EventArgs e)
        {
            if (dgvPendingEvents.CurrentRow == null)
            {
                MessageBox.Show("Please select an event.");
                return;
            }

            int eventId = Convert.ToInt32(
                dgvPendingEvents.CurrentRow.Cells["EventId"].Value
            );

            string eventTitle =
                dgvPendingEvents.CurrentRow.Cells["Title"].Value.ToString()!;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to reject this event?\n\nEvent: {eventTitle}",
                "Confirm Event Rejection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SocietyService societyService =
                new SocietyService();

            societyService.RejectEvent(eventId);

            MessageBox.Show("Event rejected successfully.");

            LoadPendingEvents();
        }

        private void btnDeleteSociety_Click(object sender, EventArgs e)
        {
            if (dgvSocieties.CurrentRow == null)
            {
                MessageBox.Show("Please select a society.");
                return;
            }

            int societyId = Convert.ToInt32(dgvSocieties.CurrentRow.Cells["SocietyId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this society?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            new SocietyService().DeleteSociety(societyId);

            MessageBox.Show("Society deleted.");

            LoadSocieties();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Close();
        }

        private void btnRegisterForm_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.Show();
        }
    }
}
