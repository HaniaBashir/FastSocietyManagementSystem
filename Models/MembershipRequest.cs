using System;

namespace FastSocietyManagementSystem.Models
{
    // Request to join a society
    public class MembershipRequest
    {
        public int RequestId { get; set; }

        public int StudentId { get; set; }

        public int SocietyId { get; set; }

        // Pending, Approved, Rejected
        public string? Status { get; set; } = "Pending";

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ReviewedAt { get; set; }
    }
}
