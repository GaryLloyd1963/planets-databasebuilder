using System;
using DatabaseBuilder.Configuration;
using DatabaseBuilder.Migrator;

namespace DatabaseBuilder.Builder
{
    public class DatabaseBuilder : IDatabaseBuilder
    {
        private readonly IDatabaseConfiguration _databaseConfig;
        private readonly IDatabaseInitiator _databaseInitiator;
        private readonly IDatabaseMigrator _databaseMigrator;
        private readonly IDatabaseSeeder _databaseSeeder;

        public DatabaseBuilder(IDatabaseConfiguration databaseConfig
            , IDatabaseInitiator databaseInitiator
            , IDatabaseMigrator databaseMigrator
            , IDatabaseSeeder databaseSeeder)
        {
            _databaseConfig = databaseConfig;
            _databaseInitiator = databaseInitiator;
            _databaseMigrator = databaseMigrator;
            _databaseSeeder = databaseSeeder;
        }

        public void BuildDatabases()
        {
            var databasesToBeBuilt = _databaseConfig.GetDatabasesToBeBuilt();

            foreach (var databaseDetail in databasesToBeBuilt)
            {
                if (!_databaseInitiator.CreateDatabaseIfNotExists(databaseDetail))
                {
                    Console.WriteLine($"Failure: Failed to create {databaseDetail.DatabaseName}, halting build process");
                    return;
                }
                Console.WriteLine($"Success: Database {databaseDetail.DatabaseName} exists or has been created");

                if (!_databaseMigrator.MigrateUp(databaseDetail))
                {
                    Console.WriteLine($"Failure: Failed to seed data in {databaseDetail.DatabaseName}, halting build process");
                    return;
                }
                Console.WriteLine($"Success: Database {databaseDetail.DatabaseName} migrate up completed");

                if (!_databaseSeeder.BuildSeedData(databaseDetail))
                {
                    Console.WriteLine($"Failure: Failed to seed data in {databaseDetail.DatabaseName}, halting build process");
                    return;
                }
                Console.WriteLine($"Success: Database {databaseDetail.DatabaseName} data seeded");

                Console.WriteLine($"Success: database build complete");
            }
        }
    }
}