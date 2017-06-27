using System;
using System.Configuration;
using DatabaseBuilder.Configuration;
using DatabaseBuilder.Migrator;

namespace DatabaseBuilder.Builder
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IDatabaseMigrationRunner _databaseMigrationRunner;

        public DatabaseSeeder(IDatabaseMigrationRunner databaseMigrationRunner)
        {
            _databaseMigrationRunner = databaseMigrationRunner;
        }

        public bool BuildSeedData(DatabaseDetails dbDetails)
        {
            try
            {
                Console.WriteLine($"Build seed data:{dbDetails.DatabaseName}, Assembly:{dbDetails.MigrationAssembly}");

                var connection = ConfigurationManager.ConnectionStrings[dbDetails.ConnectionName].ConnectionString;

                var runner = _databaseMigrationRunner.CreateMigrationRunner(connection, dbDetails.MigrationAssembly, dbDetails.SeedDataProfile);

                runner.MigrateUp();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Failure: Migrate up Name:{dbDetails.DatabaseName}, Assembly:{dbDetails.MigrationAssembly}, Error:{e.Message}");
                return false;
            }
        }
    }
}