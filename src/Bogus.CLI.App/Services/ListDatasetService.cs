using Bogus.CLI.App.Helpers.Interface;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class ListDatasetService(IDatasetHelper datasetHelper) : IListDatasetService
{
    private readonly IDatasetHelper _datasetHelper = datasetHelper;

    public IList<string> ExecuteCommand(string? datasetName)
    {
        var datasets = new List<string>();

        if (string.IsNullOrEmpty(datasetName))
        {
            datasets.AddRange(_datasetHelper.ListDataset());
        }
        else
        {
            var properties = _datasetHelper.ListPropertiesByDatasetName(datasetName);

            if (properties.Any())
                datasets.AddRange(properties.Order());
        }

        return datasets;
    }
}