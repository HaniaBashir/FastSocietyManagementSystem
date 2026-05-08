using System;
using System.Collections.Generic;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    // Simple in-memory repository placeholder
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User? GetById(Guid id) => _users.Find(u => u.Id == id);

        public User? GetByEmail(string email) => _users.Find(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<User> GetAll() => _users.AsReadOnly();

        public void Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing == null) return;
            existing.FullName = user.FullName;
            existing.Email = user.Email;
            // other fields as needed
        }

        public void Delete(Guid id)
        {
            var user = GetById(id);
            if (user != null) _users.Remove(user);
        }
    }
}
