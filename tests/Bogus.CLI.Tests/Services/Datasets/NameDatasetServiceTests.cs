using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;
using static Bogus.DataSets.Name;

namespace Bogus.CLI.Tests.Services.Datasets;
public class NameDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<INameFakerAdapter> _nameAdapterMock;
    private readonly INameDatasetService _nameDatasetService;

    public NameDatasetServiceTests()
    {
        _nameAdapterMock = new Mock<INameFakerAdapter>();
        _nameDatasetService = new NameDatasetService(_nameAdapterMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Theory]
    [InlineData("male", Gender.Male)]
    [InlineData("female", Gender.Female)]
    public void GenerateFirstName_WithGender_ShouldCallFirstNameWithGender(string genderParam, Gender expected)
    {
        // Arrange
        _parameters.AddParameter("gender", genderParam);
        _nameAdapterMock.Setup(s => s.FirstName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FIRST_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FirstName(expected), Times.Once());
    }

    [Fact]
    public void GenerateFirstName_WithoutGender_ShouldCallFirstNameWithoutGender()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.FirstName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FIRST_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FirstName(null), Times.Once());
    }

    [Theory]
    [InlineData("male", Gender.Male)]
    [InlineData("female", Gender.Female)]
    public void GenerateLastName_WithGender_ShouldCallLastNameWithGender(string genderParam, Gender expected)
    {
        // Arrange
        _parameters.AddParameter("gender", genderParam);
        _nameAdapterMock.Setup(s => s.LastName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.LAST_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.LastName(expected), Times.Once());
    }

    [Fact]
    public void GenerateLastName_WithoutGender_ShouldCallLastNameWithoutGender()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.LastName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.LAST_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.LastName(null), Times.Once());
    }

    [Theory]
    [InlineData("male", Gender.Male)]
    [InlineData("female", Gender.Female)]
    public void GenerateFullName_WithGender_ShouldCallFullNameWithGender(string genderParam, Gender expected)
    {
        // Arrange
        _parameters.AddParameter("gender", genderParam);
        _nameAdapterMock.Setup(s => s.FullName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FULL_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FullName(expected), Times.Once());
    }

    [Fact]
    public void GenerateFullName_WithoutGender_ShouldCallFullNameWithoutGender()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.FullName(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FULL_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FullName(null), Times.Once());
    }

    [Theory]
    [InlineData("male", Gender.Male)]
    [InlineData("female", Gender.Female)]
    public void GeneratePrefix_WithGender_ShouldCallPrefixWithGender(string genderParam, Gender expected)
    {
        // Arrange
        _parameters.AddParameter("gender", genderParam);
        _nameAdapterMock.Setup(s => s.Prefix(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.PREFIX, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.Prefix(expected), Times.Once());
    }

    [Fact]
    public void GeneratePrefix_WithoutGender_ShouldCallPrefixWithoutGender()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.Prefix(It.IsAny<Gender?>())).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.PREFIX, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.Prefix(null), Times.Once());
    }

    [Fact]
    public void GenerateSuffix_ShouldCallSuffix()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.Suffix()).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.SUFFIX, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.Suffix(), Times.Once());
    }

    [Fact]
    public void GenerateJobTitle_ShouldCallJobTitle()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.JobTitle()).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.JOB_TITLE, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.JobTitle(), Times.Once());
    }

    [Fact]
    public void GenerateJobDescriptor_ShouldCallJobDescriptor()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.JobDescriptor()).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.JOB_DESCRIPTOR, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.JobDescriptor(), Times.Once());
    }

    [Fact]
    public void GenerateJobArea_ShouldCallJobArea()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.JobArea()).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.JOB_AREA, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.JobArea(), Times.Once());
    }

    [Fact]
    public void GenerateJobType_ShouldCallJobType()
    {
        // Arrange
        _nameAdapterMock.Setup(s => s.JobType()).Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.JOB_TYPE, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.JobType(), Times.Once());
    }

    [Theory]
    [InlineData("male", Gender.Male)]
    [InlineData("female", Gender.Female)]
    public void GenerateFindName_WithGender_ShouldCallFindNameWithGender(string genderParam, Gender expected)
    {
        // Arrange
        _parameters.AddParameter("gender", genderParam);
        _nameAdapterMock
            .Setup(s => s.FindName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<Gender?>()))
            .Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FIND_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FindName(string.Empty, string.Empty, null, null, expected), Times.Once());
    }

    [Fact]
    public void GenerateFindName_WithCustomNames_ShouldPassNamesToAdapter()
    {
        // Arrange
        _parameters.AddParameter("firstName", "John");
        _parameters.AddParameter("lastName", "Doe");
        _nameAdapterMock
            .Setup(s => s.FindName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<Gender?>()))
            .Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FIND_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FindName("John", "Doe", null, null, null), Times.Once());
    }

    [Fact]
    public void GenerateFindName_WithPrefixAndSuffix_ShouldPassFlagsToAdapter()
    {
        // Arrange
        _parameters.AddParameter("withPrefix", true);
        _parameters.AddParameter("withSuffix", false);
        _nameAdapterMock
            .Setup(s => s.FindName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<Gender?>()))
            .Returns(string.Empty);

        // Act
        _ = _nameDatasetService.Generate(NameProperty.FIND_NAME, _parameters);

        // Assert
        _nameAdapterMock.Verify(v => v.FindName(string.Empty, string.Empty, true, false, null), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void Generate_InvalidProperty_ReturnsNull(string property)
    {
        // Act
        var result = _nameDatasetService.Generate(property, _parameters);

        // Assert
        Assert.Null(result);
    }
}
