using System;
using System.Security.Cryptography;
using System.Text;

namespace FastSocietyManagementSystem.Utilities
{
    // Minimal password hashing helper (placeholder). Replace with a secure library or PBKDF2 in production.
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string hashed)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (hashed == null) return false;
            return string.Equals(HashPassword(password), hashed, StringComparison.Ordinal);
        }
    }
}
