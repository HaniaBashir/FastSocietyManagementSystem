namespace FastSocietyManagementSystem.Forms
{
    partial class TaskManagementForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTaskTitle = new TextBox();
            txtTaskDescription = new TextBox();
            cmbStudents = new ComboBox();
            dtpDueDate = new DateTimePicker();
            btnCreateTask = new Button();
            btnBack = new Button();
            dgvTasks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 79);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 0;
            label1.Text = "Task Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(411, 141);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(411, 209);
            label3.Name = "label3";
            label3.Size = new Size(131, 25);
            label3.TabIndex = 2;
            label3.Text = "Assign Student";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(411, 276);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 3;
            label4.Text = "Due Date";
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(411, 107);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(150, 31);
            txtTaskTitle.TabIndex = 4;
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(411, 169);
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(150, 31);
            txtTaskDescription.TabIndex = 5;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(411, 237);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(182, 33);
            cmbStudents.TabIndex = 6;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(411, 304);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(300, 31);
            dtpDueDate.TabIndex = 7;
            // 
            // btnCreateTask
            // 
            btnCreateTask.Location = new Point(411, 358);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(112, 34);
            btnCreateTask.TabIndex = 8;
            btnCreateTask.Text = "Create Task";
            btnCreateTask.UseVisualStyleBackColor = true;
            btnCreateTask.Click += btnCreateTask_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(12, 79);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 62;
            dgvTasks.Size = new Size(377, 313);
            dgvTasks.TabIndex = 10;
            // 
            // TaskManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvTasks);
            Controls.Add(btnBack);
            Controls.Add(btnCreateTask);
            Controls.Add(dtpDueDate);
            Controls.Add(cmbStudents);
            Controls.Add(txtTaskDescription);
            Controls.Add(txtTaskTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TaskManagementForm";
            Text = "TaskManagementForm";
            Load += TaskManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTaskTitle;
        private TextBox txtTaskDescription;
        private ComboBox cmbStudents;
        private DateTimePicker dtpDueDate;
        private Button btnCreateTask;
        private Button btnBack;
        private DataGridView dgvTasks;
    }
}