using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers.Interface;
using Bogus.CLI.App.Services;
using Bogus.CLI.App.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services;
public class DatasetServiceTests
{
    private readonly DatasetService _datasetService;
    private readonly Mock<IDatasetHelper> _datasetHelper;
    private readonly Mock<IFakerService> _fakerService;
    private readonly Mock<IFakeDataLoremService> _fakeDataLoremService;
    private readonly Mock<IFakeDataNameService> _fakeDataNameService;
    private readonly Mock<IFakeDataPhoneService> _fakeDataPhoneService;

    public DatasetServiceTests()
    {
        _fakerService = new Mock<IFakerService>();
        _datasetHelper = new Mock<IDatasetHelper>();
        _fakeDataLoremService = new Mock<IFakeDataLoremService>();
        _fakeDataNameService = new Mock<IFakeDataNameService>();
        _fakeDataPhoneService = new Mock<IFakeDataPhoneService>();

        _datasetService = new DatasetService(
            _datasetHelper.Object,
            _fakerService.Object,
            _fakeDataLoremService.Object,
            _fakeDataNameService.Object,
            _fakeDataPhoneService.Object);
    }

    #region Tests Should Be Fail

    [Fact]
    public void ExecuteCommand_InvalidParameters_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"{Datasets.LOREM}.{LoremProperty.WORD}" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(false);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Never());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void ExecuteCommand_InvalidCount_ShouldBeFail(int rowsCount)
    {
        // Arrange
        var datasets = new string[] { $"{Datasets.LOREM}.{LoremProperty.WORD}" };
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Never());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_InvalidFormatDataset_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { "123.456" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        var datasetName = string.Empty;
        var propertyName = string.Empty;

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(false);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Never());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_DatasetNotExists_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { "XPTO.XPTO" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        var datasetName = string.Empty;
        var propertyName = string.Empty;

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(false);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_PropertyNotExists_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"{Datasets.LOREM}.XPTO" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        var datasetName = string.Empty;
        var propertyName = string.Empty;

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(false);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Once());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_DatasetOrPropertyUnknown_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"XPTO.XPTO" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        var datasetName = string.Empty;
        var propertyName = string.Empty;

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(resultActual);
        Assert.NotEmpty(message);

        _datasetHelper.Verify(v => v.TryParseParameters(
            It.IsAny<string>(), out It.Ref<Dictionary<string, object>>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.TryParseDatasetAndProperty(
            It.IsAny<string>(), out It.Ref<string>.IsAny, out It.Ref<string>.IsAny), Times.Once());

        _datasetHelper.Verify(v => v.DatasetExists(
            It.IsAny<string>()), Times.Once());

        _datasetHelper.Verify(v => v.PropertyExists(
            It.IsAny<string>(), It.IsAny<string>()), Times.Once());

        _fakeDataLoremService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService.Verify(v => v.Generate(
            It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    #endregion

    #region Tests Should Be Ok

    [Theory]
    [InlineData(LoremProperty.SLUG)]
    [InlineData(LoremProperty.WORD)]
    public void ExecuteCommand_LoremDataset_ShouldBeOk(string propertyName)
    {
        // Arrange
        var datasetName = Datasets.LOREM;
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataLoremService
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.NotEmpty(resultActual);
        Assert.Empty(message);

        _fakeDataLoremService
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataNameService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(NameProperty.FULL_NAME)]
    [InlineData(NameProperty.SUFFIX)]
    public void ExecuteCommand_NameDataset_ShouldBeOk(string propertyName)
    {
        // Arrange
        var datasetName = Datasets.NAME;
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataNameService
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(message);

        _fakeDataLoremService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));

        _fakeDataPhoneService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);
    }

    [Theory]
    [InlineData(PhoneProperty.NUMBER)]
    [InlineData(PhoneProperty.FORMAT)]
    public void ExecuteCommand_DatasetName_ShouldBeOk(string propertyName)
    {
        // Arrange
        var datasetName = Datasets.PHONE;
        var datasets = new string[] { $"{datasetName}.{propertyName}" };
        var rowsCount = 10;
        var parsedParameters = new Dictionary<string, object>();

        _datasetHelper
            .Setup(s => s.TryParseParameters(It.IsAny<string>(), out parsedParameters))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.TryParseDatasetAndProperty(It.IsAny<string>(), out datasetName, out propertyName))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.DatasetExists(It.IsAny<string>()))
            .Returns(true);

        _datasetHelper
            .Setup(s => s.PropertyExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _fakeDataPhoneService
            .Setup(s => s.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
            .Returns("abcde");

        // Act
        var resultActual = _datasetService
            .ExecuteCommand(datasets, rowsCount, null, null, out var message);

        // Assert
        Assert.Empty(message);

        _fakeDataLoremService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataNameService
            .Verify(v => v.Generate(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()), Times.Never);

        _fakeDataPhoneService
            .Verify(v => v.Generate(propertyName, new Dictionary<string, object>()), Times.Exactly(rowsCount));
    }

    #endregion
}