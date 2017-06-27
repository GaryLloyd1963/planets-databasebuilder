using DatabaseBuilder.Configuration;

namespace DatabaseBuilder.Builder
{
    public class DatabaseInitiator : IDatabaseInitiator
    {
        private readonly IDatabaseChecker _databaseChecker;
        private readonly IDatabaseCreator _databaseCreator;

        public DatabaseInitiator(IDatabaseChecker databaseChecker
            , IDatabaseCreator databaseCreator)
        {
            _databaseChecker = databaseChecker;
            _databaseCreator = databaseCreator;
        }

        public bool CreateDatabaseIfNotExists(DatabaseDetails dbDetails)
        {
            return _databaseChecker.DatabaseExists(dbDetails.DatabaseName)
                || _databaseCreator.CreateDatabase(dbDetails);
        }
    }
}