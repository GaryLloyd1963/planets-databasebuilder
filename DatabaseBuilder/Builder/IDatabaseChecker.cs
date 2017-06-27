namespace DatabaseBuilder.Builder
{
    public interface IDatabaseChecker
    {
        bool DatabaseExists(string databaseName);
    }
}