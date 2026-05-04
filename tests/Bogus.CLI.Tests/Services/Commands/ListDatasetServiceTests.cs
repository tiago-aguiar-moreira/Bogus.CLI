using static global::Bogus.CLI.Core.Constants.Datasets;
using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Helpers;
using Bogus.CLI.Core.Services.Commands;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Tests.Services.Commands;
public class ListDatasetServiceTests
{
    private readonly IListDatasetService _listDatasetService;

    public ListDatasetServiceTests()
    {
        _listDatasetService = new ListDatasetService(new DatasetHelper());
    }

    public static IEnumerable<object[]> DatasetPropertiesData =>
    [
        [ADDRESS, new[]
        {
            AddressProperty.BUILDING_NUMBER, AddressProperty.CARDINAL_DIRECTION, AddressProperty.CITY,
            AddressProperty.CITY_PREFIX, AddressProperty.CITY_SUFFIX, AddressProperty.COUNTRY,
            AddressProperty.COUNTRY_CODE, AddressProperty.COUNTY, AddressProperty.DIRECTION,
            AddressProperty.FULL_ADDRESS, AddressProperty.LATITUDE, AddressProperty.LONGITUDE,
            AddressProperty.ORDINAL_DIRECTION, AddressProperty.SECONDARY_ADDRESS, AddressProperty.STATE,
            AddressProperty.STATE_ABBR, AddressProperty.STREET_ADDRESS, AddressProperty.STREET_NAME,
            AddressProperty.STREET_SUFFIX, AddressProperty.ZIPCODE
        }],
        [COMMERCE, new[]
        {
            CommerceProperty.CATEGORIES, CommerceProperty.COLOR, CommerceProperty.DEPARTMENT,
            CommerceProperty.EAN13, CommerceProperty.EAN8, CommerceProperty.PRICE,
            CommerceProperty.PRODUCT, CommerceProperty.PRODUCT_ADJECTIVE, CommerceProperty.PRODUCT_DESCRIPTION,
            CommerceProperty.PRODUCT_MATERIAL, CommerceProperty.PRODUCT_NAME
        }],
        [COMPANY, new[]
        {
            CompanyProperty.BS, CompanyProperty.CATCH_PHRASE,
            CompanyProperty.COMPANY_NAME, CompanyProperty.COMPANY_SUFFIX
        }],
        [DATABASE, new[]
        {
            DatabaseProperty.COLLATION, DatabaseProperty.COLUMN,
            DatabaseProperty.ENGINE, DatabaseProperty.TYPE
        }],
        [DATE, new[]
        {
            DateProperty.BETWEEN, DateProperty.BETWEEN_OFFSET, DateProperty.FUTURE, DateProperty.FUTURE_OFFSET,
            DateProperty.MONTH, DateProperty.PAST, DateProperty.PAST_OFFSET, DateProperty.RECENT,
            DateProperty.RECENT_OFFSET, DateProperty.SOON, DateProperty.SOON_OFFSET, DateProperty.TIMESPAN,
            DateProperty.TIMEZONE_STRING, DateProperty.WEEKDAY
        }],
        [FINANCE, new[]
        {
            FinanceProperty.ACCOUNT, FinanceProperty.ACCOUNT_NAME, FinanceProperty.AMOUNT,
            FinanceProperty.BIC, FinanceProperty.BITCOIN_ADDRESS, FinanceProperty.CREDIT_CARD_CVV,
            FinanceProperty.CREDIT_CARD_NUMBER, FinanceProperty.CURRENCY, FinanceProperty.ETHEREUM_ADDRESS,
            FinanceProperty.IBAN, FinanceProperty.ROUTING_NUMBER, FinanceProperty.TRANSACTION_TYPE
        }],
        [HACKER, new[]
        {
            HackerProperty.ABBREVIATION, HackerProperty.ADJECTIVE, HackerProperty.ING_VERB,
            HackerProperty.NOUN, HackerProperty.PHRASE, HackerProperty.VERB
        }],
        [IMAGES, new[]
        {
            ImagesProperty.DATA_URI, ImagesProperty.LOREM_FLICKR_URL, ImagesProperty.PICSUM_URL,
            ImagesProperty.PLACEHOLDER_URL, ImagesProperty.PLACE_IMG_URL
        }],
        [INTERNET, new[]
        {
            InternetProperty.AVATAR, InternetProperty.COLOR, InternetProperty.DOMAIN_NAME,
            InternetProperty.DOMAIN_SUFFIX, InternetProperty.DOMAIN_WORD, InternetProperty.EMAIL,
            InternetProperty.EXAMPLE_EMAIL, InternetProperty.IP, InternetProperty.IP_ADDRESS,
            InternetProperty.IP_ENDPOINT, InternetProperty.IPV6, InternetProperty.IPV6_ADDRESS,
            InternetProperty.IPV6_ENDPOINT, InternetProperty.MAC, InternetProperty.PASSWORD,
            InternetProperty.PORT, InternetProperty.PROTOCOL, InternetProperty.URL,
            InternetProperty.URL_ROOTED_PATH, InternetProperty.URL_WITH_PATH,
            InternetProperty.USER_AGENT, InternetProperty.USERNAME, InternetProperty.USERNAME_UNICODE
        }],
        [LOREM, new[]
        {
            LoremProperty.LETTER, LoremProperty.LINES, LoremProperty.PARAGRAPH, LoremProperty.PARAGRAPHS,
            LoremProperty.SENTENCE, LoremProperty.SENTENCES, LoremProperty.SLUG, LoremProperty.TEXT,
            LoremProperty.WORD, LoremProperty.WORDS
        }],
        [NAME, new[]
        {
            NameProperty.FIND_NAME, NameProperty.FIRST_NAME, NameProperty.FULL_NAME, NameProperty.JOB_AREA,
            NameProperty.JOB_DESCRIPTOR, NameProperty.JOB_TITLE, NameProperty.JOB_TYPE,
            NameProperty.LAST_NAME, NameProperty.PREFIX, NameProperty.SUFFIX
        }],
        [PHONE, new[]
        {
            PhoneProperty.FORMAT, PhoneProperty.NUMBER
        }],
        [RANDOM, new[]
        {
            RandomProperty.ALPHANUMERIC, RandomProperty.BOOL, RandomProperty.CHAR, RandomProperty.DECIMAL,
            RandomProperty.DOUBLE, RandomProperty.EVEN, RandomProperty.FLOAT, RandomProperty.GUID,
            RandomProperty.HASH, RandomProperty.HEXADECIMAL, RandomProperty.INT, RandomProperty.LONG,
            RandomProperty.NUMBER, RandomProperty.ODD, RandomProperty.RANDOM_LOCALE, RandomProperty.REPLACE,
            RandomProperty.REPLACE_NUMBERS, RandomProperty.WORD, RandomProperty.WORDS
        }],
        [RANT, new[]
        {
            RantProperty.REVIEW, RantProperty.REVIEWS
        }],
        [SYSTEM, new[]
        {
            SystemProperty.ANDROID_ID, SystemProperty.APPLE_PUSH_TOKEN, SystemProperty.BLACKBERRY_PIN,
            SystemProperty.COMMON_FILE_EXT, SystemProperty.COMMON_FILE_NAME, SystemProperty.COMMON_FILE_TYPE,
            SystemProperty.DIRECTORY_PATH, SystemProperty.EXCEPTION, SystemProperty.FILE_EXT,
            SystemProperty.FILE_NAME, SystemProperty.FILE_PATH, SystemProperty.FILE_TYPE,
            SystemProperty.MIME_TYPE, SystemProperty.SEMVER, SystemProperty.VERSION
        }],
        [VEHICLE, new[]
        {
            VehicleProperty.FUEL, VehicleProperty.MANUFACTURER,
            VehicleProperty.MODEL, VehicleProperty.TYPE, VehicleProperty.VIN
        }],
    ];

    [Theory]
    [MemberData(nameof(DatasetPropertiesData))]
    public void ExecuteCommand_WithDatasetName_ShouldReturnSortedProperties(string datasetName, string[] expectedProperties)
    {
        var result = _listDatasetService.ExecuteCommand(datasetName);

        Assert.Equal(expectedProperties.Length, result.Count);
        Assert.Equal(expectedProperties, result);
    }

    [Fact]
    public void ExecuteCommand_WithUnknownDatasetName_ShouldReturnEmptyList()
    {
        var result = _listDatasetService.ExecuteCommand("unknown");

        Assert.Empty(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ExecuteCommand_WithoutDatasetName_ShouldReturnAllDatasets(string? datasetName)
    {
        List<string> expectedDatasets =
        [
            ADDRESS, COMMERCE, COMPANY, DATABASE, DATE, FINANCE,
            HACKER, IMAGES, INTERNET, LOREM, NAME, PHONE,
            RANDOM, RANT, SYSTEM, VEHICLE
        ];

        var result = _listDatasetService.ExecuteCommand(datasetName);

        Assert.Equal(expectedDatasets.Count, result.Count);
        Assert.Equal(expectedDatasets.Order(), result);
    }
}
