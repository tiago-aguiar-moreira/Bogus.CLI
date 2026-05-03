using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class CompanyDatasetServiceTests
{
    private readonly CompanyDatasetService _service;
    private readonly Mock<ICompanyFakerAdapter> _adapterMock;

    public CompanyDatasetServiceTests()
    {
        _adapterMock = new Mock<ICompanyFakerAdapter>();
        _service = new CompanyDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_CompanySuffix_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.CompanySuffix()).Returns("Inc");

        var result = _service.Generate(CompanyProperty.COMPANY_SUFFIX, new Dictionary<string, object>());

        Assert.Equal("Inc", result);
        _adapterMock.Verify(v => v.CompanySuffix(), Times.Once);
    }

    [Fact]
    public void Generate_CompanyName_ShouldCallAdapterWithNullFormat()
    {
        _adapterMock.Setup(s => s.CompanyName(null)).Returns("Acme Inc");

        var result = _service.Generate(CompanyProperty.COMPANY_NAME, new Dictionary<string, object>());

        Assert.Equal("Acme Inc", result);
        _adapterMock.Verify(v => v.CompanyName(null), Times.Once);
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void Generate_CompanyName_WithFormatParam_ShouldCallAdapter(string formatValue, int expectedIndex)
    {
        _adapterMock.Setup(s => s.CompanyName(expectedIndex)).Returns("Acme-Corp");

        var parameters = new Dictionary<string, object>
        {
            { CompanyDatasetService.PARAM_FORMAT, formatValue }
        };

        var result = _service.Generate(CompanyProperty.COMPANY_NAME, parameters);

        Assert.Equal("Acme-Corp", result);
        _adapterMock.Verify(v => v.CompanyName(expectedIndex), Times.Once);
    }

    [Fact]
    public void Generate_CatchPhrase_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.CatchPhrase()).Returns("Innovate beyond limits");

        var result = _service.Generate(CompanyProperty.CATCH_PHRASE, new Dictionary<string, object>());

        Assert.Equal("Innovate beyond limits", result);
        _adapterMock.Verify(v => v.CatchPhrase(), Times.Once);
    }

    [Fact]
    public void Generate_Bs_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Bs()).Returns("synergize bleeding-edge markets");

        var result = _service.Generate(CompanyProperty.BS, new Dictionary<string, object>());

        Assert.Equal("synergize bleeding-edge markets", result);
        _adapterMock.Verify(v => v.Bs(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
