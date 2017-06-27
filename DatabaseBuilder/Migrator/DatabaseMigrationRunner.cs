using System.Diagnostics;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace DatabaseBuilder.Migrator
{
    public class DatabaseMigrationRunner : IDatabaseMigrationRunner
    {
        public MigrationRunner CreateMigrationRunner(string connectionString, Assembly migrationsAssembly, string seedDataProfile)
        {
            var announcer = new TextWriterAnnouncer(s => Trace.WriteLine(s));
            var migrationContext = new RunnerContext(announcer);

            if ( !string.IsNullOrEmpty(seedDataProfile))
                migrationContext.Profile = seedDataProfile;

            var options = new DatabaseMigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2012ProcessorFactory();
            var processor = factory.Create(connectionString, announcer, options);
            var runner = new MigrationRunner(migrationsAssembly, migrationContext, processor);

            return runner;
        }
    }
}