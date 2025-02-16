using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services;
public class ListDatasetServiceTests
{
    private readonly IListDatasetService _listDatasetService;
    private readonly Mock<IDatasetHelper> _datasetHelperMock;

    public ListDatasetServiceTests()
    {
        _datasetHelperMock = new Mock<IDatasetHelper>();
        _listDatasetService = new ListDatasetService(_datasetHelperMock.Object);
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

        _datasetHelperMock
            .Setup(x => x.ListPropertiesByDatasetName(It.IsAny<string>()))
            .Returns(expectedList);

        // Act
        var actualList = _listDatasetService
            .ExecuteCommand(Datasets.LOREM);

        // Assert
        Assert.Equal(expectedList.Count, actualList.Count);
        _datasetHelperMock.Verify(v => v.ListDataset(), Times.Never);
        _datasetHelperMock.Verify(v => v.ListPropertiesByDatasetName(It.IsAny<string>()), Times.Once);
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

        _datasetHelperMock
            .Setup(x => x.ListDataset())
            .Returns(expectedList);

        // Act
        var actualList = _listDatasetService
            .ExecuteCommand(datasetName);

        // Assert
        Assert.Equal(expectedList.Count, actualList.Count);
        _datasetHelperMock.Verify(v => v.ListDataset(), Times.Once);
        _datasetHelperMock.Verify(v => v.ListPropertiesByDatasetName(It.IsAny<string>()), Times.Never);
    }
}