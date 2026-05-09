using System.Text.RegularExpressions;

namespace FastSocietyManagementSystem.Utilities
{
    public static class ValidationHelper
    {
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (IsEmpty(email))
            {
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        public static bool IsStrongEnoughPassword(string password)
        {
            return !IsEmpty(password) && password.Trim().Length >= 6;
        }

        public static bool IsFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}