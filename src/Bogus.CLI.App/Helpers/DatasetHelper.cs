using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers.Interface;
using CONST = Bogus.CLI.App.Constants;

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

    public bool TryParseDataset(string dataset, out string datasetName, out string propertyName, out string alias, out IDictionary<string, object> parameters)
    {
        datasetName = string.Empty;
        propertyName = string.Empty;
        alias = string.Empty;
        parameters = new Dictionary<string, object>();

        if (string.IsNullOrWhiteSpace(dataset))
            return false;

        var openParenIndex = dataset.IndexOf('(');
        var closeParenIndex = dataset.IndexOf(')');
        var hasParams = openParenIndex > 0 || closeParenIndex > 0;

        // Params
        if (hasParams)
        {
            if ((openParenIndex == -1 && closeParenIndex > 0) || (openParenIndex > 0 && closeParenIndex == -1))
                return false;

            var paramsSplited = dataset[(openParenIndex + 1)..closeParenIndex]
                .Trim()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (!paramsSplited.All(a => a.Contains('=')))
                return false;

            foreach (var parameter in paramsSplited)
            {
                var keyValue = parameter.Split('=');
                if (keyValue.Length != 2)
                    return false;

                var key = keyValue[0].Trim();
                var value = keyValue[1].Trim();

                if (string.IsNullOrEmpty(key) || parameters.ContainsKey(key))
                    return false;

                parameters[key] = value;
            }
        }

        // Alias
        var aliasIndex = hasParams ? dataset.IndexOf('=', closeParenIndex + 1) : dataset.IndexOf('=');
        var hasAlias = aliasIndex > 0;

        if (hasAlias)
            alias = dataset[(aliasIndex + 1)..];

        // Dataset
        var dotIndex = dataset.IndexOf('.');

        datasetName = dataset[..dotIndex];

        // Property Name
        if (hasParams)
        {
            propertyName = dataset[(dotIndex + 1)..openParenIndex];
        }
        else if (hasAlias)
        {
            propertyName = dataset[(dotIndex + 1)..aliasIndex];
        }
        else
        {
            propertyName = dataset[(dotIndex + 1)..];
        }

        return !string.IsNullOrEmpty(datasetName) || !datasetName.All(char.IsDigit) 
            || !string.IsNullOrEmpty(propertyName) || !propertyName.All(char.IsDigit);
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
