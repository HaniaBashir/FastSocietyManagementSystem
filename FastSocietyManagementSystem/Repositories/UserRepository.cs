using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles all database operations related to users such as:
    /// - registration
    /// - login retrieval
    /// - activation/deactivation
    /// - student listing
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public UserRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

        /// <summary>
        /// Adds a new user account to the system.
        /// </summary>
        public void AddUser(User user)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"INSERT INTO Users
                (
                    FullName,
                    Email,
                    PasswordHash,
                    Role,
                    IsActive
                )
                VALUES
                (
                    @FullName,
                    @Email,
                    @PasswordHash,
                    @Role,
                    @IsActive
                )";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@FullName",
                user.FullName
            );

            command.Parameters.AddWithValue(
                "@Email",
                user.Email
            );

            command.Parameters.AddWithValue(
                "@PasswordHash",
                user.PasswordHash
            );

            command.Parameters.AddWithValue(
                "@Role",
                user.Role
            );

            command.Parameters.AddWithValue(
                "@IsActive",
                user.IsActive
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves a user using their email address.
        /// Used during authentication and duplicate checking.
        /// </summary>
        public User? GetUserByEmail(string email)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT *
                  FROM Users
                  WHERE Email = @Email";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@Email",
                email
            );

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    UserId = Convert.ToInt32(
                        reader["UserId"]
                    ),

                    FullName =
                        reader["FullName"].ToString()!,

                    Email =
                        reader["Email"].ToString()!,

                    PasswordHash =
                        reader["PasswordHash"].ToString()!,

                    Role =
                        reader["Role"].ToString()!,

                    IsActive = Convert.ToBoolean(
                        reader["IsActive"]
                    ),

                    CreatedAt = Convert.ToDateTime(
                        reader["CreatedAt"]
                    )
                };
            }

            return null;
        }

        /// <summary>
        /// Retrieves all users registered as students.
        /// Used by admin management features.
        /// </summary>
        public List<User> GetAllStudents()
        {
            List<User> users = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT *
                FROM Users
                WHERE Role = 'Student'
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(
                        reader["UserId"]
                    ),

                    FullName =
                        reader["FullName"].ToString()!,

                    Email =
                        reader["Email"].ToString()!,

                    PasswordHash =
                        reader["PasswordHash"].ToString()!,

                    Role =
                        reader["Role"].ToString()!,

                    IsActive = Convert.ToBoolean(
                        reader["IsActive"]
                    ),

                    CreatedAt = Convert.ToDateTime(
                        reader["CreatedAt"]
                    )
                });
            }

            return users;
        }

        /// <summary>
        /// Activates or deactivates a user account.
        /// Inactive users cannot log in.
        /// </summary>
        public void UpdateUserStatus(
            int userId,
            bool isActive
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE Users
                SET IsActive = @IsActive
                WHERE UserId = @UserId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserId",
                userId
            );

            command.Parameters.AddWithValue(
                "@IsActive",
                isActive
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Soft-deletes a user by deactivating the account
        /// instead of permanently removing database records.
        /// </summary>
        public void DeleteUser(int userId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE Users
                SET IsActive = 0
                WHERE UserId = @UserId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserId",
                userId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}