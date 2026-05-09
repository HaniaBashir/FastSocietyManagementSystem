using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem.Repositories
{
    /// <summary>
    /// Handles database operations related to society task assignment
    /// and task retrieval.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseConnection
            _databaseConnection;

        public TaskRepository()
        {
            _databaseConnection =
                new DatabaseConnection();
        }

        /// <summary>
        /// Adds a new task assigned by a society head
        /// to a selected student.
        /// </summary>
        public void AddTask(SocietyTask societyTask)
        {
            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"
                INSERT INTO SocietyTasks
                (
                    SocietyId,
                    AssignedToStudentId,
                    Title,
                    Description,
                    DueDate,
                    Status
                )
                VALUES
                (
                    @SocietyId,
                    @AssignedToStudentId,
                    @Title,
                    @Description,
                    @DueDate,
                    @Status
                )
                ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@SocietyId",
                societyTask.SocietyId
            );

            command.Parameters.AddWithValue(
                "@AssignedToStudentId",
                societyTask.AssignedToStudentId
            );

            command.Parameters.AddWithValue(
                "@Title",
                societyTask.Title
            );

            command.Parameters.AddWithValue(
                "@Description",
                societyTask.Description
            );

            command.Parameters.AddWithValue(
                "@DueDate",
                societyTask.DueDate
            );

            command.Parameters.AddWithValue(
                "@Status",
                societyTask.Status
            );

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all assigned society tasks.
        /// Used by society heads to monitor task distribution.
        /// </summary>
        public List<SocietyTask> GetAllTasks()
        {
            List<SocietyTask> tasks = new();

            using SqlConnection connection =
                _databaseConnection.GetConnection();

            string query =
                @"SELECT * FROM SocietyTasks";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                SocietyTask societyTask =
                    new SocietyTask
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
                            reader["Status"].ToString()!
                    };

                tasks.Add(societyTask);
            }

            return tasks;
        }
    }
}