using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int UserId { get; set; }

        public string RollNumber { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int Semester { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
