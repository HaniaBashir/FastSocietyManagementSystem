using System;

namespace FastSocietyManagementSystem.Models
{
    // Represents a student society/club
    public class Society
    {
        public int SocietyId { get; set; }

        public string? SocietyName { get; set; }

        public string? Description { get; set; }

        // e.g. Cultural, Technical, Sports
        public string? Category { get; set; }

        // FK to User.UserId - society head
        public int? HeadUserId { get; set; }

        // Status values: Active, Suspended, Cancelled
        public string? Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
