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
    public partial class EventManagementForm : Form
    {
        public EventManagementForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void EventManagementForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void LoadEvents()
        {
            SocietyService societyService = new SocietyService();

            dgvEvents.DataSource = societyService.GetAllEvents();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            string title = txtEventTitle.Text.Trim();
            string description = txtEventDescription.Text.Trim();
            string venue = txtVenue.Text.Trim();
            string capacityText = txtCapacity.Text.Trim();

            if (
                title == "" ||
                description == "" ||
                venue == "" ||
                capacityText == ""
            )
            {
                MessageBox.Show("Please fill all event fields.");
                return;
            }

            if (title.Length < 3)
            {
                MessageBox.Show("Event title must be at least 3 characters.");
                return;
            }

            if (!int.TryParse(capacityText, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Capacity must be a positive number.");
                return;
            }

            if (dtpEventDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Event date must be in the future.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to create this event?\n\n" +
                $"Title: {title}\n" +
                $"Description: {description}\n" +
                $"Venue: {venue}\n" +
                $"Date: {dtpEventDate.Value}\n" +
                $"Capacity: {capacity}\n" +
                $"Status: Pending admin approval",
                "Confirm Event Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SocietyEvent societyEvent = new SocietyEvent
            {
                SocietyId = 1,
                Title = title,
                Description = description,
                EventDate = dtpEventDate.Value,
                Venue = venue,
                Capacity = capacity,
                Status = "Pending"
            };

            SocietyService societyService = new SocietyService();

            societyService.CreateEvent(societyEvent);

            MessageBox.Show("Event created successfully. Waiting for admin approval.");

            LoadEvents();

            txtEventTitle.Clear();
            txtEventDescription.Clear();
            txtVenue.Clear();
            txtCapacity.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvEvents.Rows[e.RowIndex];

            txtEventTitle.Text = row.Cells["Title"].Value.ToString();
            txtEventDescription.Text = row.Cells["Description"].Value.ToString();
            txtVenue.Text = row.Cells["Venue"].Value.ToString();
            txtCapacity.Text = row.Cells["Capacity"].Value.ToString();

            dtpEventDate.Value = Convert.ToDateTime(row.Cells["EventDate"].Value);
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Please select an event to update.");
                return;
            }

            if (
                txtEventTitle.Text.Trim() == "" ||
                txtEventDescription.Text.Trim() == "" ||
                txtVenue.Text.Trim() == "" ||
                txtCapacity.Text.Trim() == ""
            )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity))
            {
                MessageBox.Show("Capacity must be a number.");
                return;
            }

            int eventId = Convert.ToInt32(
                dgvEvents.CurrentRow.Cells["EventId"].Value
            );

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update this event?\n\n" +
                $"Title: {txtEventTitle.Text}\n" +
                $"Venue: {txtVenue.Text}\n" +
                $"Date: {dtpEventDate.Value}\n" +
                $"Capacity: {capacity}",
                "Confirm Event Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SocietyEvent societyEvent = new SocietyEvent
            {
                EventId = eventId,
                Title = txtEventTitle.Text.Trim(),
                Description = txtEventDescription.Text.Trim(),
                EventDate = dtpEventDate.Value,
                Venue = txtVenue.Text.Trim(),
                Capacity = capacity
            };

            SocietyService societyService = new SocietyService();

            societyService.UpdateEvent(societyEvent);

            MessageBox.Show("Event updated successfully.");

            LoadEvents();
        }

        private void btnCancelEvent_Click(object sender, EventArgs e)
{
    if (dgvEvents.CurrentRow == null)
    {
        MessageBox.Show("Please select an event to cancel.");
        return;
    }

    int eventId = Convert.ToInt32(
        dgvEvents.CurrentRow.Cells["EventId"].Value
    );

    string title =
        dgvEvents.CurrentRow.Cells["Title"].Value.ToString()!;

    DialogResult result = MessageBox.Show(
        $"Are you sure you want to cancel this event?\n\nEvent: {title}",
        "Confirm Event Cancellation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

    if (result != DialogResult.Yes)
    {
        return;
    }

    SocietyService societyService = new SocietyService();

    societyService.CancelEvent(eventId);

    MessageBox.Show("Event cancelled successfully.");

    LoadEvents();
}
    }
}
