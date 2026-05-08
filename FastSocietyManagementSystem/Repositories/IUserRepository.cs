using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);

        User? GetUserByEmail(string email);

        List<User> GetAllStudents();

        void UpdateUserStatus(int userId, bool isActive);

        void DeleteUser(int userId);
    }
}
