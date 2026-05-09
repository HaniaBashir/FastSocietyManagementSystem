using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles all database operations related to
    /// societies and society events.
    /// </summary>
    public class SocietyRepository : ISocietyRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public SocietyRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

        /// <summary>
        /// Retrieves all societies except soft-deleted societies.
        /// </summary>
        public List<Society> GetAllSocieties()
        {
            List<Society> societies = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT * FROM Societies
                  WHERE Status <> 'Deleted'";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Society society = new Society
                {
                    SocietyId = Convert.ToInt32(
                        reader["SocietyId"]
                    ),

                    SocietyName =
                        reader["SocietyName"].ToString()!,

                    Description =
                        reader["Description"].ToString()!,

                    Category =
                        reader["Category"].ToString()!,

                    Status =
                        reader["Status"].ToString()!
                };

                societies.Add(society);
            }

            return societies;
        }

        /// <summary>
        /// Checks whether the given user is assigned
        /// as a society head.
        /// </summary>
        public bool IsSocietyHead(int userId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT COUNT(*)
                  FROM Societies
                  WHERE HeadUserId = @UserId";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserId",
                userId
            );

            connection.Open();

            int count =
                Convert.ToInt32(
                    command.ExecuteScalar()
                );

            return count > 0;
        }

        /// <summary>
        /// Creates a new society event.
        /// Events are initially created with Pending status
        /// until approved by admin.
        /// </summary>
        public void CreateEvent(
            SocietyEvent societyEvent
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                INSERT INTO SocietyEvents
                (
                    SocietyId,
                    Title,
                    Description,
                    EventDate,
                    Venue,
                    Capacity,
                    Status
                )
                VALUES
                (
                    @SocietyId,
                    @Title,
                    @Description,
                    @EventDate,
                    @Venue,
                    @Capacity,
                    @Status
                )
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyEvent.SocietyId
            );

            command.Parameters.AddWithValue(
                "@Title",
                societyEvent.Title
            );

            command.Parameters.AddWithValue(
                "@Description",
                societyEvent.Description
            );

            command.Parameters.AddWithValue(
                "@EventDate",
                societyEvent.EventDate
            );

            command.Parameters.AddWithValue(
                "@Venue",
                societyEvent.Venue
            );

            command.Parameters.AddWithValue(
                "@Capacity",
                societyEvent.Capacity
            );

            command.Parameters.AddWithValue(
                "@Status",
                societyEvent.Status
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all society events.
        /// </summary>
        public List<SocietyEvent> GetAllEvents()
        {
            List<SocietyEvent> events = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT * FROM SocietyEvents";

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
        /// Updates editable event details.
        /// </summary>
        public void UpdateEvent(SocietyEvent societyEvent)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE SocietyEvents
                SET
                    Title = @Title,
                    Description = @Description,
                    EventDate = @EventDate,
                    Venue = @Venue,
                    Capacity = @Capacity
                WHERE EventId = @EventId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                societyEvent.EventId
            );

            command.Parameters.AddWithValue(
                "@Title",
                societyEvent.Title
            );

            command.Parameters.AddWithValue(
                "@Description",
                societyEvent.Description
            );

            command.Parameters.AddWithValue(
                "@EventDate",
                societyEvent.EventDate
            );

            command.Parameters.AddWithValue(
                "@Venue",
                societyEvent.Venue
            );

            command.Parameters.AddWithValue(
                "@Capacity",
                societyEvent.Capacity
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Soft-cancels an event by updating its status.
        /// </summary>
        public void CancelEvent(int eventId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE SocietyEvents
                SET Status = 'Cancelled'
                WHERE EventId = @EventId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Creates a new society record.
        /// </summary>
        public void AddSociety(Society society)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                INSERT INTO Societies
                (
                    SocietyName,
                    Description,
                    Category,
                    HeadUserId,
                    Status
                )
                VALUES
                (
                    @SocietyName,
                    @Description,
                    @Category,
                    @HeadUserId,
                    @Status
                )
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@SocietyName",
                society.SocietyName
            );

            command.Parameters.AddWithValue(
                "@Description",
                society.Description
            );

            command.Parameters.AddWithValue(
                "@Category",
                society.Category
            );

            command.Parameters.AddWithValue(
                "@HeadUserId",
                society.HeadUserId
            );

            command.Parameters.AddWithValue(
                "@Status",
                society.Status
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates society status such as:
        /// Active, Suspended, Deleted.
        /// </summary>
        public void UpdateSocietyStatus(
            int societyId,
            string status
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE Societies
                SET Status = @Status
                WHERE SocietyId = @SocietyId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyId
            );

            command.Parameters.AddWithValue(
                "@Status",
                status
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Soft-deletes a society instead of permanently
        /// removing it from the database.
        /// </summary>
        public void DeleteSociety(int societyId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE Societies
                SET Status = 'Deleted'
                WHERE SocietyId = @SocietyId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyId
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all events currently waiting
        /// for admin approval.
        /// </summary>
        public List<SocietyEvent> GetPendingEvents()
        {
            List<SocietyEvent> events = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                SELECT *
                FROM SocietyEvents
                WHERE Status = 'Pending'
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                events.Add(new SocietyEvent
                {
                    EventId = Convert.ToInt32(reader["EventId"]),
                    SocietyId = Convert.ToInt32(reader["SocietyId"]),
                    Title = reader["Title"].ToString()!,
                    Description = reader["Description"].ToString()!,
                    EventDate = Convert.ToDateTime(reader["EventDate"]),
                    Venue = reader["Venue"].ToString()!,
                    Capacity = Convert.ToInt32(reader["Capacity"]),
                    Status = reader["Status"].ToString()!,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                });
            }

            return events;
        }

        /// <summary>
        /// Updates event approval status such as:
        /// Active or Rejected.
        /// </summary>
        public void UpdateEventStatus(
            int eventId,
            string status
        )
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                UPDATE SocietyEvents
                SET Status = @Status
                WHERE EventId = @EventId
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@EventId",
                eventId
            );

            command.Parameters.AddWithValue(
                "@Status",
                status
            );

            connection.Open();

            command.ExecuteNonQuery();
        }


        public int GetSocietyIdByHeadUserId(int userId)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
        SELECT TOP 1 SocietyId
        FROM Societies
        WHERE HeadUserId = @UserId
          AND Status <> 'Deleted'
        ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();

            object? result = command.ExecuteScalar();

            if (result == null)
            {
                return -1;
            }

            return Convert.ToInt32(result);
        }

        public List<SocietyEvent> GetEventsBySocietyId(int societyId)
        {
            List<SocietyEvent> events = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
        SELECT *
        FROM SocietyEvents
        WHERE SocietyId = @SocietyId
        ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SocietyId", societyId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                events.Add(new SocietyEvent
                {
                    EventId = Convert.ToInt32(reader["EventId"]),
                    SocietyId = Convert.ToInt32(reader["SocietyId"]),
                    Title = reader["Title"].ToString()!,
                    Description = reader["Description"].ToString()!,
                    EventDate = Convert.ToDateTime(reader["EventDate"]),
                    Venue = reader["Venue"].ToString()!,
                    Capacity = Convert.ToInt32(reader["Capacity"]),
                    Status = reader["Status"].ToString()!,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                });
            }

            return events;
        }
    }
}