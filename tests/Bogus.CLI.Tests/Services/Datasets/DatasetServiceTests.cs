using static global::Bogus.CLI.Core.Constants.Datasets;
using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class DatasetServiceTests
{
    private readonly DatasetService _datasetService;
    private readonly Mock<IDatasetHelper> _datasetHelperMock;
    private readonly Mock<IFakerService> _fakerServiceMock;
    private readonly Mock<IAddressDatasetService> _fakeDataAddressServiceMock;
    private readonly Mock<ICommerceDatasetService> _fakeDataCommerceServiceMock;
    private readonly Mock<ICompanyDatasetService> _fakeDataCompanyServiceMock;
    private readonly Mock<IFinanceDatasetService> _fakeDataFinanceServiceMock;
    private readonly Mock<IHackerDatasetService> _fakeDataHackerServiceMock;
    private readonly Mock<IInternetDatasetService> _fakeDataInternetServiceMock;
    private readonly Mock<ILoremDatasetService> _fakeDataLoremServiceMock;
    private readonly Mock<INameDatasetService> _fakeDataNameServiceMock;
    private readonly Mock<IPhoneDatasetService> _fakeDataPhoneServiceMock;
    private readonly Mock<IVehicleDatasetService> _fakeDataVehicleServiceMock;
    private readonly Mock<Action<List<(string Value, string Alias)>>> _onInsertMock;

    public DatasetServiceTests()
    {
        _fakerServiceMock = new Mock<IFakerService>();
        _datasetHelperMock = new Mock<IDatasetHelper>();
        _fakeDataAddressServiceMock = new Mock<IAddressDatasetService>();
        _fakeDataCommerceServiceMock = new Mock<ICommerceDatasetService>();
        _fakeDataCompanyServiceMock = new Mock<ICompanyDatasetService>();
        _fakeDataFinanceServiceMock = new Mock<IFinanceDatasetService>();
        _fakeDataHackerServiceMock = new Mock<IHackerDatasetService>();
        _fakeDataInternetServiceMock = new Mock<IInternetDatasetService>();
        _fakeDataLoremServiceMock = new Mock<ILoremDatasetService>();
        _fakeDataNameServiceMock = new Mock<INameDatasetService>();
        _fakeDataPhoneServiceMock = new Mock<IPhoneDatasetService>();
        _fakeDataVehicleServiceMock = new Mock<IVehicleDatasetService>();

        _datasetService = new DatasetService(
            _datasetHelperMock.Object,
            _fakerServiceMock.Object,
            _fakeDataAddressServiceMock.Object,
            _fakeDataCommerceServiceMock.Object,
            _fakeDataCompanyServiceMock.Object,
            _fakeDataFinanceServiceMock.Object,
            _fakeDataHackerServiceMock.Object,
            _fakeDataInternetServiceMock.Object,
            _fakeDataLoremServiceMock.Object,
            _fakeDataNameServiceMock.Object,
            _fakeDataPhoneServiceMock.Object,
            _fakeDataVehicleServiceMock.Object);

        _onInsertMock = new Mock<Action<List<(string Value, string Alias)>>>();
    }

    [Fact]
    public void ExecuteCommand_InvalidParameters_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"{LOREM}.{LoremProperty.WORD}" };
        var rowsCount = 10;

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Once());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void ExecuteCommand_InvalidCount_ShouldBeFail(int rowsCount)
    {
        // Arrange
        var datasets = new string[] { $"{LOREM}.{LoremProperty.WORD}" };

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Never());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_InvalidFormatDataset_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { "123.456" };
        var rowsCount = 10;

        var datasetName = string.Empty;
        var propertyName = string.Empty;
        var alias = string.Empty;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(false);

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Once());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_DatasetNotExists_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { "XPTO.XPTO" };
        var rowsCount = 10;

        var datasetName = string.Empty;
        var propertyName = string.Empty;
        var alias = string.Empty;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(false);

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Once());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_PropertyNotExists_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"{LOREM}.XPTO" };
        var rowsCount = 10;

        var datasetName = string.Empty;
        var propertyName = string.Empty;
        var alias = string.Empty;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(false);

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Once());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Once());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_DatasetOrPropertyUnknown_ShouldBeFail()
    {
        // Arrange
        var datasetName = "DatasetXPTO";
        var propertyName = "PropertyXPTO";
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var alias = string.Empty;
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        // Act
        Assert.Throws<Exception>(() => _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object));

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Never);

        _datasetHelperMock.Verify(v => v.TryParseDataset(
            It.IsAny<string>(),
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<string>.IsAny,
            out It.Ref<IDictionary<string, object>>.IsAny), Times.Once());

        _datasetHelperMock.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelperMock.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Once());

        _fakeDataLoremServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(CommerceProperty.PRODUCT_NAME, "product")]
    [InlineData(CommerceProperty.COLOR, "color")]
    public void ExecuteCommand_CommerceDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = COMMERCE;
        var datasets = new string[] { $"{datasetName}.{propertyName}={alias}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataCommerceServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataCommerceServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(CompanyProperty.COMPANY_NAME, "company")]
    [InlineData(CompanyProperty.CATCH_PHRASE, "slogan")]
    public void ExecuteCommand_CompanyDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = COMPANY;
        var datasets = new string[] { $"{datasetName}.{propertyName}={alias}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataCompanyServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataCompanyServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(LoremProperty.TEXT, "description")]
    [InlineData(LoremProperty.SLUG, "blog")]
    public void ExecuteCommand_LoremDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = LOREM;
        var datasets = new string[] { $"{datasetName}.{propertyName}={alias}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataLoremServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataNameServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(NameProperty.FULL_NAME, "name")]
    [InlineData(NameProperty.LAST_NAME, "surname")]
    public void ExecuteCommand_NameDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = NAME;
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataNameServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(HackerProperty.PHRASE, "techPhrase")]
    [InlineData(HackerProperty.NOUN, "techNoun")]
    public void ExecuteCommand_HackerDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = HACKER;
        var datasets = new string[] { $"{datasetName}.{propertyName}={alias}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataHackerServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataHackerServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(VehicleProperty.MANUFACTURER, "brand")]
    [InlineData(VehicleProperty.MODEL, "model")]
    public void ExecuteCommand_VehicleDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = VEHICLE;
        var datasets = new string[] { $"{datasetName}.{propertyName}={alias}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataVehicleServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataVehicleServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(PhoneProperty.NUMBER, "phoneNumber")]
    [InlineData(PhoneProperty.FORMAT, "formatPhone")]
    public void ExecuteCommand_DatasetName_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = PHONE;
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var rowsCount = 10;
        IDictionary<string, object> parameters = new Dictionary<string, object>();

        _datasetHelperMock
            .Setup(s => s.TryParseDataset(It.IsAny<string>(), out datasetName, out propertyName, out alias, out parameters))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelperMock
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataPhoneServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));


        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));
    }
}