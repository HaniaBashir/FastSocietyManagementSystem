using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles all student-related database operations such as:
    /// - event registration
    /// - ticket generation
    /// - task retrieval
    /// - task status updates
    /// - event capacity checks
    /// </summary>
    public class StudentRepository
        : IStudentRepository
    {
        private readonly DatabaseConnection
            _databaseConnection;

        public StudentRepository()
        {
            _databaseConnection =
                new DatabaseConnection();
        }

        /// <summary>
        /// Retrieves the student ID associated
        /// with the currently logged-in user.
        /// </summary>
        public int GetStudentIdByUserId(int userId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT StudentId
                  FROM Students
                  WHERE UserId = @UserId";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserId",
                userId
            );

            connection.Open();

            object? result =
                command.ExecuteScalar();

            if (result != null)
            {
                return Convert.ToInt32(result);
            }

            return -1;
        }

        /// <summary>
        /// Retrieves all active events available
        /// for student registration.
        /// </summary>
        public List<SocietyEvent> GetAllEvents()
        {
            List<SocietyEvent> events = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT *
                  FROM SocietyEvents
                  WHERE Status = 'Active'";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                SocietyEvent societyEvent =
                    new SocietyEvent
                    {
                        EventId = Convert.ToInt32(
                            reader["EventId"]
                        ),

                        SocietyId = Convert.ToInt32(
                            reader["SocietyId"]
                        ),

                        Title = reader["Title"].ToString()!,

                        Description =
                            reader["Description"].ToString()!,

                        EventDate = Convert.ToDateTime(
                            reader["EventDate"]
                        ),

                        Venue =
                            reader["Venue"].ToString()!,

                        Capacity = Convert.ToInt32(
                            reader["Capacity"]
                        ),

                        Status =
                            reader["Status"].ToString()!
                    };

                events.Add(societyEvent);
            }

            return events;
        }

        /// <summary>
        /// Registers a student for an event
        /// and returns the generated registration ID.
        /// </summary>
        public int RegisterForEvent(
            int eventId,
            int studentId
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                INSERT INTO EventRegistrations
                (
                    EventId,
                    StudentId,
                    Status
                )
                OUTPUT INSERTED.RegistrationId
                VALUES
                (
                    @EventId,
                    @StudentId,
                    'Registered'
                )
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            connection.Open();

            return Convert.ToInt32(
                command.ExecuteScalar()
            );
        }

        /// <summary>
        /// Creates a ticket record after
        /// successful event registration.
        /// </summary>
        public void CreateTicket(
            int registrationId,
            string ticketCode
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                INSERT INTO Tickets
                (
                    RegistrationId,
                    TicketCode
                )
                VALUES
                (
                    @RegistrationId,
                    @TicketCode
                )
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@RegistrationId",
                registrationId
            );

            command.Parameters.AddWithValue(
                "@TicketCode",
                ticketCode
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all tickets belonging
        /// to a specific student.
        /// </summary>
        public List<Ticket> GetTicketsByStudentId(
            int studentId
        )
        {
            List<Ticket> tickets = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT
                    t.TicketId,
                    t.RegistrationId,
                    t.TicketCode,
                    t.IssuedAt
                FROM Tickets t
                INNER JOIN EventRegistrations er
                    ON t.RegistrationId = er.RegistrationId
                WHERE er.StudentId = @StudentId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket
                {
                    TicketId = Convert.ToInt32(
                        reader["TicketId"]
                    ),

                    RegistrationId = Convert.ToInt32(
                        reader["RegistrationId"]
                    ),

                    TicketCode =
                        reader["TicketCode"].ToString()!,

                    IssuedAt = Convert.ToDateTime(
                        reader["IssuedAt"]
                    )
                };

                tickets.Add(ticket);
            }

            return tickets;
        }

        /// <summary>
        /// Retrieves all registered students.
        /// Used mainly for task assignment.
        /// </summary>
        public List<Student> GetAllStudents()
        {
            List<Student> students = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT
                    s.StudentId,
                    s.UserId,
                    s.RollNumber,
                    s.Department,
                    s.Semester,
                    u.FullName,
                    u.Email
                FROM Students s
                INNER JOIN Users u
                    ON s.UserId = u.UserId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student
                {
                    StudentId = Convert.ToInt32(
                        reader["StudentId"]
                    ),

                    UserId = Convert.ToInt32(
                        reader["UserId"]
                    ),

                    RollNumber =
                        reader["RollNumber"].ToString()!,

                    Department =
                        reader["Department"].ToString()!,

                    Semester = Convert.ToInt32(
                        reader["Semester"]
                    ),

                    FullName =
                        reader["FullName"].ToString()!,

                    Email =
                        reader["Email"].ToString()!
                };

                students.Add(student);
            }

            return students;
        }

        /// <summary>
        /// Retrieves all tasks assigned
        /// to a specific student.
        /// </summary>
        public List<SocietyTask> GetTasksByStudentId(
            int studentId
        )
        {
            List<SocietyTask> tasks = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT *
                FROM SocietyTasks
                WHERE AssignedToStudentId = @StudentId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                SocietyTask task = new SocietyTask
                {
                    TaskId = Convert.ToInt32(
                        reader["TaskId"]
                    ),

                    SocietyId = Convert.ToInt32(
                        reader["SocietyId"]
                    ),

                    AssignedToStudentId =
                        Convert.ToInt32(
                            reader["AssignedToStudentId"]
                        ),

                    Title =
                        reader["Title"].ToString()!,

                    Description =
                        reader["Description"].ToString()!,

                    DueDate = Convert.ToDateTime(
                        reader["DueDate"]
                    ),

                    Status =
                        reader["Status"].ToString()!,

                    CreatedAt = Convert.ToDateTime(
                        reader["CreatedAt"]
                    )
                };

                tasks.Add(task);
            }

            return tasks;
        }

        /// <summary>
        /// Updates the progress status of a task.
        /// Example statuses:
        /// Pending, In Progress, Completed.
        /// </summary>
        public void UpdateTaskStatus(
            int taskId,
            string status
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE SocietyTasks
                SET Status = @Status
                WHERE TaskId = @TaskId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@Status",
                status
            );

            command.Parameters.AddWithValue(
                "@TaskId",
                taskId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Checks whether a student has already
        /// registered for a specific event.
        /// </summary>
        public bool IsStudentAlreadyRegistered(
            int eventId,
            int studentId
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT COUNT(*)
                FROM EventRegistrations
                WHERE EventId = @EventId
                  AND StudentId = @StudentId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            command.Parameters.AddWithValue(
                "@StudentId",
                studentId
            );

            connection.Open();

            int count = Convert.ToInt32(
                command.ExecuteScalar()
            );

            return count > 0;
        }

        /// <summary>
        /// Retrieves total registrations
        /// for a specific event.
        /// </summary>
        public int GetEventRegistrationCount(
            int eventId
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT COUNT(*)
                FROM EventRegistrations
                WHERE EventId = @EventId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            connection.Open();

            return Convert.ToInt32(
                command.ExecuteScalar()
            );
        }

        /// <summary>
        /// Retrieves maximum event capacity
        /// configured for an event.
        /// </summary>
        public int GetEventCapacity(int eventId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT Capacity
                FROM SocietyEvents
                WHERE EventId = @EventId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            connection.Open();

            object? result =
                command.ExecuteScalar();

            if (result == null)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }

        public string GetEventStatus(int eventId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
        SELECT Status
        FROM SocietyEvents
        WHERE EventId = @EventId
        ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            connection.Open();

            object? result =
                command.ExecuteScalar();

            return result?.ToString() ?? "";
        }

        public DateTime GetEventDate(int eventId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
        SELECT EventDate
        FROM SocietyEvents
        WHERE EventId = @EventId
        ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            connection.Open();

            object? result =
                command.ExecuteScalar();

            if (result == null)
            {
                return DateTime.MinValue;
            }

            return Convert.ToDateTime(result);
        }

        public List<Student> GetApprovedMembersBySocietyId(int societyId)
        {
            List<Student> students = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
        SELECT
            st.StudentId,
            st.UserId,
            st.RollNumber,
            st.Department,
            st.Semester,
            u.FullName,
            u.Email
        FROM MembershipRequests mr
        INNER JOIN Students st
            ON mr.StudentId = st.StudentId
        INNER JOIN Users u
            ON st.UserId = u.UserId
        WHERE mr.SocietyId = @SocietyId
          AND mr.Status = 'Approved'
          AND u.Role = 'Student'
          AND u.IsActive = 1
        ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SocietyId", societyId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    RollNumber = reader["RollNumber"].ToString()!,
                    Department = reader["Department"].ToString()!,
                    Semester = Convert.ToInt32(reader["Semester"]),
                    FullName = reader["FullName"].ToString()!,
                    Email = reader["Email"].ToString()!
                });
            }

            return students;
        }
    }
}