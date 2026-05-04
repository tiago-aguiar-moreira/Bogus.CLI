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
    private readonly Mock<IDateDatasetService> _fakeDataDateServiceMock;
    private readonly Mock<IDatabaseDatasetService> _fakeDataDatabaseServiceMock;
    private readonly Mock<IFinanceDatasetService> _fakeDataFinanceServiceMock;
    private readonly Mock<IHackerDatasetService> _fakeDataHackerServiceMock;
    private readonly Mock<IImagesDatasetService> _fakeDataImagesServiceMock;
    private readonly Mock<IInternetDatasetService> _fakeDataInternetServiceMock;
    private readonly Mock<ILoremDatasetService> _fakeDataLoremServiceMock;
    private readonly Mock<INameDatasetService> _fakeDataNameServiceMock;
    private readonly Mock<IPhoneDatasetService> _fakeDataPhoneServiceMock;
    private readonly Mock<IRantDatasetService> _fakeDataRantServiceMock;
    private readonly Mock<IRandomDatasetService> _fakeDataRandomServiceMock;
    private readonly Mock<ISystemDatasetService> _fakeDataSystemServiceMock;
    private readonly Mock<IVehicleDatasetService> _fakeDataVehicleServiceMock;
    private readonly Mock<Action<List<(string Value, string Alias)>>> _onInsertMock;

    public DatasetServiceTests()
    {
        _fakerServiceMock = new Mock<IFakerService>();
        _datasetHelperMock = new Mock<IDatasetHelper>();
        _fakeDataAddressServiceMock = new Mock<IAddressDatasetService>();
        _fakeDataCommerceServiceMock = new Mock<ICommerceDatasetService>();
        _fakeDataCompanyServiceMock = new Mock<ICompanyDatasetService>();
        _fakeDataDateServiceMock = new Mock<IDateDatasetService>();
        _fakeDataDatabaseServiceMock = new Mock<IDatabaseDatasetService>();
        _fakeDataFinanceServiceMock = new Mock<IFinanceDatasetService>();
        _fakeDataHackerServiceMock = new Mock<IHackerDatasetService>();
        _fakeDataImagesServiceMock = new Mock<IImagesDatasetService>();
        _fakeDataInternetServiceMock = new Mock<IInternetDatasetService>();
        _fakeDataLoremServiceMock = new Mock<ILoremDatasetService>();
        _fakeDataNameServiceMock = new Mock<INameDatasetService>();
        _fakeDataPhoneServiceMock = new Mock<IPhoneDatasetService>();
        _fakeDataRantServiceMock = new Mock<IRantDatasetService>();
        _fakeDataRandomServiceMock = new Mock<IRandomDatasetService>();
        _fakeDataSystemServiceMock = new Mock<ISystemDatasetService>();
        _fakeDataVehicleServiceMock = new Mock<IVehicleDatasetService>();

        _datasetService = new DatasetService(
            _datasetHelperMock.Object,
            _fakerServiceMock.Object,
            _fakeDataAddressServiceMock.Object,
            _fakeDataCommerceServiceMock.Object,
            _fakeDataCompanyServiceMock.Object,
            _fakeDataDateServiceMock.Object,
            _fakeDataDatabaseServiceMock.Object,
            _fakeDataFinanceServiceMock.Object,
            _fakeDataHackerServiceMock.Object,
            _fakeDataImagesServiceMock.Object,
            _fakeDataInternetServiceMock.Object,
            _fakeDataLoremServiceMock.Object,
            _fakeDataNameServiceMock.Object,
            _fakeDataPhoneServiceMock.Object,
            _fakeDataRantServiceMock.Object,
            _fakeDataRandomServiceMock.Object,
            _fakeDataSystemServiceMock.Object,
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
    [InlineData(DateProperty.PAST, "pastDate")]
    [InlineData(DateProperty.MONTH, "month")]
    public void ExecuteCommand_DateDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = DATE;
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

        _fakeDataDateServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataDateServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(DatabaseProperty.COLUMN, "col")]
    [InlineData(DatabaseProperty.ENGINE, "engine")]
    public void ExecuteCommand_DatabaseDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = DATABASE;
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

        _fakeDataDatabaseServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataDatabaseServiceMock
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
    [InlineData(ImagesProperty.PICSUM_URL, "photo")]
    [InlineData(ImagesProperty.PLACEHOLDER_URL, "img")]
    public void ExecuteCommand_ImagesDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = IMAGES;
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

        _fakeDataImagesServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("https://picsum.photos/640/480");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataImagesServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

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
    [InlineData(SystemProperty.FILE_NAME, "file")]
    [InlineData(SystemProperty.SEMVER, "version")]
    public void ExecuteCommand_SystemDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = SYSTEM;
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

        _fakeDataSystemServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataSystemServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(RantProperty.REVIEW, "review")]
    [InlineData(RantProperty.REVIEWS, "reviews")]
    public void ExecuteCommand_RantDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = RANT;
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

        _fakeDataRantServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataRantServiceMock
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

    [Theory]
    [InlineData(RandomProperty.WORD, "randomWord")]
    [InlineData(RandomProperty.GUID, "randomGuid")]
    public void ExecuteCommand_RandomDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = RANDOM;
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

        _fakeDataRandomServiceMock
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        _datasetService.ExecuteCommand(datasets, rowsCount, null, _onInsertMock.Object);

        // Assert
        _onInsertMock.Verify(v => v.Invoke(It.IsAny<List<(string Value, string Alias)>>()), Times.Exactly(rowsCount));

        _fakeDataLoremServiceMock
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataRandomServiceMock
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));
    }
}