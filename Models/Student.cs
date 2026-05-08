using System;

namespace FastSocietyManagementSystem.Models
{
    // Student entity separate from User for relational mapping
    public class Student
    {
        public int StudentId { get; set; }

        // FK to User.UserId
        public int UserId { get; set; }

        public string? RollNumber { get; set; }

        public string? Department { get; set; }

        public int Semester { get; set; }
    }
}
