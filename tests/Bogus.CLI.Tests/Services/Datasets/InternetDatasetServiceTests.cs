using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;
public class InternetDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<IInternetFakerAdapter> _internetAdapterMock;
    private readonly IInternetDatasetService _internetDatasetService;

    public InternetDatasetServiceTests()
    {
        _internetAdapterMock = new Mock<IInternetFakerAdapter>();
        _internetDatasetService = new InternetDatasetService(_internetAdapterMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Fact]
    public void GenerateAvatar_ShouldCallAvatar()
    {
        _internetAdapterMock.Setup(s => s.Avatar()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.AVATAR, _parameters);
        _internetAdapterMock.Verify(v => v.Avatar(), Times.Once());
    }

    [Fact]
    public void GenerateDomainName_ShouldCallDomainName()
    {
        _internetAdapterMock.Setup(s => s.DomainName()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.DOMAIN_NAME, _parameters);
        _internetAdapterMock.Verify(v => v.DomainName(), Times.Once());
    }

    [Fact]
    public void GenerateDomainWord_ShouldCallDomainWord()
    {
        _internetAdapterMock.Setup(s => s.DomainWord()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.DOMAIN_WORD, _parameters);
        _internetAdapterMock.Verify(v => v.DomainWord(), Times.Once());
    }

    [Fact]
    public void GenerateDomainSuffix_ShouldCallDomainSuffix()
    {
        _internetAdapterMock.Setup(s => s.DomainSuffix()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.DOMAIN_SUFFIX, _parameters);
        _internetAdapterMock.Verify(v => v.DomainSuffix(), Times.Once());
    }

    [Fact]
    public void GenerateIp_ShouldCallIp()
    {
        _internetAdapterMock.Setup(s => s.Ip()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IP, _parameters);
        _internetAdapterMock.Verify(v => v.Ip(), Times.Once());
    }

    [Fact]
    public void GeneratePort_ShouldCallPort()
    {
        _internetAdapterMock.Setup(s => s.Port()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.PORT, _parameters);
        _internetAdapterMock.Verify(v => v.Port(), Times.Once());
    }

    [Fact]
    public void GenerateIpAddress_ShouldCallIpAddress()
    {
        _internetAdapterMock.Setup(s => s.IpAddress()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IP_ADDRESS, _parameters);
        _internetAdapterMock.Verify(v => v.IpAddress(), Times.Once());
    }

    [Fact]
    public void GenerateIpEndPoint_ShouldCallIpEndPoint()
    {
        _internetAdapterMock.Setup(s => s.IpEndPoint()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IP_ENDPOINT, _parameters);
        _internetAdapterMock.Verify(v => v.IpEndPoint(), Times.Once());
    }

    [Fact]
    public void GenerateIpv6_ShouldCallIpv6()
    {
        _internetAdapterMock.Setup(s => s.Ipv6()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IPV6, _parameters);
        _internetAdapterMock.Verify(v => v.Ipv6(), Times.Once());
    }

    [Fact]
    public void GenerateIpv6Address_ShouldCallIpv6Address()
    {
        _internetAdapterMock.Setup(s => s.Ipv6Address()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IPV6_ADDRESS, _parameters);
        _internetAdapterMock.Verify(v => v.Ipv6Address(), Times.Once());
    }

    [Fact]
    public void GenerateIpv6EndPoint_ShouldCallIpv6EndPoint()
    {
        _internetAdapterMock.Setup(s => s.Ipv6EndPoint()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.IPV6_ENDPOINT, _parameters);
        _internetAdapterMock.Verify(v => v.Ipv6EndPoint(), Times.Once());
    }

    [Fact]
    public void GenerateUserAgent_ShouldCallUserAgent()
    {
        _internetAdapterMock.Setup(s => s.UserAgent()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.USER_AGENT, _parameters);
        _internetAdapterMock.Verify(v => v.UserAgent(), Times.Once());
    }

    [Fact]
    public void GenerateProtocol_ShouldCallProtocol()
    {
        _internetAdapterMock.Setup(s => s.Protocol()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.PROTOCOL, _parameters);
        _internetAdapterMock.Verify(v => v.Protocol(), Times.Once());
    }

    [Fact]
    public void GenerateUrl_ShouldCallUrl()
    {
        _internetAdapterMock.Setup(s => s.Url()).Returns(string.Empty);
        _ = _internetDatasetService.Generate(InternetProperty.URL, _parameters);
        _internetAdapterMock.Verify(v => v.Url(), Times.Once());
    }

    [Fact]
    public void GenerateEmail_WithParams_ShouldPassParams()
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FIRST_NAME, "John");
        _parameters.AddParameter(InternetDatasetService.PARAM_LAST_NAME, "Doe");
        _parameters.AddParameter(InternetDatasetService.PARAM_PROVIDER, "example.com");
        _internetAdapterMock.Setup(s => s.Email(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.EMAIL, _parameters);

        _internetAdapterMock.Verify(v => v.Email("John", "Doe", "example.com", null), Times.Once());
    }

    [Fact]
    public void GenerateEmail_WithoutParams_ShouldPassNulls()
    {
        _internetAdapterMock.Setup(s => s.Email(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.EMAIL, _parameters);

        _internetAdapterMock.Verify(v => v.Email(null, null, null, null), Times.Once());
    }

    [Fact]
    public void GenerateExampleEmail_WithNames_ShouldPassNames()
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FIRST_NAME, "Jane");
        _parameters.AddParameter(InternetDatasetService.PARAM_LAST_NAME, "Smith");
        _internetAdapterMock.Setup(s => s.ExampleEmail(It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.EXAMPLE_EMAIL, _parameters);

        _internetAdapterMock.Verify(v => v.ExampleEmail("Jane", "Smith"), Times.Once());
    }

    [Fact]
    public void GenerateUserName_WithNames_ShouldPassNames()
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FIRST_NAME, "John");
        _parameters.AddParameter(InternetDatasetService.PARAM_LAST_NAME, "Doe");
        _internetAdapterMock.Setup(s => s.UserName(It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.USERNAME, _parameters);

        _internetAdapterMock.Verify(v => v.UserName("John", "Doe"), Times.Once());
    }

    [Fact]
    public void GenerateUserNameUnicode_WithNames_ShouldPassNames()
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FIRST_NAME, "João");
        _parameters.AddParameter(InternetDatasetService.PARAM_LAST_NAME, "Silva");
        _internetAdapterMock.Setup(s => s.UserNameUnicode(It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.USERNAME_UNICODE, _parameters);

        _internetAdapterMock.Verify(v => v.UserNameUnicode("João", "Silva"), Times.Once());
    }

    [Theory]
    [InlineData(":")]
    [InlineData("-")]
    public void GenerateMac_WithSeparator_ShouldPassSeparator(string separator)
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_SEPARATOR, separator);
        _internetAdapterMock.Setup(s => s.Mac(It.IsAny<string>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.MAC, _parameters);

        _internetAdapterMock.Verify(v => v.Mac(separator), Times.Once());
    }

    [Fact]
    public void GenerateMac_WithoutParams_ShouldUseDefaultSeparator()
    {
        _internetAdapterMock.Setup(s => s.Mac(It.IsAny<string>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.MAC, _parameters);

        _internetAdapterMock.Verify(v => v.Mac(":"), Times.Once());
    }

    [Theory]
    [InlineData(8, true)]
    [InlineData(16, false)]
    public void GeneratePassword_WithParams_ShouldPassParams(int length, bool memorable)
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_LENGTH, length);
        _parameters.AddParameter(InternetDatasetService.PARAM_MEMORABLE, memorable);
        _internetAdapterMock.Setup(s => s.Password(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.PASSWORD, _parameters);

        _internetAdapterMock.Verify(v => v.Password(length, memorable, null, null), Times.Once());
    }

    [Fact]
    public void GeneratePassword_WithoutParams_ShouldUseDefaults()
    {
        _internetAdapterMock.Setup(s => s.Password(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.PASSWORD, _parameters);

        _internetAdapterMock.Verify(v => v.Password(10, false, null, null), Times.Once());
    }

    [Theory]
    [InlineData("hex")]
    [InlineData("rgb")]
    [InlineData("delimited")]
    public void GenerateColor_WithFormat_ShouldPassFormat(string format)
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FORMAT, format);
        _internetAdapterMock.Setup(s => s.Color(It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.COLOR, _parameters);

        _internetAdapterMock.Verify(v => v.Color(0, 0, 0, false, format), Times.Once());
    }

    [Fact]
    public void GenerateColor_WithoutParams_ShouldUseDefaults()
    {
        _internetAdapterMock.Setup(s => s.Color(It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.COLOR, _parameters);

        _internetAdapterMock.Verify(v => v.Color(0, 0, 0, false, "hex"), Times.Once());
    }

    [Fact]
    public void GenerateUrlWithPath_WithParams_ShouldPassParams()
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_PROTOCOL, "https");
        _parameters.AddParameter(InternetDatasetService.PARAM_DOMAIN, "example.com");
        _parameters.AddParameter(InternetDatasetService.PARAM_FILE_EXT, "html");
        _internetAdapterMock.Setup(s => s.UrlWithPath(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.URL_WITH_PATH, _parameters);

        _internetAdapterMock.Verify(v => v.UrlWithPath("https", "example.com", "html"), Times.Once());
    }

    [Fact]
    public void GenerateUrlWithPath_WithoutParams_ShouldPassNulls()
    {
        _internetAdapterMock.Setup(s => s.UrlWithPath(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.URL_WITH_PATH, _parameters);

        _internetAdapterMock.Verify(v => v.UrlWithPath(null, null, null), Times.Once());
    }

    [Theory]
    [InlineData("html")]
    [InlineData("json")]
    public void GenerateUrlRootedPath_WithFileExt_ShouldPassFileExt(string fileExt)
    {
        _parameters.AddParameter(InternetDatasetService.PARAM_FILE_EXT, fileExt);
        _internetAdapterMock.Setup(s => s.UrlRootedPath(It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.URL_ROOTED_PATH, _parameters);

        _internetAdapterMock.Verify(v => v.UrlRootedPath(fileExt), Times.Once());
    }

    [Fact]
    public void GenerateUrlRootedPath_WithoutParams_ShouldPassNull()
    {
        _internetAdapterMock.Setup(s => s.UrlRootedPath(It.IsAny<string?>())).Returns(string.Empty);

        _ = _internetDatasetService.Generate(InternetProperty.URL_ROOTED_PATH, _parameters);

        _internetAdapterMock.Verify(v => v.UrlRootedPath(null), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void Generate_InvalidProperty_ReturnsNull(string property)
    {
        var result = _internetDatasetService.Generate(property, _parameters);
        Assert.Null(result);
    }
}
