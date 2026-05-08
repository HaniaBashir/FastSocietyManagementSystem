using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastSocietyManagementSystem.Services;

namespace FastSocietyManagementSystem.Forms
{
    public partial class SocietyDashboard : Form
    {
        public SocietyDashboard()
        {
            InitializeComponent();
        }

        private void LoadMembershipRequests()
        {
            MembershipService membershipService =
                new MembershipService();

            dgvMembershipRequests.DataSource =
                membershipService
                    .GetPendingMembershipRequests();
        }

        private void SocietyDashboard_Load(
    object sender,
    EventArgs e
)
        {
            LoadMembershipRequests();
        }

        private void btnApprove_Click(
    object sender,
    EventArgs e
)
        {
            if (
                dgvMembershipRequests.CurrentRow == null
            )
            {
                MessageBox.Show(
                    "Select a request."
                );

                return;
            }

            int requestId = Convert.ToInt32(
                dgvMembershipRequests
                    .CurrentRow
                    .Cells["RequestId"]
                    .Value
            );

            MembershipService membershipService =
                new MembershipService();

            membershipService.ApproveMembership(
                requestId
            );

            MessageBox.Show(
                "Membership approved."
            );

            LoadMembershipRequests();
        }

        private void btnReject_Click(
    object sender,
    EventArgs e
)
        {
            if (
                dgvMembershipRequests.CurrentRow == null
            )
            {
                MessageBox.Show(
                    "Select a request."
                );

                return;
            }

            int requestId = Convert.ToInt32(
                dgvMembershipRequests
                    .CurrentRow
                    .Cells["RequestId"]
                    .Value
            );

            MembershipService membershipService =
                new MembershipService();

            membershipService.RejectMembership(
                requestId
            );

            MessageBox.Show(
                "Membership rejected."
            );

            LoadMembershipRequests();
        }

        private void btnManageEvents_Click(
    object sender,
    EventArgs e
)
        {
            EventManagementForm
                eventManagementForm =
                    new EventManagementForm();

            eventManagementForm.Show();
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            TaskManagementForm taskManagementForm =
                new TaskManagementForm();

            taskManagementForm.Show();
        }
    }
}
