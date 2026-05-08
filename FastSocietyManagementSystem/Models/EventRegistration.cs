using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class EventRegistration
    {
        public int RegistrationId { get; set; }

        public int EventId { get; set; }

        public int StudentId { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Registered";
    }
}
