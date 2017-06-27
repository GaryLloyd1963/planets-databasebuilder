using System;
using System.Configuration;
using System.Data.SqlClient;
using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Builder
{
    public class DatabaseCreator : IDatabaseCreator
    {
        public bool CreateDatabase(DatabaseDetails dbDetails)
        {
            var connection = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            var sqlQuery = $"CREATE DATABASE {dbDetails.DatabaseName}";

            try
            {
                using (var sqlConnection = new SqlConnection {ConnectionString = connection})
                {
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        Console.WriteLine($"DatabaseCreator: attempting to create {dbDetails.DatabaseName}");
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"DatabaseCreator: failed to create {dbDetails.DatabaseName} - {e.Message}");
                return false;
            }
            return true;
        }
    }
}