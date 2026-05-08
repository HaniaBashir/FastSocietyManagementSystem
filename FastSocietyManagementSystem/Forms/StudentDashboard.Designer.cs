namespace FastSocietyManagementSystem.Forms
{
    partial class StudentDashboard
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
            dgvSocieties = new DataGridView();
            btnApplyMembership = new Button();
            dgvEvents = new DataGridView();
            btnLogout = new Button();
            btnRegisterEvent = new Button();
            dgvTickets = new DataGridView();
            btnRefreshTickets = new Button();
            dgvTasks = new DataGridView();
            btnRefreshTasks = new Button();
            cmbTaskStatus = new ComboBox();
            btnUpdateTaskStatus = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocieties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(266, 25);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Student Dashboard";
            // 
            // dgvSocieties
            // 
            dgvSocieties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocieties.Location = new Point(22, 115);
            dgvSocieties.Name = "dgvSocieties";
            dgvSocieties.RowHeadersWidth = 62;
            dgvSocieties.Size = new Size(446, 217);
            dgvSocieties.TabIndex = 1;
            dgvSocieties.CellContentClick += dgvSocieties_CellContentClick;
            // 
            // btnApplyMembership
            // 
            btnApplyMembership.Location = new Point(22, 348);
            btnApplyMembership.Name = "btnApplyMembership";
            btnApplyMembership.Size = new Size(203, 44);
            btnApplyMembership.TabIndex = 2;
            btnApplyMembership.Text = "Apply Membership";
            btnApplyMembership.UseVisualStyleBackColor = true;
            btnApplyMembership.Click += btnApplyMembership_Click;
            // 
            // dgvEvents
            // 
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(486, 118);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.RowHeadersWidth = 62;
            dgvEvents.Size = new Size(447, 217);
            dgvEvents.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(821, 26);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRegisterEvent
            // 
            btnRegisterEvent.Location = new Point(486, 351);
            btnRegisterEvent.Name = "btnRegisterEvent";
            btnRegisterEvent.Size = new Size(154, 44);
            btnRegisterEvent.TabIndex = 5;
            btnRegisterEvent.Text = "Register Event";
            btnRegisterEvent.UseVisualStyleBackColor = true;
            btnRegisterEvent.Click += btnRegisterEvent_Click;
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(22, 482);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 62;
            dgvTickets.Size = new Size(446, 225);
            dgvTickets.TabIndex = 6;
            // 
            // btnRefreshTickets
            // 
            btnRefreshTickets.Location = new Point(304, 441);
            btnRefreshTickets.Name = "btnRefreshTickets";
            btnRefreshTickets.Size = new Size(164, 34);
            btnRefreshTickets.TabIndex = 7;
            btnRefreshTickets.Text = "Refresh Tickets";
            btnRefreshTickets.UseVisualStyleBackColor = true;
            btnRefreshTickets.Click += btnRefreshTickets_Click;
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(486, 482);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 62;
            dgvTasks.Size = new Size(447, 225);
            dgvTasks.TabIndex = 8;
            dgvTasks.CellClick += dgvTasks_CellClick;
            // 
            // btnRefreshTasks
            // 
            btnRefreshTasks.Location = new Point(795, 441);
            btnRefreshTasks.Name = "btnRefreshTasks";
            btnRefreshTasks.Size = new Size(138, 34);
            btnRefreshTasks.TabIndex = 9;
            btnRefreshTasks.Text = "Refresh Tasks";
            btnRefreshTasks.UseVisualStyleBackColor = true;
            btnRefreshTasks.Click += btnRefreshTasks_Click;
            // 
            // cmbTaskStatus
            // 
            cmbTaskStatus.FormattingEnabled = true;
            cmbTaskStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Completed" });
            cmbTaskStatus.Location = new Point(486, 725);
            cmbTaskStatus.Name = "cmbTaskStatus";
            cmbTaskStatus.Size = new Size(244, 33);
            cmbTaskStatus.TabIndex = 10;
            // 
            // btnUpdateTaskStatus
            // 
            btnUpdateTaskStatus.Location = new Point(744, 725);
            btnUpdateTaskStatus.Name = "btnUpdateTaskStatus";
            btnUpdateTaskStatus.Size = new Size(185, 34);
            btnUpdateTaskStatus.TabIndex = 11;
            btnUpdateTaskStatus.Text = "Update Task Status";
            btnUpdateTaskStatus.UseVisualStyleBackColor = true;
            btnUpdateTaskStatus.Click += btnUpdateTaskStatus_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 80);
            label2.Name = "label2";
            label2.Size = new Size(192, 32);
            label2.TabIndex = 12;
            label2.Text = "Active Societies";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 441);
            label3.Name = "label3";
            label3.Size = new Size(183, 32);
            label3.TabIndex = 13;
            label3.Text = "Tickets Bought";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(485, 73);
            label4.Name = "label4";
            label4.Size = new Size(166, 32);
            label4.TabIndex = 14;
            label4.Text = "Active Events";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(485, 441);
            label5.Name = "label5";
            label5.Size = new Size(145, 32);
            label5.TabIndex = 15;
            label5.Text = "Tasks to Do";
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 817);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnUpdateTaskStatus);
            Controls.Add(cmbTaskStatus);
            Controls.Add(btnRefreshTasks);
            Controls.Add(dgvTasks);
            Controls.Add(btnRefreshTickets);
            Controls.Add(dgvTickets);
            Controls.Add(btnRegisterEvent);
            Controls.Add(btnLogout);
            Controls.Add(dgvEvents);
            Controls.Add(btnApplyMembership);
            Controls.Add(dgvSocieties);
            Controls.Add(label1);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            Load += StudentDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocieties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvSocieties;
        private Button btnApplyMembership;
        private DataGridView dgvEvents;
        private Button btnLogout;
        private Button btnRegisterEvent;
        private DataGridView dgvTickets;
        private Button btnRefreshTickets;
        private DataGridView dgvTasks;
        private Button btnRefreshTasks;
        private ComboBox cmbTaskStatus;
        private Button btnUpdateTaskStatus;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}