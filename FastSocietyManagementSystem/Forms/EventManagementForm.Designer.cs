namespace FastSocietyManagementSystem.Forms
{
    partial class EventManagementForm
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
            label5 = new Label();
            label6 = new Label();
            txtVenue = new TextBox();
            txtEventTitle = new TextBox();
            txtCapacity = new TextBox();
            dgvEvents = new DataGridView();
            dtpEventDate = new DateTimePicker();
            txtEventDescription = new RichTextBox();
            btnCreateEvent = new Button();
            btnUpdateEvent = new Button();
            btnCancelEvent = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 95);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 0;
            label1.Text = "Event Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 178);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 261);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 2;
            label3.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 340);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 3;
            label4.Text = "Venue";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 420);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 4;
            label5.Text = "Capacity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(362, 52);
            label6.Name = "label6";
            label6.Size = new Size(165, 25);
            label6.TabIndex = 5;
            label6.Text = "Event Management";
            label6.Click += label6_Click;
            // 
            // txtVenue
            // 
            txtVenue.Location = new Point(362, 368);
            txtVenue.Name = "txtVenue";
            txtVenue.Size = new Size(390, 31);
            txtVenue.TabIndex = 6;
            // 
            // txtEventTitle
            // 
            txtEventTitle.Location = new Point(362, 135);
            txtEventTitle.Name = "txtEventTitle";
            txtEventTitle.Size = new Size(390, 31);
            txtEventTitle.TabIndex = 7;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(362, 455);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(390, 31);
            txtCapacity.TabIndex = 8;
            // 
            // dgvEvents
            // 
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(19, 52);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.RowHeadersWidth = 62;
            dgvEvents.Size = new Size(318, 485);
            dgvEvents.TabIndex = 9;
            dgvEvents.CellClick += dgvEvents_CellClick;
            dgvEvents.CellContentClick += dgvEvents_CellContentClick;
            // 
            // dtpEventDate
            // 
            dtpEventDate.Location = new Point(362, 294);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(390, 31);
            dtpEventDate.TabIndex = 10;
            // 
            // txtEventDescription
            // 
            txtEventDescription.Location = new Point(362, 206);
            txtEventDescription.Name = "txtEventDescription";
            txtEventDescription.Size = new Size(390, 52);
            txtEventDescription.TabIndex = 11;
            txtEventDescription.Text = "";
            // 
            // btnCreateEvent
            // 
            btnCreateEvent.Location = new Point(353, 503);
            btnCreateEvent.Name = "btnCreateEvent";
            btnCreateEvent.Size = new Size(133, 34);
            btnCreateEvent.TabIndex = 12;
            btnCreateEvent.Text = "Create Event";
            btnCreateEvent.UseVisualStyleBackColor = true;
            btnCreateEvent.Click += btnCreateEvent_Click;
            // 
            // btnUpdateEvent
            // 
            btnUpdateEvent.Location = new Point(492, 503);
            btnUpdateEvent.Name = "btnUpdateEvent";
            btnUpdateEvent.Size = new Size(141, 34);
            btnUpdateEvent.TabIndex = 13;
            btnUpdateEvent.Text = "Update Event";
            btnUpdateEvent.UseVisualStyleBackColor = true;
            btnUpdateEvent.Click += btnUpdateEvent_Click;
            // 
            // btnCancelEvent
            // 
            btnCancelEvent.Location = new Point(639, 503);
            btnCancelEvent.Name = "btnCancelEvent";
            btnCancelEvent.Size = new Size(125, 34);
            btnCancelEvent.TabIndex = 14;
            btnCancelEvent.Text = "Cancel Event";
            btnCancelEvent.UseVisualStyleBackColor = true;
            btnCancelEvent.Click += btnCancelEvent_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(21, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // EventManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 564);
            Controls.Add(btnBack);
            Controls.Add(btnCancelEvent);
            Controls.Add(btnUpdateEvent);
            Controls.Add(btnCreateEvent);
            Controls.Add(txtEventDescription);
            Controls.Add(dtpEventDate);
            Controls.Add(dgvEvents);
            Controls.Add(txtCapacity);
            Controls.Add(txtEventTitle);
            Controls.Add(txtVenue);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EventManagementForm";
            Text = "EventManagementForm";
            Load += EventManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtVenue;
        private TextBox txtEventTitle;
        private TextBox txtCapacity;
        private DataGridView dgvEvents;
        private DateTimePicker dtpEventDate;
        private RichTextBox txtEventDescription;
        private Button btnCreateEvent;
        private Button btnUpdateEvent;
        private Button btnCancelEvent;
        private Button btnBack;
    }
}