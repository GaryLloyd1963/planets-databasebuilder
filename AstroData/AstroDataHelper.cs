using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AstroData
{
    public class AstroDataHelper
    {
        public static bool TableContainsData(string connectionString, string tableName)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>($"Select Count(*) From {tableName}").First() > 0;
            }
        }
    }
}