using Bogus.CLI.Core.Services;

namespace Bogus.CLI.Tests.Services;
public class TemplateServiceTests
{
    private readonly TemplateService _templateService;

    public TemplateServiceTests()
    {
        _templateService = new TemplateService();
    }

    [Theory]
    [InlineData("Name: {{name}} Phone: {{phone}} Job: {{job}}")]
    [InlineData("Phone: {{1}} Name: {{0}} Job: {{2}}")]
    [InlineData("Name: {{name}} Phone: {{1}} Job: {{job}}")]
    [InlineData("Name: {{name}} Phone: {{1}} Job: {{job}} -- {{1}}")]
    public void SetTemplate_ValidTemplate_ReturnsTrue(string template)
    {
        // Act
        var actualResult = _templateService.SetTemplate(template, out var actualErrorMessage);

        // Assert
        Assert.True(actualResult);
        Assert.Empty(actualErrorMessage);
    }

    [Theory]
    [InlineData("Name: name Phone: phone Job: job", TemplateService.ERROR_TEMPLATE_NO_PLACEHOLDERS)]
    [InlineData("Name: {{name}} Phone: {{1 Job: {{job}}", TemplateService.ERROR_TEMPLATE_UNMATCHED_OPENING_BRACE)]
    [InlineData("Name: {{name}} Phone: {{1}} Job: job}}", TemplateService.ERROR_TEMPLATE_UNMATCHED_CLOSING_BRACE)]
    public void SetTemplate_InvalidTemplate_ReturnsFalse(string template, string expectedErrorMessage)
    {
        // Act
        var actualResult = _templateService.SetTemplate(template, out var actualErrorMessage);

        // Assert
        Assert.False(actualResult);
        Assert.Equal(actualErrorMessage, expectedErrorMessage);
    }

    [Theory]
    [InlineData("Name: {{name}} Phone: {{phone}} Job: {{job}}", "Name: Jack Phone: 99999-9999 Job: job description")]
    [InlineData("Phone: {{1}} Name: {{0}} Job: {{2}}", "Phone: 99999-9999 Name: Jack Job: job description")]
    [InlineData("Name: {{name}} Phone: {{1}} Job: {{job}}", "Name: Jack Phone: 99999-9999 Job: job description")]
    public void Format_ValidTemplate_ReturnsFalse(string template, string expectedResult)
    {
        // Arrange
        var values = new List<(string Value, string Alias)>()
        {
             ( "Jack", "name" ),
             ( "99999-9999", "phone" ),
             ( "job description", "job" ),
        };

        // Act
        _ = _templateService.SetTemplate(template, out var _);
        var actualResult = _templateService.Format(values);

        // Assert
        Assert.Equal(actualResult, expectedResult);
    }
}