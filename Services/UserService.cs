using System;
using System.Collections.Generic;
using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;

namespace FastSocietyManagementSystem.Services
{
    // Service layer for user operations
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? GetUserById(Guid id) => _userRepository.GetById(id);

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

        public void CreateUser(User user)
        {
            // Basic validation and creation logic should go here
            _userRepository.Add(user);
        }
    }
}
