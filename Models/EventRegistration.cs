using System;

namespace FastSocietyManagementSystem.Models
{
    // Registration of a student for an event
    public class EventRegistration
    {
        public int RegistrationId { get; set; }

        public int EventId { get; set; }

        public int StudentId { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // e.g. Pending, Approved, Cancelled
        public string? Status { get; set; } = "Pending";
    }
}
