using CONST = Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers.Interface;
using System.Text.RegularExpressions;
using Bogus.CLI.App.Extensions;

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

    public bool TryParseDataset(string dataset, out string datasetName, out string propertyName, out string alias)
    {
        datasetName = string.Empty;
        propertyName = string.Empty;
        alias = string.Empty;

        // Validate if the string contains the dot (.) and equal sign (=)
        var dotIndex = dataset.IndexOf('.');
        var equalsIndex = dataset.IndexOf('=');

        // Check if the dot and equal sign are present in the correct order
        if (dotIndex == -1 || dataset.CountCharacter('.') > 1 || (equalsIndex != -1 && equalsIndex < dotIndex))
            return false;

        // Extract datasetName and propertyName
        datasetName = dataset[..dotIndex];
        datasetName = datasetName.Trim();

        if (string.IsNullOrEmpty(datasetName) || datasetName.Any(char.IsNumber))
        {
            datasetName = string.Empty;
            return false;
        }

        propertyName = dataset[(dotIndex + 1)..(equalsIndex == -1 ? dataset.Length : equalsIndex)];
        propertyName = propertyName.Trim();

        if(string.IsNullOrEmpty(propertyName) || propertyName.Any(char.IsNumber))
        {
            datasetName = string.Empty;
            propertyName = string.Empty;
            return false;
        }

        // Check if there is an alias, which should come after the equal sign
        if (equalsIndex != -1)
        {
            alias = dataset[(equalsIndex + 1)..];
            if (string.IsNullOrEmpty(alias))
            {
                datasetName = string.Empty;
                propertyName = string.Empty;
                return false;
            }
        }

        return true;
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
                parsedParameters.AddParameter(keyValue[0], keyValue[1]);
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
