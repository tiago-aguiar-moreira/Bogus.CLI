namespace Bogus.CLI.Core.Helpers.Interface;
public interface IDatasetHelper
{
    IEnumerable<string> ListPropertiesByDatasetName(string datasetName);
    bool PropertyExists(string datasetName, string propertyName);
    IEnumerable<string> ListDataset();
    bool DatasetExists(string datasetName);
    bool TryParseDataset(string dataset, out string datasetName, out string propertyName, out string alias, out IDictionary<string, object> parameters);
}