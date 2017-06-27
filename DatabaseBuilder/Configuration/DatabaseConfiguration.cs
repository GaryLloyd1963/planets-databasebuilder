using System.Collections.Generic;
using System.Linq;

namespace DatabaseBuilder.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public List<DatabaseDetails> GetDatabasesToBeBuilt()
        {
            return Constants.Databases.DatabasesRequired.ToList();
        }
    }
}