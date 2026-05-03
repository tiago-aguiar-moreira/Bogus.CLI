using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class DatabaseDatasetService(IDatabaseFakerAdapter databaseAdapter) : IDatabaseDatasetService
{
    private readonly IDatabaseFakerAdapter _databaseAdapter = databaseAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        DatabaseProperty.COLUMN => _databaseAdapter.Column(),
        DatabaseProperty.TYPE => _databaseAdapter.Type(),
        DatabaseProperty.COLLATION => _databaseAdapter.Collation(),
        DatabaseProperty.ENGINE => _databaseAdapter.Engine(),
        _ => null
    };
}
