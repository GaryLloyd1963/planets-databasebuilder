using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Constants
{
    public class Databases
    {
        public static DatabaseDetails[] DatabasesRequired = {
            new DatabaseDetails {ConnectionName = "AstroData", DatabaseName = "AstroData", MigrationAssembly = typeof(AstroData.AstroDataAssembly).Assembly, SeedDataProfile = "AstroDataSeedDataProfile"}
        };
    }
}