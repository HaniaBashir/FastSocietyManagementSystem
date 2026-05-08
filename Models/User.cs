using System;

namespace FastSocietyManagementSystem.Models
{
    // Basic user entity
    public class User
    {
        // Int identity for SQL Server
        public int UserId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        // Stored password hash (do not store plain text)
        public string? PasswordHash { get; set; }

        // e.g. Admin, Student, SocietyHead
        public string? Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
