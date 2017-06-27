using System.Collections.Generic;

namespace DatabaseBuilder.Configuration
{
    public interface IDatabaseConfiguration
    {
        List<DatabaseDetails> GetDatabasesToBeBuilt();
    }
}