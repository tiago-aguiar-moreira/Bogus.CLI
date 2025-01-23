using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Helpers;

namespace Bogus.CLI.Tests.Helpers;

public class DatasetHelperTest
{
    private readonly DatasetHelper _datasetHelper = new();

    #region TryParseDatasetAndProperty

    [Theory]
    [InlineData(Datasets.LOREM, LoremProperty.SLUG)]
    [InlineData(Datasets.LOREM, LoremProperty.WORD)]
    [InlineData(Datasets.NAME, NameProperty.FULL_NAME)]
    [InlineData(Datasets.NAME, NameProperty.SUFFIX)]
    [InlineData(Datasets.PHONE, PhoneProperty.NUMBER)]
    [InlineData(Datasets.PHONE, PhoneProperty.FORMAT)]
    public void TryParseDatasetAndPropertyName_ValidFormat_ShouldBeOk(string expectedDatasetName, string expectedPropertyName)
    {
        // Arrange
        var dataset = $"{expectedDatasetName}.{expectedPropertyName}";

        // Act
        var actualResult = _datasetHelper.TryParseDatasetAndProperty(
            dataset, out var actualDatasetName, out var actualPropertyNameActual);

        // Assert
        Assert.True(actualResult);
        Assert.Equal(expectedDatasetName, actualDatasetName);
        Assert.Equal(expectedPropertyName, actualPropertyNameActual);
    }

    [Theory]
    [InlineData("")]
    [InlineData(".")]
    [InlineData(" .")]
    [InlineData(" . ")]
    [InlineData(". ")]
    [InlineData("dataset")]
    [InlineData("dataset.")]
    [InlineData("dataset.123456")]
    [InlineData(".dataset")]
    [InlineData("123456.dataset")]
    [InlineData("abc123456.123456")]
    [InlineData("123456.123456")]
    [InlineData("123456.abc123456")]
    [InlineData("dataset.dataset.dataset")]
    [InlineData("123456.dataset.dataset")]
    [InlineData("dataset.123456.dataset")]
    [InlineData("dataset.dataset.123456")]
    public void TryParseDatasetAndPropertyName_InvalidFormat_ShouldBeFail(string dataset)
    {
        // Act
        var actualResult = _datasetHelper.TryParseDatasetAndProperty(
            dataset, out var actualDatasetName, out var actualPropertyNameActual);

        // Assert
        Assert.False(actualResult);
        Assert.Empty(actualDatasetName);
        Assert.Empty(actualPropertyNameActual);
    }

    #endregion

    #region TryParseParameters

    [Theory]
    [InlineData("num=8", 1)]
    [InlineData("num=8 separator=;", 2)]
    [InlineData("num=8 separator=,", 2)]
    [InlineData("num=8 separator=-", 2)]
    [InlineData("num=8 separator=_", 2)]
    [InlineData("num=8  separator=_", 2)]
    [InlineData("num=8   separator=_", 2)]
    [InlineData(" num=8   separator=_", 2)]
    [InlineData(" num=8   separator=_ ", 2)]
    [InlineData("num=8   separator=_ ", 2)]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    public void TryParseParameters_ValidInputs_ShouldBeOk(string parameters, int expectedParamsCount)
    {
        // Act
        var actualResult = _datasetHelper.TryParseParameters(parameters, out var parsedParameters);

        // Assert
        Assert.True(actualResult);
        Assert.Equal(expectedParamsCount, parsedParameters.Count);
    }

    [Theory]
    [InlineData("num=")]
    [InlineData(" num=")]
    [InlineData(" num= ")]
    [InlineData("num= ")]
    [InlineData("num = ")]
    [InlineData(" num = ")]
    [InlineData(" num =")]
    [InlineData("=8")]
    [InlineData("= 8")]
    [InlineData("= 8 ")]
    [InlineData(" = 8 ")]
    [InlineData(" = 8")]
    [InlineData("=")]
    [InlineData("= ")]
    [InlineData(" = ")]
    [InlineData(" =")]
    [InlineData("num=8;separator=;")]
    public void TryParseParameters_InvalidInputs_ShouldBeFail(string parameters)
    {
        // Act
        var actualResult = _datasetHelper.TryParseParameters(parameters, out var parsedParameters);

        // Assert
        Assert.False(actualResult);
        Assert.Empty(parsedParameters);
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

}