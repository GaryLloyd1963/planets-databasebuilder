using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Migrator
{
    public interface IDatabaseMigrator
    {
        bool MigrateUp(DatabaseDetails dbDetails);
    }
}