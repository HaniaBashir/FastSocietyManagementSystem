using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem.Repositories
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public SocietyRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

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

        public void UpdateEvent(SocietyEvent societyEvent)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

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

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", societyEvent.EventId);
            command.Parameters.AddWithValue("@Title", societyEvent.Title);
            command.Parameters.AddWithValue("@Description", societyEvent.Description);
            command.Parameters.AddWithValue("@EventDate", societyEvent.EventDate);
            command.Parameters.AddWithValue("@Venue", societyEvent.Venue);
            command.Parameters.AddWithValue("@Capacity", societyEvent.Capacity);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void CancelEvent(int eventId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        UPDATE SocietyEvents
        SET Status = 'Cancelled'
        WHERE EventId = @EventId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void AddSociety(Society society)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

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

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SocietyName", society.SocietyName);
            command.Parameters.AddWithValue("@Description", society.Description);
            command.Parameters.AddWithValue("@Category", society.Category);
            command.Parameters.AddWithValue("@HeadUserId", society.HeadUserId);
            command.Parameters.AddWithValue("@Status", society.Status);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void UpdateSocietyStatus(int societyId, string status)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        UPDATE Societies
        SET Status = @Status
        WHERE SocietyId = @SocietyId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SocietyId", societyId);
            command.Parameters.AddWithValue("@Status", status);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void DeleteSociety(int societyId)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        UPDATE Societies
        SET Status = 'Deleted'
        WHERE SocietyId = @SocietyId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SocietyId", societyId);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public List<SocietyEvent> GetPendingEvents()
        {
            List<SocietyEvent> events = new();

            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        SELECT *
        FROM SocietyEvents
        WHERE Status = 'Pending'
        ";

            using SqlCommand command = new SqlCommand(query, connection);

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

        public void UpdateEventStatus(int eventId, string status)
        {
            using SqlConnection connection = _databaseConnection.GetConnection();

            string query =
                @"
        UPDATE SocietyEvents
        SET Status = @Status
        WHERE EventId = @EventId
        ";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventId", eventId);
            command.Parameters.AddWithValue("@Status", status);

            connection.Open();

            command.ExecuteNonQuery();
        }

    }
}
