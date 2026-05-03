using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;
public class PhoneDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<IPhoneFakerAdapter> _phoneDatasetMock;
    private readonly IPhoneDatasetService _fakeDataPhoneService;

    public PhoneDatasetServiceTests()
    {
        _phoneDatasetMock = new Mock<IPhoneFakerAdapter>();
        _fakeDataPhoneService = new PhoneDatasetService(_phoneDatasetMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Theory]
    [InlineData("####-####")]
    [InlineData("(##)####-####")]
    public void GeneratePhoneNumber_WithFormat_ShouldBeOk(string format)
    {
        // Arrange
        _parameters.AddParameter(PhoneDatasetService.PARAM_FORMAT, format);
        _phoneDatasetMock
            .Setup(s => s.PhoneNumber(It.IsAny<string?>()))
            .Returns(string.Empty);

        // Act
        _ = _fakeDataPhoneService
            .Generate(PhoneProperty.NUMBER, _parameters);

        // Assert
        _phoneDatasetMock.Verify(v => v.PhoneNumber(format), Times.Once());
    }

    [Fact]
    public void GeneratePhoneNumber_WithoutFormat_ShouldBeOk()
    {
        // Arrange
        _phoneDatasetMock
            .Setup(s => s.PhoneNumber(It.IsAny<string?>()))
            .Returns(string.Empty);

        // Act
        _ = _fakeDataPhoneService
            .Generate(PhoneProperty.NUMBER, _parameters);

        // Assert
        _phoneDatasetMock.Verify(v => v.PhoneNumber(null), Times.Once());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GeneratePhoneNumberFormat_ShouldBeOk(int phoneFormatsArrayIndex)
    {
        // Arrange
        _parameters.AddParameter(
            PhoneDatasetService.PARAM_PHONE_FORMATS_ARRAY_INDEX,
            phoneFormatsArrayIndex);

        _phoneDatasetMock
            .Setup(s => s.PhoneNumberFormat(It.IsAny<int>()))
            .Returns(string.Empty);

        // Act
        _ = _fakeDataPhoneService
            .Generate(PhoneProperty.FORMAT, _parameters);

        // Assert
        _phoneDatasetMock.Verify(v => v.PhoneNumberFormat(phoneFormatsArrayIndex), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void GeneratePhoneNumber_InvalidProperty_ReturnsNull(string propertyname)
    {
        // Arrange
        _phoneDatasetMock
            .Setup(s => s.PhoneNumber(It.IsAny<string?>()))
            .Returns(string.Empty);

        // Act
        var actualValue = _fakeDataPhoneService
            .Generate(propertyname, _parameters);

        // Assert
        Assert.Null(actualValue);

        _phoneDatasetMock.Verify(v => v.PhoneNumber(null), Times.Never());
    }
}