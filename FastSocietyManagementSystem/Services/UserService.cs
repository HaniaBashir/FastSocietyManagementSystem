using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;

namespace FastSocietyManagementSystem.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllStudents()
        {
            return _userRepository.GetAllStudents();
        }

        public void ActivateUser(int userId)
        {
            _userRepository.UpdateUserStatus(userId, true);
        }

        public void DeactivateUser(int userId)
        {
            _userRepository.UpdateUserStatus(userId, false);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
    }
}
