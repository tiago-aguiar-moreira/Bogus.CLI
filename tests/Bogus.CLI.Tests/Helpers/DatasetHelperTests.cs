using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers;
using Bogus.CLI.Tests.Helpers.TestData;

namespace Bogus.CLI.Tests.Helpers;

public class DatasetHelperTest
{
    private readonly DatasetHelper _datasetHelper = new();

    #region TryParseDataset

    [Theory]
    [MemberData(nameof(DatasetHelperTestDataProvider.ValidFormat), MemberType = typeof(DatasetHelperTestDataProvider))]
    public void TryParseDataset_ValidFormat_ShouldBeOk(
        string dataset,
        string expectedDatasetName,
        string expectedPropertyName,
        string expectedAlias,
        Dictionary<string, object> expectedParameters)
    {
        // Act
        var actualResult = _datasetHelper.TryParseDataset(
            dataset,
            out var actualDatasetName,
            out var actualPropertyNameActual,
            out var actualAlias,
            out var actualParameters);

        // Assert
        Assert.True(actualResult);
        Assert.Equal(expectedDatasetName, actualDatasetName);
        Assert.Equal(expectedPropertyName, actualPropertyNameActual);
        Assert.Equal(expectedAlias, actualAlias);
        Assert.Equal(expectedParameters, actualParameters);
    }

    [Theory]
    [InlineData("lorem.words(num=8")]
    [InlineData("lorem.wordsnum=8)")]
    [InlineData("lorem.words(num8)")]
    public void TryParseDataset_InvalidParam_ShouldBeFail(string dataset)
    {
        // Act
        var actualResult = _datasetHelper.TryParseDataset(
            dataset,
            out var actualDatasetName,
            out var actualPropertyName,
            out var actualAlias,
            out var actualParameters);

        // Assert
        Assert.False(actualResult);
        Assert.Empty(actualDatasetName);
        Assert.Empty(actualPropertyName);
        Assert.Empty(actualAlias);
        Assert.Empty(actualParameters);
    }

    #endregion

    #region ListPropertiesByDatasetName

    [Fact]
    public void ListProperties_InvalidDataset_ReturnsEmptyList()
    {
        // Act
        var datasetName = "XPTO";
        var properties = _datasetHelper.ListPropertiesByDatasetName(datasetName);

        // Assert
        Assert.Empty(properties);
    }

    [Fact]
    public void ListProperties_ValidDataset_ReturnsNotEmptyList()
    {
        // Act
        var datasetName = Datasets.LOREM;
        var properties = _datasetHelper.ListPropertiesByDatasetName(datasetName);

        // Assert
        Assert.NotEmpty(properties);
    }

    #endregion

    #region PropertyExists

    [Theory]
    [InlineData(Datasets.LOREM, "XPTO")]
    [InlineData("XPTO", LoremProperty.PARAGRAPH)]
    [InlineData("XPTO", "XPTO")]
    public void PropertyExists_InvalidProperty_ReturnsFals(string datasetName, string propertyName)
    {
        // Act
        var propertyExists = _datasetHelper.PropertyExists(datasetName, propertyName);

        // Assert
        Assert.False(propertyExists);
    }

    [Fact]
    public void PropertyExists_ValidProperty_ReturnsTrue()
    {
        // Act
        var datasetName = Datasets.NAME;
        var propertyName = NameProperty.FULL_NAME;
        var propertyExists = _datasetHelper.PropertyExists(datasetName, propertyName);

        // Assert
        Assert.True(propertyExists);
    }

    #endregion

    #region PropertyExists

    [Fact]
    public void ListDataset_ReturnsNotEmptyList()
    {
        // Act
        var datasets = _datasetHelper.ListDataset();

        // Assert
        Assert.NotEmpty(datasets);
    }

    #endregion

    #region PropertyExists

    [Theory]
    [InlineData(Datasets.NAME)]
    [InlineData(Datasets.LOREM)]
    [InlineData(Datasets.PHONE)]
    public void DatasetExists_ValidDataset_ReturnsTrue(string datasetName)
    {
        // Act
        var datasetExists = _datasetHelper.DatasetExists(datasetName);

        // Assert
        Assert.True(datasetExists);
    }

    [Theory]
    [InlineData("XPTO")]
    [InlineData("ABC")]
    [InlineData("123")]
    public void DatasetExists_InvalidDataset_ReturnsFalse(string datasetName)
    {
        // Act
        var datasetExists = _datasetHelper.DatasetExists(datasetName);

        // Assert
        Assert.False(datasetExists);
    }

    #endregion
}