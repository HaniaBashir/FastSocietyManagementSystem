using System;

namespace FastSocietyManagementSystem.Models
{
    // Event organized by a society
    public class SocietyEvent
    {
        public int EventId { get; set; }

        public int SocietyId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime EventDate { get; set; }

        public string? Venue { get; set; }

        public int Capacity { get; set; }

        // Status: Pending, Approved, Cancelled
        public string? Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
