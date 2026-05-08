using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class Society
    {
        public int SocietyId { get; set; }

        public string SocietyName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int HeadUserId { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
