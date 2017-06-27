using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Builder
{
    public interface IDatabaseInitiator
    {
        bool CreateDatabaseIfNotExists(DatabaseDetails dbDetails);
    }
}