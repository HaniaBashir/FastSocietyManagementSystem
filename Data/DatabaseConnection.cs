using System;
using System.Data;

namespace FastSocietyManagementSystem.Data
{
    // Placeholder for database connection handling
    public class DatabaseConnection
    {
        // Connection details should be stored in configuration; this is a stub
        public IDbConnection? Connection { get; private set; }

        public DatabaseConnection()
        {
            Connection = null; // Initialize real connection in implementation
        }
    }
}
