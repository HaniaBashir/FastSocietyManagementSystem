using System;
using System.Collections.Generic;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    // Repository interface for user-related data access
    public interface IUserRepository
    {
        User? GetById(Guid id);
        User? GetByEmail(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(Guid id);
    }
}
