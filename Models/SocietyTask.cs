using System;

namespace FastSocietyManagementSystem.Models
{
    // Task or to-do for a society
    public class SocietyTask
    {
        public int TaskId { get; set; }

        public int SocietyId { get; set; }

        public int? AssignedToStudentId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        // Pending, Active, Completed
        public string? Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
