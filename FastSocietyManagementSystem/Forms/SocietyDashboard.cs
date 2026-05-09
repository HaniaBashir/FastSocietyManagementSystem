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

    
    public partial class SocietyDashboard : Form
    {
        
        private readonly User _loggedInUser;
        private readonly int _societyId;
        public SocietyDashboard(User user)
        {
            InitializeComponent();

            _loggedInUser = user;

            SocietyService societyService = new SocietyService();

            _societyId = societyService.GetSocietyIdByHeadUserId(
                _loggedInUser.UserId
            );
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
            EventManagementForm eventForm = new EventManagementForm(_societyId);

            eventForm.Show();
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            TaskManagementForm taskForm =
    new TaskManagementForm(_societyId);

            taskForm.Show();
        }
    }
}
