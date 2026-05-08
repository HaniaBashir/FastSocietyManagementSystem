using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class SocietyTask
    {
        public int TaskId { get; set; }

        public int SocietyId { get; set; }

        public int AssignedToStudentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
