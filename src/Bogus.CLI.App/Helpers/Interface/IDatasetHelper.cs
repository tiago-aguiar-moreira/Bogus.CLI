namespace Bogus.CLI.App.Helpers.Interface;
public interface IDatasetHelper
{
    IEnumerable<string> ListPropertiesByDatasetName(string datasetName);
    bool PropertyExists(string datasetName, string propertyName);
    IEnumerable<string> ListDataset();
    bool DatasetExists(string datasetName);
    bool TryParseDatasetAndProperty(string dataset, out string datasetName, out string propertyName);
    bool TryParseParameters(string? parameters, out Dictionary<string, object> parsedParameters);
}