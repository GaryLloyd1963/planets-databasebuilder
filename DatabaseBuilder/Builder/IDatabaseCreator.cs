using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Builder
{
    public interface IDatabaseCreator
    {
        bool CreateDatabase(DatabaseDetails dbDetails);
    }
}