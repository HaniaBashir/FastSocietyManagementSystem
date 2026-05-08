namespace FastSocietyManagementSystem.Forms
{
    partial class RegisterForm
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
            FullName = new Label();
            Email = new Label();
            Password = new Label();
            Role = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // FullName
            // 
            FullName.AutoSize = true;
            FullName.Location = new Point(392, 76);
            FullName.Name = "FullName";
            FullName.Size = new Size(91, 25);
            FullName.TabIndex = 0;
            FullName.Text = "Full Name";
            FullName.Click += label1_Click;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(392, 152);
            Email.Name = "Email";
            Email.Size = new Size(54, 25);
            Email.TabIndex = 1;
            Email.Text = "Email";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(392, 228);
            Password.Name = "Password";
            Password.Size = new Size(87, 25);
            Password.TabIndex = 2;
            Password.Text = "Password";
            // 
            // Role
            // 
            Role.AutoSize = true;
            Role.Location = new Point(392, 305);
            Role.Name = "Role";
            Role.Size = new Size(46, 25);
            Role.TabIndex = 3;
            Role.Text = "Role";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(392, 104);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(238, 31);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(392, 180);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(238, 31);
            txtEmail.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(392, 256);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(238, 31);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Student", "Admin" });
            cmbRole.Location = new Point(392, 333);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(238, 33);
            cmbRole.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(392, 382);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(112, 34);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 483);
            Controls.Add(btnRegister);
            Controls.Add(cmbRole);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(Role);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(FullName);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FullName;
        private Label Email;
        private Label Password;
        private Label Role;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnRegister;
    }
}