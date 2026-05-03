using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class AddressDatasetService(IAddressFakerAdapter addressAdapter) : IAddressDatasetService
{
    public const string PARAM_FORMAT = "format";
    public const string PARAM_USEFULLADDRESS = "useFullAddress";
    public const string PARAM_USEABBREVIATION = "useAbbreviation";
    public const string PARAM_MIN = "min";
    public const string PARAM_MAX = "max";

    private readonly IAddressFakerAdapter _addressAdapter = addressAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        AddressProperty.ZIPCODE => GenerateZipCode(parameters),
        AddressProperty.CITY => _addressAdapter.City(),
        AddressProperty.STREET_ADDRESS => GenerateStreetAddress(parameters),
        AddressProperty.CITY_PREFIX => _addressAdapter.CityPrefix(),
        AddressProperty.CITY_SUFFIX => _addressAdapter.CitySuffix(),
        AddressProperty.STREET_NAME => _addressAdapter.StreetName(),
        AddressProperty.BUILDING_NUMBER => _addressAdapter.BuildingNumber(),
        AddressProperty.STREET_SUFFIX => _addressAdapter.StreetSuffix(),
        AddressProperty.SECONDARY_ADDRESS => _addressAdapter.SecondaryAddress(),
        AddressProperty.COUNTY => _addressAdapter.County(),
        AddressProperty.COUNTRY => _addressAdapter.Country(),
        AddressProperty.FULL_ADDRESS => _addressAdapter.FullAddress(),
        AddressProperty.COUNTRY_CODE => GenerateCountryCode(parameters),
        AddressProperty.STATE => _addressAdapter.State(),
        AddressProperty.STATE_ABBR => _addressAdapter.StateAbbr(),
        AddressProperty.LATITUDE => GenerateLatitude(parameters),
        AddressProperty.LONGITUDE => GenerateLongitude(parameters),
        AddressProperty.DIRECTION => GenerateDirection(parameters),
        AddressProperty.CARDINAL_DIRECTION => GenerateCardinalDirection(parameters),
        AddressProperty.ORDINAL_DIRECTION => GenerateOrdinalDirection(parameters),
        _ => null
    };

    private string GenerateZipCode(IDictionary<string, object> parameters)
    {
        var format = parameters.ConvertToString(PARAM_FORMAT, null!);
        return _addressAdapter.ZipCode(string.IsNullOrEmpty(format) ? null : format);
    }

    private string GenerateStreetAddress(IDictionary<string, object> parameters)
    {
        var useFullAddress = parameters.ConvertToBool(PARAM_USEFULLADDRESS, false);
        return _addressAdapter.StreetAddress(useFullAddress);
    }

    private string GenerateCountryCode(IDictionary<string, object> parameters)
    {
        var format = parameters.ConvertToString(PARAM_FORMAT, "alpha2");
        return _addressAdapter.CountryCode(format);
    }

    private string GenerateLatitude(IDictionary<string, object> parameters)
    {
        var min = parameters.ConvertToDouble(PARAM_MIN, -90);
        var max = parameters.ConvertToDouble(PARAM_MAX, 90);
        return _addressAdapter.Latitude(min, max);
    }

    private string GenerateLongitude(IDictionary<string, object> parameters)
    {
        var min = parameters.ConvertToDouble(PARAM_MIN, -180);
        var max = parameters.ConvertToDouble(PARAM_MAX, 180);
        return _addressAdapter.Longitude(min, max);
    }

    private string GenerateDirection(IDictionary<string, object> parameters)
    {
        var useAbbreviation = parameters.ConvertToBool(PARAM_USEABBREVIATION, false);
        return _addressAdapter.Direction(useAbbreviation);
    }

    private string GenerateCardinalDirection(IDictionary<string, object> parameters)
    {
        var useAbbreviation = parameters.ConvertToBool(PARAM_USEABBREVIATION, false);
        return _addressAdapter.CardinalDirection(useAbbreviation);
    }

    private string GenerateOrdinalDirection(IDictionary<string, object> parameters)
    {
        var useAbbreviation = parameters.ConvertToBool(PARAM_USEABBREVIATION, false);
        return _addressAdapter.OrdinalDirection(useAbbreviation);
    }
}
