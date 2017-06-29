using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FluentMigrator;

namespace AstroData.Extensions
{
    public static class AstroDataExtensions
    {
        public static bool TableContainsData(this Migration migration, string tableName)
        {
            using (IDbConnection db = new SqlConnection(migration.ConnectionString))
            {
                return db.Query<int>($"Select Count(*) From {tableName}").First() > 0;
            }
        }       
    }
}