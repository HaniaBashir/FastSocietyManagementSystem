using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Repositories
{
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

        public int RegisterForEvent(int eventId, int studentId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

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

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);
            command.Parameters.AddWithValue("@StudentId", studentId);

            connection.Open();

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public void CreateTicket(int registrationId, string ticketCode)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

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

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RegistrationId", registrationId);
            command.Parameters.AddWithValue("@TicketCode", ticketCode);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public List<Ticket> GetTicketsByStudentId(int studentId)
        {
            List<Ticket> tickets = new();

            using SqlConnection connection = _databaseConnection.GetConnection();

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

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentId", studentId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket
                {
                    TicketId = Convert.ToInt32(reader["TicketId"]),
                    RegistrationId = Convert.ToInt32(reader["RegistrationId"]),
                    TicketCode = reader["TicketCode"].ToString()!,
                    IssuedAt = Convert.ToDateTime(reader["IssuedAt"])
                };

                tickets.Add(ticket);
            }

            return tickets;
        }

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


        public List<SocietyTask> GetTasksByStudentId(int studentId)
        {
            List<SocietyTask> tasks = new();

            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        SELECT *
        FROM SocietyTasks
        WHERE AssignedToStudentId = @StudentId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentId", studentId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SocietyTask task = new SocietyTask
                {
                    TaskId = Convert.ToInt32(reader["TaskId"]),
                    SocietyId = Convert.ToInt32(reader["SocietyId"]),
                    AssignedToStudentId = Convert.ToInt32(reader["AssignedToStudentId"]),
                    Title = reader["Title"].ToString()!,
                    Description = reader["Description"].ToString()!,
                    DueDate = Convert.ToDateTime(reader["DueDate"]),
                    Status = reader["Status"].ToString()!,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                };

                tasks.Add(task);
            }

            return tasks;
        }

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

        public bool IsStudentAlreadyRegistered(int eventId, int studentId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        SELECT COUNT(*)
        FROM EventRegistrations
        WHERE EventId = @EventId
          AND StudentId = @StudentId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);
            command.Parameters.AddWithValue("@StudentId", studentId);

            connection.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }

        public int GetEventRegistrationCount(int eventId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        SELECT COUNT(*)
        FROM EventRegistrations
        WHERE EventId = @EventId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);

            connection.Open();

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public int GetEventCapacity(int eventId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        SELECT Capacity
        FROM SocietyEvents
        WHERE EventId = @EventId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);

            connection.Open();

            object? result = command.ExecuteScalar();

            if (result == null)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }
    }
}
