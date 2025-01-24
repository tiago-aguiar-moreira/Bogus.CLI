using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.Tests.Extensions;
public class StringExtensionTests
{
    [Theory]
    [InlineData("(##)####-####", '#', 10)]
    [InlineData("####-####", '#', 8)]
    [InlineData("dd/MM/yyyy", '/', 2)]
    public void CountCharacter_ShouldBeOk(string str, char character, int expectedCount)
    {
        // Act
        var actualCount = str.CountCharacter(character);

        // Assert
        Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [InlineData("(12)3456-7890", 10)]
    [InlineData("1234-5678", 8)]
    [InlineData("21/02/1964", 8)]
    public void CountNumbers_ShouldBeOk(string str, int expectedCount)
    {
        // Act
        var actualCount = str.CountNumbers();

        // Assert
        Assert.Equal(expectedCount, actualCount);
    }
}
