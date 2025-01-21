using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.Tests.Extensions;

public class ParamaterExtensionTests
{
    #region ConvertToInt (not nullable)

    [Fact]
    public void ConvertToIntNotNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "123" }
        };

        // Act
        var result = parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void ConvertToIntNotNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ConvertToIntNotNullable_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "abc" }
        };

        // Act
        var result = parameters.ConvertToInt("key1", 0);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region ConvertToInt (nullable)

    [Fact]
    public void ConvertToIntNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "123" }
        };

        // Act
        var result = parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void ConvertToIntNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ConvertToIntNullable_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "abc" }
        };

        // Act
        var result = parameters.ConvertToInt("key1", null);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region ConvertToString

    [Fact]
    public void ConvertToString_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "value" }
        };

        // Act
        var result = parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("value", result);
    }

    [Fact]
    public void ConvertToString_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("default", result);
    }

    [Fact]
    public void ConvertToString_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", null! }
        };

        // Act
        var result = parameters.ConvertToString("key1", "default");

        // Assert
        Assert.Equal("default", result);
    }

    #endregion

    #region ConvertToChar

    [Fact]
    public void ConvertToChar_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "A" }
        };

        // Act
        var result = parameters.ConvertToChar("key1", 'B');

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void ConvertToChar_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToChar("key1", 'B');

        // Assert
        Assert.Equal('B', result);
    }

    [Fact]
    public void ConvertToChar_ReturnsDefaultValue_WhenValueIsInvalid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "abc" }
        };

        // Act
        var result = parameters.ConvertToBool("key1", false);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region ConvertToBool (not nullable)

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "true" }
        };

        // Act
        var result = parameters.ConvertToBool("key1", false);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToBool("key1", false);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ConvertToBoolNotNullable_ReturnsNullableBool_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "true" }
        };

        // Act
        var result = parameters.ConvertToBool("key1", null);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ConvertToBool (nullable)

    [Fact]
    public void ConvertToBoolNullable_ReturnsConvertedValue_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "true" }
        };

        // Act
        var result = parameters.ConvertToBool("key1", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ConvertToBoolNullable_ReturnsDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        var parameters = new Dictionary<string, object>();

        // Act
        var result = parameters.ConvertToBool("key1", null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ConvertToBoolNullable_ReturnsNullableBool_WhenKeyExistsAndValueIsValid()
    {
        // Arrange
        var parameters = new Dictionary<string, object>
        {
            { "key1", "abc" }
        };

        // Act
        var result = parameters.ConvertToBool("key1", null);

        // Assert
        Assert.Null(result);
    }

    #endregion
}
