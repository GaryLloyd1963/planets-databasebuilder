using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseBuilder.Builder
{
    public class DatabaseChecker : IDatabaseChecker
    {
        public bool DatabaseExists(string databaseName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            var sqlQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";

            try
            {
                return ExecuteScalar(connectionString, sqlQuery) > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"DatabaseExists: failed to check {databaseName} - {e.Message}");
                return false;
            }
        }

        private static int ExecuteScalar(string connectionString, string sqlQuery)
        {
            using (var sqlConnection = new SqlConnection {ConnectionString = connectionString})
            {
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    return (int)sqlCommand.ExecuteScalar();
                }
            }
        }
    }
}