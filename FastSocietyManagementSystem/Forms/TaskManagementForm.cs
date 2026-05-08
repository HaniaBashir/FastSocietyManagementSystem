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
    public partial class TaskManagementForm : Form
    {
        public TaskManagementForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoadStudents()
        {
            StudentService studentService =
                new StudentService();

            List<Student> students =
                studentService.GetAllStudents();

            cmbStudents.DataSource = students;

            cmbStudents.DisplayMember =
                "FullName";

            cmbStudents.ValueMember =
                "StudentId";
        }

        private void LoadTasks()
        {
            TaskService taskService =
                new TaskService();

            dgvTasks.DataSource =
                taskService.GetAllTasks();
        }

        private void TaskManagementForm_Load(
    object sender,
    EventArgs e
)
        {
            LoadStudents();

            LoadTasks();
        }

        private void btnCreateTask_Click(
    object sender,
    EventArgs e
)
        {
            if (
                txtTaskTitle.Text.Trim() == "" ||
                txtTaskDescription.Text.Trim() == ""
            )
            {
                MessageBox.Show(
                    "Please fill all fields."
                );

                return;
            }

            int selectedStudentId =
                Convert.ToInt32(
                    cmbStudents.SelectedValue
                );

            string selectedStudentName =
                cmbStudents.Text;

            DialogResult result =
                MessageBox.Show(
                    $"Are you sure you want to assign this task?\n\n" +
                    $"Task: {txtTaskTitle.Text}\n" +
                    $"Assigned To: {selectedStudentName}\n" +
                    $"Due Date: {dtpDueDate.Value}",
                    "Confirm Task Assignment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SocietyTask societyTask =
                new SocietyTask
                {
                    SocietyId = 1,

                    AssignedToStudentId =
                        selectedStudentId,

                    Title =
                        txtTaskTitle.Text.Trim(),

                    Description =
                        txtTaskDescription.Text.Trim(),

                    DueDate =
                        dtpDueDate.Value,

                    Status = "Pending"
                };

            TaskService taskService =
                new TaskService();

            taskService.AddTask(
                societyTask
            );

            MessageBox.Show(
                "Task assigned successfully!"
            );

            LoadTasks();

            txtTaskTitle.Clear();

            txtTaskDescription.Clear();
        }

        private void btnBack_Click(
    object sender,
    EventArgs e
)
        {
            this.Close();
        }
    }
}
