using System;
using FastSocietyManagementSystem.Repositories;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Services
{
    // Authentication related operations (placeholder)
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Authenticate(string email, string password)
        {
            // Placeholder: password handling should be implemented using PasswordHelper
            var user = _userRepository.GetByEmail(email);
            return user;
        }
    }
}
