using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.Tests.Extensions;

public class ParamaterExtensionTests
{
    private readonly IDictionary<string, object> _parameters;

    public ParamaterExtensionTests()
    {
        _parameters = new Dictionary<string, object>();
    }

    #region ConvertToInt (not nullable)

    [Fact]
    public void ConvertToIntNotNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "123");
        
        // Act
        var result = _parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void ConvertToIntNotNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ConvertToIntNotNullable_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        _parameters.AddParameter("key1", "abc");

        // Act
        var result = _parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region ConvertToInt (nullable)

    [Fact]
    public void ConvertToIntNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "123");
        
        // Act
        var result = _parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void ConvertToIntNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ConvertToIntNullable_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        _parameters.AddParameter("key1", "abc");

        // Act
        var result = _parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region ConvertToString

    [Fact]
    public void ConvertToString_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "value");

        // Act
        var result = _parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("value", result);
    }

    [Fact]
    public void ConvertToString_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("default", result);
    }

    [Fact]
    public void ConvertToString_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        _parameters.AddParameter("key1", null!);

        // Act
        var result = _parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("default", result);
    }

    #endregion

    #region ConvertToChar

    [Fact]
    public void ConvertToChar_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "A");

        // Act
        var result = _parameters.ConvertToChar("key1", 'B');

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void ConvertToChar_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToChar("key1", 'B');

        // Assert
        Assert.Equal('B', result);
    }

    [Fact]
    public void ConvertToChar_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        _parameters.AddParameter("key1", "abc");

        // Act
        var result = _parameters.ConvertToBool("key1", false);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region ConvertToBool (not nullable)

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "true");

        // Act
        var result = _parameters.ConvertToBool("key1", false);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToBool("key1", false);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsNullableBool_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "true");

        // Act
        var result = _parameters.ConvertToBool("key1", null);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ConvertToBool (nullable)

    [Fact]
    public void ConvertToBoolNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "true");

        // Act
        var result = _parameters.ConvertToBool("key1", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ConvertToBoolNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Act
        var result = _parameters.ConvertToBool("key1", null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ConvertToBoolNullable_ReturnsNullableBool_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        _parameters.AddParameter("key1", "abc");

        // Act
        var result = _parameters.ConvertToBool("key1", null);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region AddParameter

    [Theory]
    [InlineData("key", "Text")]
    [InlineData("key", true)]
    [InlineData("key", 54)]
    public void AddParameter_ShouldAddValue_WhenKeyAndValueAreValid(string key, object value)
    {
        var expectedCount = 1;

        // Act
        _parameters.AddParameter(key, value);

        // Assert
        Assert.Equal(expectedCount, _parameters.Count);
    }

    [Theory]
    [InlineData("", null)]
    [InlineData(null, null)]
    [InlineData(null, "")]
    [InlineData("key", null)]
    [InlineData("", "value")]
    public void AddParameter_ShouldNotAddValue_WhenKeyOrValueAreInvalid(string key, object value)
    {
        // Act
        _parameters.AddParameter(key, value);

        // Assert
        Assert.Empty(_parameters);
    }

    #endregion
}
