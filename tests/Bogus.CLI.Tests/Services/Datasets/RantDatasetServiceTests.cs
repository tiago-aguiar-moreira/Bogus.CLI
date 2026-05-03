using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class RantDatasetServiceTests
{
    private readonly RantDatasetService _service;
    private readonly Mock<IRantFakerAdapter> _adapterMock;

    public RantDatasetServiceTests()
    {
        _adapterMock = new Mock<IRantFakerAdapter>();
        _service = new RantDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Review_ShouldCallAdapterWithEmptyProduct()
    {
        _adapterMock.Setup(s => s.Review(string.Empty)).Returns("Great product!");

        var result = _service.Generate(RantProperty.REVIEW, new Dictionary<string, object>());

        Assert.Equal("Great product!", result);
        _adapterMock.Verify(v => v.Review(string.Empty), Times.Once);
    }

    [Fact]
    public void Generate_Review_WithProductParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Review("iPhone")).Returns("Love this phone!");

        var parameters = new Dictionary<string, object>
        {
            { RantDatasetService.PARAM_PRODUCT, "iPhone" }
        };

        var result = _service.Generate(RantProperty.REVIEW, parameters);

        Assert.Equal("Love this phone!", result);
        _adapterMock.Verify(v => v.Review("iPhone"), Times.Once);
    }

    [Fact]
    public void Generate_Reviews_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Reviews(string.Empty, 1)).Returns(["Decent product."]);

        var result = _service.Generate(RantProperty.REVIEWS, new Dictionary<string, object>());

        Assert.Equal("Decent product.", result);
        _adapterMock.Verify(v => v.Reviews(string.Empty, 1), Times.Once);
    }

    [Fact]
    public void Generate_Reviews_WithParams_ShouldJoinWithSeparator()
    {
        _adapterMock.Setup(s => s.Reviews("MacBook", 2)).Returns(["Amazing laptop.", "Best purchase ever."]);

        var parameters = new Dictionary<string, object>
        {
            { RantDatasetService.PARAM_PRODUCT, "MacBook" },
            { RantDatasetService.PARAM_LINES, "2" },
            { RantDatasetService.PARAM_SEPARATOR, " | " }
        };

        var result = _service.Generate(RantProperty.REVIEWS, parameters);

        Assert.Equal("Amazing laptop. | Best purchase ever.", result);
        _adapterMock.Verify(v => v.Reviews("MacBook", 2), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
