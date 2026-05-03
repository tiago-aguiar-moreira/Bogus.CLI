using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;
public class AddressDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<IAddressFakerAdapter> _addressAdapterMock;
    private readonly IAddressDatasetService _addressDatasetService;

    public AddressDatasetServiceTests()
    {
        _addressAdapterMock = new Mock<IAddressFakerAdapter>();
        _addressDatasetService = new AddressDatasetService(_addressAdapterMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Fact]
    public void GenerateCity_ShouldCallCity()
    {
        _addressAdapterMock.Setup(s => s.City()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.CITY, _parameters);
        _addressAdapterMock.Verify(v => v.City(), Times.Once());
    }

    [Fact]
    public void GenerateCityPrefix_ShouldCallCityPrefix()
    {
        _addressAdapterMock.Setup(s => s.CityPrefix()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.CITY_PREFIX, _parameters);
        _addressAdapterMock.Verify(v => v.CityPrefix(), Times.Once());
    }

    [Fact]
    public void GenerateCitySuffix_ShouldCallCitySuffix()
    {
        _addressAdapterMock.Setup(s => s.CitySuffix()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.CITY_SUFFIX, _parameters);
        _addressAdapterMock.Verify(v => v.CitySuffix(), Times.Once());
    }

    [Fact]
    public void GenerateStreetName_ShouldCallStreetName()
    {
        _addressAdapterMock.Setup(s => s.StreetName()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STREET_NAME, _parameters);
        _addressAdapterMock.Verify(v => v.StreetName(), Times.Once());
    }

    [Fact]
    public void GenerateBuildingNumber_ShouldCallBuildingNumber()
    {
        _addressAdapterMock.Setup(s => s.BuildingNumber()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.BUILDING_NUMBER, _parameters);
        _addressAdapterMock.Verify(v => v.BuildingNumber(), Times.Once());
    }

    [Fact]
    public void GenerateStreetSuffix_ShouldCallStreetSuffix()
    {
        _addressAdapterMock.Setup(s => s.StreetSuffix()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STREET_SUFFIX, _parameters);
        _addressAdapterMock.Verify(v => v.StreetSuffix(), Times.Once());
    }

    [Fact]
    public void GenerateSecondaryAddress_ShouldCallSecondaryAddress()
    {
        _addressAdapterMock.Setup(s => s.SecondaryAddress()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.SECONDARY_ADDRESS, _parameters);
        _addressAdapterMock.Verify(v => v.SecondaryAddress(), Times.Once());
    }

    [Fact]
    public void GenerateCounty_ShouldCallCounty()
    {
        _addressAdapterMock.Setup(s => s.County()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.COUNTY, _parameters);
        _addressAdapterMock.Verify(v => v.County(), Times.Once());
    }

    [Fact]
    public void GenerateCountry_ShouldCallCountry()
    {
        _addressAdapterMock.Setup(s => s.Country()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.COUNTRY, _parameters);
        _addressAdapterMock.Verify(v => v.Country(), Times.Once());
    }

    [Fact]
    public void GenerateFullAddress_ShouldCallFullAddress()
    {
        _addressAdapterMock.Setup(s => s.FullAddress()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.FULL_ADDRESS, _parameters);
        _addressAdapterMock.Verify(v => v.FullAddress(), Times.Once());
    }

    [Fact]
    public void GenerateState_ShouldCallState()
    {
        _addressAdapterMock.Setup(s => s.State()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STATE, _parameters);
        _addressAdapterMock.Verify(v => v.State(), Times.Once());
    }

    [Fact]
    public void GenerateStateAbbr_ShouldCallStateAbbr()
    {
        _addressAdapterMock.Setup(s => s.StateAbbr()).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STATE_ABBR, _parameters);
        _addressAdapterMock.Verify(v => v.StateAbbr(), Times.Once());
    }

    [Theory]
    [InlineData("##### ")]
    [InlineData("???? ##")]
    public void GenerateZipCode_WithFormat_ShouldCallZipCodeWithFormat(string format)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_FORMAT, format);
        _addressAdapterMock.Setup(s => s.ZipCode(It.IsAny<string?>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.ZIPCODE, _parameters);
        _addressAdapterMock.Verify(v => v.ZipCode(format), Times.Once());
    }

    [Fact]
    public void GenerateZipCode_WithoutFormat_ShouldCallZipCodeWithNull()
    {
        _addressAdapterMock.Setup(s => s.ZipCode(It.IsAny<string?>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.ZIPCODE, _parameters);
        _addressAdapterMock.Verify(v => v.ZipCode(null), Times.Once());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GenerateStreetAddress_WithUseFullAddress_ShouldPassFlag(bool useFullAddress)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_USEFULLADDRESS, useFullAddress);
        _addressAdapterMock.Setup(s => s.StreetAddress(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STREET_ADDRESS, _parameters);
        _addressAdapterMock.Verify(v => v.StreetAddress(useFullAddress), Times.Once());
    }

    [Fact]
    public void GenerateStreetAddress_WithoutParams_ShouldUseDefault()
    {
        _addressAdapterMock.Setup(s => s.StreetAddress(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.STREET_ADDRESS, _parameters);
        _addressAdapterMock.Verify(v => v.StreetAddress(false), Times.Once());
    }

    [Theory]
    [InlineData("alpha2")]
    [InlineData("alpha3")]
    public void GenerateCountryCode_WithFormat_ShouldPassFormat(string format)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_FORMAT, format);
        _addressAdapterMock.Setup(s => s.CountryCode(It.IsAny<string>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.COUNTRY_CODE, _parameters);
        _addressAdapterMock.Verify(v => v.CountryCode(format), Times.Once());
    }

    [Fact]
    public void GenerateCountryCode_WithoutParams_ShouldUseAlpha2()
    {
        _addressAdapterMock.Setup(s => s.CountryCode(It.IsAny<string>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.COUNTRY_CODE, _parameters);
        _addressAdapterMock.Verify(v => v.CountryCode("alpha2"), Times.Once());
    }

    [Theory]
    [InlineData(-30, 30)]
    [InlineData(0, 90)]
    public void GenerateLatitude_WithMinMax_ShouldPassValues(double min, double max)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_MIN, min.ToString());
        _parameters.AddParameter(AddressDatasetService.PARAM_MAX, max.ToString());
        _addressAdapterMock.Setup(s => s.Latitude(It.IsAny<double>(), It.IsAny<double>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.LATITUDE, _parameters);
        _addressAdapterMock.Verify(v => v.Latitude(min, max), Times.Once());
    }

    [Fact]
    public void GenerateLatitude_WithoutParams_ShouldUseDefaults()
    {
        _addressAdapterMock.Setup(s => s.Latitude(It.IsAny<double>(), It.IsAny<double>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.LATITUDE, _parameters);
        _addressAdapterMock.Verify(v => v.Latitude(-90, 90), Times.Once());
    }

    [Theory]
    [InlineData(-60, 60)]
    [InlineData(0, 180)]
    public void GenerateLongitude_WithMinMax_ShouldPassValues(double min, double max)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_MIN, min.ToString());
        _parameters.AddParameter(AddressDatasetService.PARAM_MAX, max.ToString());
        _addressAdapterMock.Setup(s => s.Longitude(It.IsAny<double>(), It.IsAny<double>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.LONGITUDE, _parameters);
        _addressAdapterMock.Verify(v => v.Longitude(min, max), Times.Once());
    }

    [Fact]
    public void GenerateLongitude_WithoutParams_ShouldUseDefaults()
    {
        _addressAdapterMock.Setup(s => s.Longitude(It.IsAny<double>(), It.IsAny<double>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.LONGITUDE, _parameters);
        _addressAdapterMock.Verify(v => v.Longitude(-180, 180), Times.Once());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GenerateDirection_WithUseAbbreviation_ShouldPassFlag(bool useAbbreviation)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_USEABBREVIATION, useAbbreviation);
        _addressAdapterMock.Setup(s => s.Direction(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.DIRECTION, _parameters);
        _addressAdapterMock.Verify(v => v.Direction(useAbbreviation), Times.Once());
    }

    [Fact]
    public void GenerateDirection_WithoutParams_ShouldUseDefault()
    {
        _addressAdapterMock.Setup(s => s.Direction(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.DIRECTION, _parameters);
        _addressAdapterMock.Verify(v => v.Direction(false), Times.Once());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GenerateCardinalDirection_WithUseAbbreviation_ShouldPassFlag(bool useAbbreviation)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_USEABBREVIATION, useAbbreviation);
        _addressAdapterMock.Setup(s => s.CardinalDirection(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.CARDINAL_DIRECTION, _parameters);
        _addressAdapterMock.Verify(v => v.CardinalDirection(useAbbreviation), Times.Once());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GenerateOrdinalDirection_WithUseAbbreviation_ShouldPassFlag(bool useAbbreviation)
    {
        _parameters.AddParameter(AddressDatasetService.PARAM_USEABBREVIATION, useAbbreviation);
        _addressAdapterMock.Setup(s => s.OrdinalDirection(It.IsAny<bool>())).Returns(string.Empty);
        _ = _addressDatasetService.Generate(AddressProperty.ORDINAL_DIRECTION, _parameters);
        _addressAdapterMock.Verify(v => v.OrdinalDirection(useAbbreviation), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void Generate_InvalidProperty_ReturnsNull(string property)
    {
        var result = _addressDatasetService.Generate(property, _parameters);
        Assert.Null(result);
    }
}
