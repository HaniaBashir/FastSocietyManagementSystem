using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString =
            @"Server=DESKTOP-R87FTCG\SQLEXPRESS;
              Database=FastSocietyManagementDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
