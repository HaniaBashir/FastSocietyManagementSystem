namespace FastSocietyManagementSystem.Forms
{
    partial class AdminDashboard
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
            txtSocietyName = new TextBox();
            txtSocietyDescription = new TextBox();
            txtSocietyCategory = new TextBox();
            txtHeadUserId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAddSociety = new Button();
            btnApproveSociety = new Button();
            btnSuspendSociety = new Button();
            btnRegisterForm = new Button();
            dgvSocieties = new DataGridView();
            dgvStudents = new DataGridView();
            dgvPendingEvents = new DataGridView();
            btnActivateStudent = new Button();
            btnDeactivateStudent = new Button();
            btnDeleteStudent = new Button();
            btnDeleteSociety = new Button();
            btnApproveEvent = new Button();
            btnRejectEvent = new Button();
            btnLogout = new Button();
            btnOpenRegisterForm = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocieties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendingEvents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 25);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Admin Dashboard";
            label1.Click += label1_Click;
            // 
            // txtSocietyName
            // 
            txtSocietyName.Location = new Point(533, 185);
            txtSocietyName.Name = "txtSocietyName";
            txtSocietyName.Size = new Size(283, 31);
            txtSocietyName.TabIndex = 1;
            // 
            // txtSocietyDescription
            // 
            txtSocietyDescription.Location = new Point(533, 250);
            txtSocietyDescription.Name = "txtSocietyDescription";
            txtSocietyDescription.Size = new Size(283, 31);
            txtSocietyDescription.TabIndex = 2;
            // 
            // txtSocietyCategory
            // 
            txtSocietyCategory.Location = new Point(848, 181);
            txtSocietyCategory.Name = "txtSocietyCategory";
            txtSocietyCategory.Size = new Size(283, 31);
            txtSocietyCategory.TabIndex = 3;
            txtSocietyCategory.TextChanged += textBox3_TextChanged;
            // 
            // txtHeadUserId
            // 
            txtHeadUserId.Location = new Point(848, 251);
            txtHeadUserId.Name = "txtHeadUserId";
            txtHeadUserId.Size = new Size(283, 31);
            txtHeadUserId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(533, 146);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 5;
            label2.Text = "Society Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 219);
            label3.Name = "label3";
            label3.Size = new Size(102, 25);
            label3.TabIndex = 6;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(848, 153);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 7;
            label4.Text = "Category";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(848, 223);
            label5.Name = "label5";
            label5.Size = new Size(117, 25);
            label5.TabIndex = 8;
            label5.Text = "Head User ID";
            // 
            // btnAddSociety
            // 
            btnAddSociety.Location = new Point(533, 301);
            btnAddSociety.Name = "btnAddSociety";
            btnAddSociety.Size = new Size(121, 41);
            btnAddSociety.TabIndex = 9;
            btnAddSociety.Text = "Add Society";
            btnAddSociety.UseVisualStyleBackColor = true;
            btnAddSociety.Click += btnAddSociety_Click;
            // 
            // btnApproveSociety
            // 
            btnApproveSociety.Location = new Point(533, 348);
            btnApproveSociety.Name = "btnApproveSociety";
            btnApproveSociety.Size = new Size(156, 41);
            btnApproveSociety.TabIndex = 10;
            btnApproveSociety.Text = "Approve Society";
            btnApproveSociety.UseVisualStyleBackColor = true;
            btnApproveSociety.Click += btnApproveSociety_Click;
            // 
            // btnSuspendSociety
            // 
            btnSuspendSociety.Location = new Point(966, 301);
            btnSuspendSociety.Name = "btnSuspendSociety";
            btnSuspendSociety.Size = new Size(165, 41);
            btnSuspendSociety.TabIndex = 11;
            btnSuspendSociety.Text = "Suspend Society";
            btnSuspendSociety.UseVisualStyleBackColor = true;
            btnSuspendSociety.Click += btnSuspendSociety_Click;
            // 
            // btnRegisterForm
            // 
            btnRegisterForm.Location = new Point(19, 45);
            btnRegisterForm.Name = "btnRegisterForm";
            btnRegisterForm.Size = new Size(145, 34);
            btnRegisterForm.TabIndex = 12;
            btnRegisterForm.Text = "Register User";
            btnRegisterForm.UseVisualStyleBackColor = true;
            btnRegisterForm.Click += btnRegisterForm_Click;
            // 
            // dgvSocieties
            // 
            dgvSocieties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocieties.Location = new Point(19, 134);
            dgvSocieties.Name = "dgvSocieties";
            dgvSocieties.RowHeadersWidth = 62;
            dgvSocieties.Size = new Size(485, 255);
            dgvSocieties.TabIndex = 13;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(28, 458);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(874, 248);
            dgvStudents.TabIndex = 14;
            // 
            // dgvPendingEvents
            // 
            dgvPendingEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingEvents.Location = new Point(28, 786);
            dgvPendingEvents.Name = "dgvPendingEvents";
            dgvPendingEvents.RowHeadersWidth = 62;
            dgvPendingEvents.Size = new Size(874, 234);
            dgvPendingEvents.TabIndex = 15;
            dgvPendingEvents.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnActivateStudent
            // 
            btnActivateStudent.Location = new Point(937, 499);
            btnActivateStudent.Name = "btnActivateStudent";
            btnActivateStudent.Size = new Size(181, 42);
            btnActivateStudent.TabIndex = 16;
            btnActivateStudent.Text = "Activate Student";
            btnActivateStudent.UseVisualStyleBackColor = true;
            btnActivateStudent.Click += btnActivateStudent_Click;
            // 
            // btnDeactivateStudent
            // 
            btnDeactivateStudent.Location = new Point(937, 554);
            btnDeactivateStudent.Name = "btnDeactivateStudent";
            btnDeactivateStudent.Size = new Size(181, 42);
            btnDeactivateStudent.TabIndex = 17;
            btnDeactivateStudent.Text = "Deactivate Student";
            btnDeactivateStudent.UseVisualStyleBackColor = true;
            btnDeactivateStudent.Click += btnDeactivateStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(937, 609);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(181, 42);
            btnDeleteStudent.TabIndex = 18;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // btnDeleteSociety
            // 
            btnDeleteSociety.Location = new Point(966, 345);
            btnDeleteSociety.Name = "btnDeleteSociety";
            btnDeleteSociety.Size = new Size(165, 40);
            btnDeleteSociety.TabIndex = 19;
            btnDeleteSociety.Text = "Delete Society";
            btnDeleteSociety.UseVisualStyleBackColor = true;
            btnDeleteSociety.Click += btnDeleteSociety_Click;
            // 
            // btnApproveEvent
            // 
            btnApproveEvent.Location = new Point(932, 844);
            btnApproveEvent.Name = "btnApproveEvent";
            btnApproveEvent.Size = new Size(186, 49);
            btnApproveEvent.TabIndex = 20;
            btnApproveEvent.Text = "Approve Event";
            btnApproveEvent.UseVisualStyleBackColor = true;
            btnApproveEvent.Click += btnApproveEvent_Click;
            // 
            // btnRejectEvent
            // 
            btnRejectEvent.Location = new Point(932, 909);
            btnRejectEvent.Name = "btnRejectEvent";
            btnRejectEvent.Size = new Size(186, 44);
            btnRejectEvent.TabIndex = 21;
            btnRejectEvent.Text = "Reject Event";
            btnRejectEvent.UseVisualStyleBackColor = true;
            btnRejectEvent.Click += btnRejectEvent_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1019, 45);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 22;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnOpenRegisterForm
            // 
            btnOpenRegisterForm.Location = new Point(627, 1192);
            btnOpenRegisterForm.Name = "btnOpenRegisterForm";
            btnOpenRegisterForm.Size = new Size(112, 34);
            btnOpenRegisterForm.TabIndex = 24;
            btnOpenRegisterForm.Text = "Register User";
            btnOpenRegisterForm.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 93);
            label6.Name = "label6";
            label6.Size = new Size(295, 38);
            label6.TabIndex = 25;
            label6.Text = "Society Management";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(28, 417);
            label7.Name = "label7";
            label7.Size = new Size(303, 38);
            label7.TabIndex = 26;
            label7.Text = "Student Management";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(28, 745);
            label8.Name = "label8";
            label8.Size = new Size(273, 38);
            label8.TabIndex = 27;
            label8.Text = "Event Management";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 1096);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnOpenRegisterForm);
            Controls.Add(btnLogout);
            Controls.Add(btnRejectEvent);
            Controls.Add(btnApproveEvent);
            Controls.Add(btnDeleteSociety);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnDeactivateStudent);
            Controls.Add(btnActivateStudent);
            Controls.Add(dgvPendingEvents);
            Controls.Add(dgvStudents);
            Controls.Add(dgvSocieties);
            Controls.Add(btnRegisterForm);
            Controls.Add(btnSuspendSociety);
            Controls.Add(btnApproveSociety);
            Controls.Add(btnAddSociety);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtHeadUserId);
            Controls.Add(txtSocietyCategory);
            Controls.Add(txtSocietyDescription);
            Controls.Add(txtSocietyName);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocieties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendingEvents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSocietyName;
        private TextBox txtSocietyDescription;
        private TextBox txtSocietyCategory;
        private TextBox txtHeadUserId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAddSociety;
        private Button btnApproveSociety;
        private Button btnSuspendSociety;
        private Button btnRegisterForm;
        private DataGridView dgvSocieties;
        private DataGridView dgvStudents;
        private DataGridView dgvPendingEvents;
        private Button btnActivateStudent;
        private Button btnDeactivateStudent;
        private Button btnDeleteStudent;
        private Button btnDeleteSociety;
        private Button btnApproveEvent;
        private Button btnRejectEvent;
        private Button btnLogout;
        private Button btnOpenRegisterForm;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}