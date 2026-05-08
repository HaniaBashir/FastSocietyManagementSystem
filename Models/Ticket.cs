using System;

namespace FastSocietyManagementSystem.Models
{
    // Ticket entity for issued tickets
    public class Ticket
    {
        public int TicketId { get; set; }

        public int RegistrationId { get; set; }

        public string? TicketCode { get; set; }

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    }
}
