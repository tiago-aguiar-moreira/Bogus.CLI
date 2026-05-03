using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Helpers.Interface;
using CONST = Bogus.CLI.Core.Constants;

namespace Bogus.CLI.Core.Helpers;
public class DatasetHelper : IDatasetHelper
{
    private readonly IDictionary<string, IList<string>> _datasets = new Dictionary<string, IList<string>>()
    {
        {
            CONST.Datasets.ADDRESS, new List<string>
            {
                AddressProperty.ZIPCODE,
                AddressProperty.CITY,
                AddressProperty.STREET_ADDRESS,
                AddressProperty.CITY_PREFIX,
                AddressProperty.CITY_SUFFIX,
                AddressProperty.STREET_NAME,
                AddressProperty.BUILDING_NUMBER,
                AddressProperty.STREET_SUFFIX,
                AddressProperty.SECONDARY_ADDRESS,
                AddressProperty.COUNTY,
                AddressProperty.COUNTRY,
                AddressProperty.FULL_ADDRESS,
                AddressProperty.COUNTRY_CODE,
                AddressProperty.STATE,
                AddressProperty.STATE_ABBR,
                AddressProperty.LATITUDE,
                AddressProperty.LONGITUDE,
                AddressProperty.DIRECTION,
                AddressProperty.CARDINAL_DIRECTION,
                AddressProperty.ORDINAL_DIRECTION
            }
        },
        {
            CONST.Datasets.COMMERCE, new List<string>
            {
                CommerceProperty.DEPARTMENT,
                CommerceProperty.PRICE,
                CommerceProperty.CATEGORIES,
                CommerceProperty.PRODUCT_NAME,
                CommerceProperty.COLOR,
                CommerceProperty.PRODUCT,
                CommerceProperty.PRODUCT_ADJECTIVE,
                CommerceProperty.PRODUCT_MATERIAL,
                CommerceProperty.PRODUCT_DESCRIPTION,
                CommerceProperty.EAN8,
                CommerceProperty.EAN13
            }
        },
        {
            CONST.Datasets.COMPANY, new List<string>
            {
                CompanyProperty.COMPANY_SUFFIX,
                CompanyProperty.COMPANY_NAME,
                CompanyProperty.CATCH_PHRASE,
                CompanyProperty.BS
            }
        },
        {
            CONST.Datasets.FINANCE, new List<string>
            {
                FinanceProperty.ACCOUNT,
                FinanceProperty.ACCOUNT_NAME,
                FinanceProperty.AMOUNT,
                FinanceProperty.TRANSACTION_TYPE,
                FinanceProperty.CURRENCY,
                FinanceProperty.CREDIT_CARD_NUMBER,
                FinanceProperty.CREDIT_CARD_CVV,
                FinanceProperty.BITCOIN_ADDRESS,
                FinanceProperty.ETHEREUM_ADDRESS,
                FinanceProperty.ROUTING_NUMBER,
                FinanceProperty.BIC,
                FinanceProperty.IBAN
            }
        },
        {
            CONST.Datasets.HACKER, new List<string>
            {
                HackerProperty.ABBREVIATION,
                HackerProperty.ADJECTIVE,
                HackerProperty.NOUN,
                HackerProperty.VERB,
                HackerProperty.ING_VERB,
                HackerProperty.PHRASE
            }
        },
        {
            CONST.Datasets.INTERNET, new List<string>
            {
                InternetProperty.AVATAR,
                InternetProperty.EMAIL,
                InternetProperty.EXAMPLE_EMAIL,
                InternetProperty.USERNAME,
                InternetProperty.USERNAME_UNICODE,
                InternetProperty.DOMAIN_NAME,
                InternetProperty.DOMAIN_WORD,
                InternetProperty.DOMAIN_SUFFIX,
                InternetProperty.IP,
                InternetProperty.PORT,
                InternetProperty.IP_ADDRESS,
                InternetProperty.IP_ENDPOINT,
                InternetProperty.IPV6,
                InternetProperty.IPV6_ADDRESS,
                InternetProperty.IPV6_ENDPOINT,
                InternetProperty.USER_AGENT,
                InternetProperty.MAC,
                InternetProperty.PASSWORD,
                InternetProperty.COLOR,
                InternetProperty.PROTOCOL,
                InternetProperty.URL,
                InternetProperty.URL_WITH_PATH,
                InternetProperty.URL_ROOTED_PATH
            }
        },
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
        },
        {
            CONST.Datasets.VEHICLE, new List<string>
            {
                VehicleProperty.VIN,
                VehicleProperty.MANUFACTURER,
                VehicleProperty.MODEL,
                VehicleProperty.TYPE,
                VehicleProperty.FUEL
            }
        }
    };

    public bool TryParseDataset(string dataset, out string datasetName, out string propertyName, out string alias, out IDictionary<string, object> parameters)
    {
        datasetName = string.Empty;
        propertyName = string.Empty;
        alias = string.Empty;
        parameters = new Dictionary<string, object>();

        dataset = dataset.Trim();

        var dotIndex = dataset.IndexOf('.');

        if (dotIndex == -1 || dataset.Length <= 1)
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
                var keyValue = parameter
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValue.Length != 2)
                    return false;

                var key = keyValue[0].Trim();
                var value = keyValue[1].Trim();

                if (string.IsNullOrEmpty(key) || parameters.ContainsKey(key))
                {
                    parameters.Clear();
                    return false;
                }

                parameters[key] = value;
            }
        }

        // Alias
        var aliasIndex = hasParams ? dataset.IndexOf('=', closeParenIndex + 1) : dataset.IndexOf('=');
        var hasAlias = aliasIndex > 0;

        if (hasAlias)
            alias = dataset[(aliasIndex + 1)..];

        // Dataset
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
        
        return IsValidName(datasetName) && IsValidName(propertyName);
    }

    private bool IsValidName(string name) 
        => !string.IsNullOrEmpty(name)
        && !name.All(char.IsDigit)
        && !name.Any(char.IsPunctuation);

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
