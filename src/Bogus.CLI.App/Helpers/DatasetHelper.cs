using CONST = Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers.Interface;
using System.Text.RegularExpressions;

namespace Bogus.CLI.App.Helpers;
public class DatasetHelper : IDatasetHelper
{
    private readonly IDictionary<string, IList<string>> _datasets = new Dictionary<string, IList<string>>()
    {
        {
            CONST.Datasets.LOREM, new List<string>
            {
                LoremProperty.WORD,
                LoremProperty.WORDS,
                LoremProperty.LETTER,
                LoremProperty.SENTENCE,
                LoremProperty.SENTENCES,
                LoremProperty.PARAGRAPH,
                LoremProperty.PARAGRAPHS,
                LoremProperty.TEXT,
                LoremProperty.LINES,
                LoremProperty.SLUG
            }
        },
        {
            CONST.Datasets.NAME, new List<string>
            {
                NameProperty.FIRST_NAME,
                NameProperty.LAST_NAME,
                NameProperty.FULL_NAME,
                NameProperty.PREFIX,
                NameProperty.SUFFIX,
                NameProperty.FIND_NAME,
                NameProperty.JOB_TITLE,
                NameProperty.JOB_DESCRIPTOR,
                NameProperty.JOB_AREA,
                NameProperty.JOB_TYPE
            }
        },
        {
            CONST.Datasets.PHONE, new List<string>
            {
                PhoneProperty.NUMBER,
                PhoneProperty.FORMAT
            }
        }
    };

    public bool TryParseDatasetAndProperty(
        string dataset, out string datasetName, out string propertyName)
    {
        var parts = dataset.Split('.');
        if (parts.Length == 2 &&
            parts.All(a => !string.IsNullOrEmpty(a.Trim()) && a.All(char.IsLetter)))
        {
            datasetName = parts[0].ToLower().Trim();
            propertyName = parts[1].ToLower().Trim();
            return true;
        }

        datasetName = string.Empty;
        propertyName = string.Empty;
        return false;
    }

    public bool TryParseParameters(
        string? parameters, out Dictionary<string, object> parsedParameters)
    {
        parsedParameters = [];

        if (string.IsNullOrWhiteSpace(parameters))
            return true;

        parameters = parameters.Trim();

        var regex = new Regex(@"^[a-zA-Z]+=[^=]+$");
        var splitParams = parameters.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var param in splitParams)
        {
            if (!regex.IsMatch(param))
                return false;

            var keyValue = param.Split('=');
            if (keyValue.Length == 2)
                parsedParameters[keyValue[0].ToLower()] = keyValue[1];
        }

        return true;
    }

    public IEnumerable<string> ListPropertiesByDatasetName(string datasetName)
        => _datasets.TryGetValue(datasetName.ToLower(), out var properties)
            ? properties.Order()
            : [];

    public bool PropertyExists(string datasetName, string propertyName)
    {
        if (!_datasets.TryGetValue(datasetName.ToLower(), out var properties))
            return false;

        return properties
            .Any(f => propertyName.Equals(f, StringComparison.InvariantCultureIgnoreCase));
    }

    public IEnumerable<string> ListDataset() => _datasets.Select(s => s.Key).Order();

    public bool DatasetExists(string datasetName)
        => _datasets.Any(f => datasetName.Equals(f.Key, StringComparison.InvariantCultureIgnoreCase));
}
