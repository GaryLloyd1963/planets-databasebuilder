using System.Reflection;
using System.Security.Policy;

namespace DatabaseBuilder.Configuration
{
    public class DatabaseDetails
    {
        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public Assembly MigrationAssembly { get; set; }
        public string SeedDataProfile { get; set; }
    }
}