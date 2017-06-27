using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Builder
{
    public interface IDatabaseSeeder
    {
        bool BuildSeedData(DatabaseDetails dbDetails);
    }
}