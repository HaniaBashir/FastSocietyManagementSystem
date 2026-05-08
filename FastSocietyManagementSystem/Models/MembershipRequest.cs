using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Models
{
    public class MembershipRequest
    {
        public int RequestId { get; set; }

        public int StudentId { get; set; }

        public int SocietyId { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestedAt { get; set; } = DateTime.Now;

        public DateTime? ReviewedAt { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string SocietyName { get; set; } = string.Empty;

    }
}
