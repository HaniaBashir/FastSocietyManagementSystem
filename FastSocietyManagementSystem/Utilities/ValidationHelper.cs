using System;
using System.Collections.Generic;
using System.Text;
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
            return !IsEmpty(password) && password.Length >= 6;
        }

        public static bool IsPositiveNumber(string value, out int number)
        {
            bool isNumber = int.TryParse(value, out number);

            return isNumber && number > 0;
        }

        public static bool IsValidFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }

        public static bool IsValidName(string value)
        {
            if (IsEmpty(value))
            {
                return false;
            }

            return value.Trim().Length >= 3;
        }

        public static bool IsValidRollNumber(string value)
        {
            if (IsEmpty(value))
            {
                return false;
            }

            return value.Trim().Length >= 4;
        }
    }
}
