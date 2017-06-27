using System;
using System.Configuration;
using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Migrator
{
    public class DatabaseMigrator : IDatabaseMigrator
    {
        private readonly IDatabaseMigrationRunner _databaseMigrationRunner;

        public DatabaseMigrator(IDatabaseMigrationRunner databaseMigrationRunner)
        {
            _databaseMigrationRunner = databaseMigrationRunner;
        }

        public bool MigrateUp(DatabaseDetails dbDetails)
        {
            try
            {
                Console.WriteLine($"Migrate up Name:{dbDetails.DatabaseName}, Assembly:{dbDetails.MigrationAssembly}");

                var connection = ConfigurationManager.ConnectionStrings[dbDetails.ConnectionName].ConnectionString;

                var runner = _databaseMigrationRunner.CreateMigrationRunner(connection, dbDetails.MigrationAssembly, string.Empty);

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