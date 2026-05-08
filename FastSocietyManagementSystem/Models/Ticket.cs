
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int RegistrationId { get; set; }

        public string TicketCode { get; set; } = string.Empty;

        public DateTime IssuedAt { get; set; } = DateTime.Now;
    }
}
