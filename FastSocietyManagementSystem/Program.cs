using FastSocietyManagementSystem.Data;
using FastSocietyManagementSystem.Forms;
using Microsoft.Data.SqlClient;

namespace FastSocietyManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DatabaseConnection databaseConnection = new DatabaseConnection();

            try
            {
                using SqlConnection connection = databaseConnection.GetConnection();

                connection.Open();

                MessageBox.Show(
                    "Database connection successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Database connection failed:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            Application.Run(new LoginForm());
        }
    }
}