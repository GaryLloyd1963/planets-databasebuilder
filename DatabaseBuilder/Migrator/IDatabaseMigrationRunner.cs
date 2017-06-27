using System.Reflection;
using FluentMigrator.Runner;

namespace DatabaseBuilder.Migrator
{
    public interface IDatabaseMigrationRunner
    {
        MigrationRunner CreateMigrationRunner(string connectionString, Assembly migrationsAssembly, string seedDataProfile);
    }
}