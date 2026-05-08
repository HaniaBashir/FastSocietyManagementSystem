using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;

namespace FastSocietyManagementSystem.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        public bool RegisterUser(
    string fullName,
    string email,
    string password,
    string role
)
        {
            fullName = fullName.Trim();
            email = email.Trim().ToLower();
            password = password.Trim();
            role = role.Trim();

            User? existingUser =
                _userRepository.GetUserByEmail(email);

            if (existingUser != null)
            {
                return false;
            }

            User user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                Role = role,
                IsActive = true
            };

            _userRepository.AddUser(user);

            return true;
        }

        public User? LoginUser(string email, string password)
        {
            email = email.Trim().ToLower();
            password = password.Trim();

            User? user =
                _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            if (!user.IsActive)
            {
                return null;
            }

            if (user.PasswordHash != password)
            {
                return null;
            }

            return user;
        }
    }
}
