using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastSocietyManagementSystem.Services;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Forms
{
    public partial class StudentDashboard : Form
    {

        private readonly User _loggedInUser;

        public StudentDashboard(User user)
        {
            InitializeComponent();

            _loggedInUser = user;
        }

        private void dgvSocieties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentDashboard_Load(
    object sender,
    EventArgs e
)
        {
            SocietyService societyService =
                new SocietyService();

            dgvSocieties.DataSource =
                societyService.GetAllSocieties();

            LoadEvents();
            LoadTickets();
            LoadTasks();
        }


        private void LoadEvents()
        {
            StudentService studentService =
                new StudentService();

            dgvEvents.DataSource =
                studentService.GetAllEvents();
        }

        private void btnApplyMembership_Click(
    object sender,
    EventArgs e
)
        {
            if (dgvSocieties.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a society."
                );

                return;
            }

            int societyId = Convert.ToInt32(
                dgvSocieties.CurrentRow.Cells["SocietyId"].Value
            );

            StudentService studentService =
                new StudentService();

            int studentId =
                studentService.GetStudentIdByUserId(
                    _loggedInUser.UserId
                );

            if (studentId == -1)
            {
                MessageBox.Show(
                    "Student record not found."
                );

                return;
            }

            MembershipService membershipService =
                new MembershipService();

            if (membershipService.IsMembershipRequestExists(studentId, societyId))
            {
                MessageBox.Show("You have already applied for this society.");
                return;
            }

            membershipService.ApplyForMembership(
                studentId,
                societyId
            );

            MessageBox.Show(
                "Membership request submitted successfully!"
            );
        }

        private void btnRegisterEvent_Click(
    object sender,
    EventArgs e
)
        {
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an event."
                );

                return;
            }

            int eventId = Convert.ToInt32(
                dgvEvents.CurrentRow
                    .Cells["EventId"]
                    .Value
            );

            string eventTitle =
                dgvEvents.CurrentRow
                    .Cells["Title"]
                    .Value
                    .ToString()!;

            DialogResult result =
                MessageBox.Show(
                    $"Are you sure you want to register for this event?\n\n" +
                    $"Event: {eventTitle}",
                    "Confirm Event Registration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            StudentService studentService =
                new StudentService();

            int studentId =
                studentService
                    .GetStudentIdByUserId(
                        _loggedInUser.UserId
                    );

            bool isAlreadyRegistered =
    studentService.IsStudentAlreadyRegistered(eventId, studentId);

            if (isAlreadyRegistered)
            {
                MessageBox.Show("You are already registered for this event.");
                return;
            }

            if (studentService.IsEventFull(eventId))
            {
                MessageBox.Show("This event is already full.");
                return;
            }

            studentService.RegisterForEvent(
                eventId,
                studentId
            );

            MessageBox.Show(
                "Event registration successful!"
            );

            LoadTickets();
        }

        private void btnLogout_Click(
    object sender,
    EventArgs e
)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            LoginForm loginForm =
                new LoginForm();

            loginForm.Show();

            this.Close();
        }

        private void LoadTickets()
        {
            StudentService studentService = new StudentService();

            int studentId =
                studentService.GetStudentIdByUserId(_loggedInUser.UserId);

            dgvTickets.DataSource =
                studentService.GetTicketsByStudentId(studentId);
        }

        private void btnRefreshTickets_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }

        private void LoadTasks()
        {
            StudentService studentService = new StudentService();

            int studentId =
                studentService.GetStudentIdByUserId(_loggedInUser.UserId);

            dgvTasks.DataSource =
                studentService.GetTasksByStudentId(studentId);
        }

        private void btnRefreshTasks_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void dgvTasks_CellClick(
    object sender,
    DataGridViewCellEventArgs e
)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvTasks.Rows[e.RowIndex];

            cmbTaskStatus.Text =
                row.Cells["Status"]
                    .Value
                    .ToString();
        }

        private void btnUpdateTaskStatus_Click(
    object sender,
    EventArgs e
)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a task."
                );

                return;
            }

            int taskId = Convert.ToInt32(
                dgvTasks.CurrentRow
                    .Cells["TaskId"]
                    .Value
            );

            string selectedStatus =
                cmbTaskStatus.Text;

            DialogResult result =
                MessageBox.Show(
                    $"Are you sure you want to update task status to:\n\n" +
                    $"{selectedStatus}?",
                    "Confirm Status Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            StudentService studentService =
                new StudentService();

            studentService.UpdateTaskStatus(
                taskId,
                selectedStatus
            );

            MessageBox.Show(
                "Task status updated successfully!"
            );

            LoadTasks();
        }
    }
}
