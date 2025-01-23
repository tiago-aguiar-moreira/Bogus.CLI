using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers.Interface;
using Bogus.CLI.App.Services;
using Bogus.CLI.App.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services;
public class ListDatasetServiceTests
{
    private readonly IListDatasetService _listDatasetService;
    private readonly Mock<IDatasetHelper> _datasetHelper;

    public ListDatasetServiceTests()
    {
        _datasetHelper = new Mock<IDatasetHelper>();
        _listDatasetService = new ListDatasetService(_datasetHelper.Object);
    }

    [Fact]
    public void ListDataset_WithDataset_ReturnsPropertyList()
    {
        // Arrange
        var expectedList = new List<string>()
        {
            LoremProperty.WORDS,
            LoremProperty.TEXT,
            LoremProperty.SLUG,
            LoremProperty.LETTER,
            LoremProperty.SENTENCE
        };

        _datasetHelper
            .Setup(x => x.ListPropertiesByDatasetName(It.IsAny<string>()))
            .Returns(expectedList);

        // Act
        var actualList = _listDatasetService
            .ExecuteCommand(Datasets.LOREM);

        // Assert
        Assert.Equal(expectedList.Count, actualList.Count);
        _datasetHelper.Verify(v => v.ListDataset(), Times.Never);
        _datasetHelper.Verify(v => v.ListPropertiesByDatasetName(It.IsAny<string>()), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ListDataset_WithoutDataset_ReturnsDatasetList(string? datasetName)
    {
        // Arrange
        var expectedList = new List<string>()
        {
            Datasets.LOREM,
            Datasets.NAME,
            Datasets.PHONE
        };

        _datasetHelper
            .Setup(x => x.ListDataset())
            .Returns(expectedList);

        // Act
        var actualList = _listDatasetService
            .ExecuteCommand(datasetName);

        // Assert
        Assert.Equal(expectedList.Count, actualList.Count);
        _datasetHelper.Verify(v => v.ListDataset(), Times.Once);
        _datasetHelper.Verify(v => v.ListPropertiesByDatasetName(It.IsAny<string>()), Times.Never);
    }
}