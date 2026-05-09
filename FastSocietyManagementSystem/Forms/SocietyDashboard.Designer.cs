


namespace FastSocietyManagementSystem.Forms
{
    partial class SocietyDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dgvMembershipRequests = new DataGridView();
            btnApprove = new Button();
            btnReject = new Button();
            btnManageEvents = new Button();
            btnManageTasks = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMembershipRequests).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(262, 25);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Society Dashboard";
            // 
            // dgvMembershipRequests
            // 
            dgvMembershipRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembershipRequests.Location = new Point(23, 71);
            dgvMembershipRequests.Name = "dgvMembershipRequests";
            dgvMembershipRequests.RowHeadersWidth = 62;
            dgvMembershipRequests.Size = new Size(745, 225);
            dgvMembershipRequests.TabIndex = 1;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(656, 317);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(112, 34);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(529, 317);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(112, 34);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnManageEvents
            // 
            btnManageEvents.BackgroundImageLayout = ImageLayout.Zoom;
            btnManageEvents.Location = new Point(23, 317);
            btnManageEvents.Name = "btnManageEvents";
            btnManageEvents.Size = new Size(146, 34);
            btnManageEvents.TabIndex = 4;
            btnManageEvents.Text = "Manage Events";
            btnManageEvents.UseVisualStyleBackColor = true;
            btnManageEvents.Click += btnManageEvents_Click;
            // 
            // btnManageTasks
            // 
            btnManageTasks.Location = new Point(175, 317);
            btnManageTasks.Name = "btnManageTasks";
            btnManageTasks.Size = new Size(133, 34);
            btnManageTasks.TabIndex = 5;
            btnManageTasks.Text = "Manage Tasks";
            btnManageTasks.UseVisualStyleBackColor = true;
            btnManageTasks.Click += btnManageTasks_Click;
            // 
            // SocietyDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 400);
            Controls.Add(btnManageTasks);
            Controls.Add(btnManageEvents);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(dgvMembershipRequests);
            Controls.Add(label1);
            Name = "SocietyDashboard";
            Text = "SocietyDashboard";
            Load += SocietyDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMembershipRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvMembershipRequests;
        private Button btnApprove;
        private Button btnReject;
        private Button btnManageEvents;
        private Button btnManageTasks;
    }
}