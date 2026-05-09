using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles all database operations related to
    /// society membership requests.
    /// </summary>
    public class MembershipRepository
        : IMembershipRepository
    {
        private readonly DatabaseConnection
            _databaseConnection;

        public MembershipRepository()
        {
            _databaseConnection =
                new DatabaseConnection();
        }

        /// <summary>
        /// Creates a new membership request
        /// with default Pending status.
        /// </summary>
        public void AddMembershipRequest(
            int studentId,
            int societyId
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"INSERT INTO MembershipRequests
                (
                    StudentId,
                    SocietyId,
                    Status
                )
                VALUES
                (
                    @StudentId,
                    @SocietyId,
                    'Pending'
                )";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all pending membership requests
        /// along with student and society names.
        /// </summary>
        public List<MembershipRequest>
            GetPendingMembershipRequests()
        {
            List<MembershipRequest> requests = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT
                    mr.RequestId,
                    mr.StudentId,
                    mr.SocietyId,
                    mr.Status,
                    u.FullName AS StudentName,
                    s.SocietyName
                FROM MembershipRequests mr
                INNER JOIN Students st
                    ON mr.StudentId = st.StudentId
                INNER JOIN Users u
                    ON st.UserId = u.UserId
                INNER JOIN Societies s
                    ON mr.SocietyId = s.SocietyId
                WHERE mr.Status = 'Pending'
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                MembershipRequest request =
                    new MembershipRequest
                    {
                        RequestId = Convert.ToInt32(
                            reader["RequestId"]
                        ),

                        StudentId = Convert.ToInt32(
                            reader["StudentId"]
                        ),

                        SocietyId = Convert.ToInt32(
                            reader["SocietyId"]
                        ),

                        Status = reader["Status"].ToString()!,

                        StudentName =
                            reader["StudentName"].ToString()!,

                        SocietyName =
                            reader["SocietyName"].ToString()!
                    };

                requests.Add(request);
            }

            return requests;
        }

        /// <summary>
        /// Updates membership request status
        /// such as Approved or Rejected.
        /// </summary>
        public void UpdateMembershipStatus(
            int requestId,
            string status
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE MembershipRequests
                SET
                    Status = @Status,
                    ReviewedAt = GETDATE()
                WHERE RequestId = @RequestId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@Status",
                status
            );

            command.Parameters.AddWithValue(
                "@RequestId",
                requestId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Checks whether a student already has
        /// a pending or approved request for a society.
        /// 
        /// Prevents duplicate membership applications.
        /// </summary>
        public bool IsMembershipRequestExists(
            int studentId,
            int societyId
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT COUNT(*)
                FROM MembershipRequests
                WHERE StudentId = @StudentId
                  AND SocietyId = @SocietyId
                  AND Status IN ('Pending', 'Approved')
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyId
            );

            connection.Open();

            int count =
                Convert.ToInt32(
                    command.ExecuteScalar()
                );

            return count > 0;
        }
    }
}