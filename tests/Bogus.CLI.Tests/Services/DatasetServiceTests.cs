using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services;
using Bogus.CLI.Core.Services.Interface;
using Moq;
using System.Collections.Generic;

namespace Bogus.CLI.Tests.Services;
public class DatasetServiceTests
{
    private readonly DatasetService _datasetService;
    private readonly Mock<IDatasetHelper> _datasetHelperMock;
    private readonly Mock<IFakerService> _fakerServiceMock;
    private readonly Mock<IParserDatasetLoremService> _fakeDataLoremServiceMock;
    private readonly Mock<IParserDatasetNameService> _fakeDataNameServiceMock;
    private readonly Mock<IParserDatasetPhoneService> _fakeDataPhoneServiceMock;
    private readonly Mock<Action<List<(string Value, string Alias)>>> _onInsertMock;

    public DatasetServiceTests()
    {
        _fakerServiceMock = new Mock<IFakerService>();
        _datasetHelperMock = new Mock<IDatasetHelper>();
        _fakeDataLoremServiceMock = new Mock<IParserDatasetLoremService>();
        _fakeDataNameServiceMock = new Mock<IParserDatasetNameService>();
        _fakeDataPhoneServiceMock = new Mock<IParserDatasetPhoneService>();

        _datasetService = new DatasetService(
            _datasetHelperMock.Object,
            _fakerServiceMock.Object,
            _fakeDataLoremServiceMock.Object,
            _fakeDataNameServiceMock.Object,
            _fakeDataPhoneServiceMock.Object);

        _onInsertMock = new Mock<Action<List<(string Value, string Alias)>>>();
    }

    #region Tests Should Be Fail

    [Fact]
    public void ExecuteCommand_InvalidParameters_ShouldBeFail()
    {
        // Arrange
        var datasets = new string[] { $"{Datasets.LOREM}.{LoremProperty.WORD}" };
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
        var datasets = new string[] { $"{Datasets.LOREM}.{LoremProperty.WORD}" };

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
        var datasets = new string[] { $"{Datasets.LOREM}.XPTO" };
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

    #endregion

    #region Tests Should Be Ok

    [Theory]
    [InlineData(LoremProperty.TEXT, "description")]
    [InlineData(LoremProperty.SLUG, "blog")]
    public void ExecuteCommand_LoremDataset_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = Datasets.LOREM;
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
        var datasetName = Datasets.NAME;
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
    [InlineData(PhoneProperty.NUMBER, "phoneNumber")]
    [InlineData(PhoneProperty.FORMAT, "formatPhone")]
    public void ExecuteCommand_DatasetName_ShouldBeOk(string propertyName, string alias)
    {
        // Arrange
        var datasetName = Datasets.PHONE;
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

    #endregion
}