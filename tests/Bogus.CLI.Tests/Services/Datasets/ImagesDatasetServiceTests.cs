using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class ImagesDatasetServiceTests
{
    private readonly ImagesDatasetService _service;
    private readonly Mock<IImagesFakerAdapter> _adapterMock;

    public ImagesDatasetServiceTests()
    {
        _adapterMock = new Mock<IImagesFakerAdapter>();
        _service = new ImagesDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_DataUri_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.DataUri(200, 200, "grey")).Returns("data:image/svg+xml;...");

        var result = _service.Generate(ImagesProperty.DATA_URI, new Dictionary<string, object>());

        Assert.Equal("data:image/svg+xml;...", result);
        _adapterMock.Verify(v => v.DataUri(200, 200, "grey"), Times.Once);
    }

    [Fact]
    public void Generate_DataUri_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.DataUri(300, 150, "red")).Returns("data:image/svg+xml;...");

        var parameters = new Dictionary<string, object>
        {
            { ImagesDatasetService.PARAM_WIDTH, "300" },
            { ImagesDatasetService.PARAM_HEIGHT, "150" },
            { ImagesDatasetService.PARAM_COLOR, "red" }
        };

        var result = _service.Generate(ImagesProperty.DATA_URI, parameters);

        Assert.Equal("data:image/svg+xml;...", result);
        _adapterMock.Verify(v => v.DataUri(300, 150, "red"), Times.Once);
    }

    [Fact]
    public void Generate_PlaceImgUrl_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.PlaceImgUrl(640, 480, "Any")).Returns("https://placeimg.com/640/480/any");

        var result = _service.Generate(ImagesProperty.PLACE_IMG_URL, new Dictionary<string, object>());

        Assert.Equal("https://placeimg.com/640/480/any", result);
        _adapterMock.Verify(v => v.PlaceImgUrl(640, 480, "Any"), Times.Once);
    }

    [Fact]
    public void Generate_PlaceImgUrl_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.PlaceImgUrl(800, 600, "animals")).Returns("https://placeimg.com/800/600/animals");

        var parameters = new Dictionary<string, object>
        {
            { ImagesDatasetService.PARAM_WIDTH, "800" },
            { ImagesDatasetService.PARAM_HEIGHT, "600" },
            { ImagesDatasetService.PARAM_CATEGORY, "animals" }
        };

        var result = _service.Generate(ImagesProperty.PLACE_IMG_URL, parameters);

        Assert.Equal("https://placeimg.com/800/600/animals", result);
        _adapterMock.Verify(v => v.PlaceImgUrl(800, 600, "animals"), Times.Once);
    }

    [Fact]
    public void Generate_PicsumUrl_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.PicsumUrl(640, 480, false, false)).Returns("https://picsum.photos/640/480");

        var result = _service.Generate(ImagesProperty.PICSUM_URL, new Dictionary<string, object>());

        Assert.Equal("https://picsum.photos/640/480", result);
        _adapterMock.Verify(v => v.PicsumUrl(640, 480, false, false), Times.Once);
    }

    [Fact]
    public void Generate_PicsumUrl_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.PicsumUrl(400, 300, true, true)).Returns("https://picsum.photos/400/300?grayscale&blur");

        var parameters = new Dictionary<string, object>
        {
            { ImagesDatasetService.PARAM_WIDTH, "400" },
            { ImagesDatasetService.PARAM_HEIGHT, "300" },
            { ImagesDatasetService.PARAM_GRAYSCALE, "true" },
            { ImagesDatasetService.PARAM_BLUR, "true" }
        };

        var result = _service.Generate(ImagesProperty.PICSUM_URL, parameters);

        Assert.Equal("https://picsum.photos/400/300?grayscale&blur", result);
        _adapterMock.Verify(v => v.PicsumUrl(400, 300, true, true), Times.Once);
    }

    [Fact]
    public void Generate_PlaceholderUrl_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.PlaceholderUrl(200, 200, null, "png", "cccccc", "9c9c9c")).Returns("https://via.placeholder.com/200");

        var result = _service.Generate(ImagesProperty.PLACEHOLDER_URL, new Dictionary<string, object>());

        Assert.Equal("https://via.placeholder.com/200", result);
        _adapterMock.Verify(v => v.PlaceholderUrl(200, 200, null, "png", "cccccc", "9c9c9c"), Times.Once);
    }

    [Fact]
    public void Generate_PlaceholderUrl_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.PlaceholderUrl(400, 300, "Hello", "jpg", "ff0000", "ffffff")).Returns("https://via.placeholder.com/400x300.jpg/ff0000/ffffff?text=Hello");

        var parameters = new Dictionary<string, object>
        {
            { ImagesDatasetService.PARAM_WIDTH, "400" },
            { ImagesDatasetService.PARAM_HEIGHT, "300" },
            { ImagesDatasetService.PARAM_TEXT, "Hello" },
            { ImagesDatasetService.PARAM_FORMAT, "jpg" },
            { ImagesDatasetService.PARAM_BACK_COLOR, "ff0000" },
            { ImagesDatasetService.PARAM_TEXT_COLOR, "ffffff" }
        };

        var result = _service.Generate(ImagesProperty.PLACEHOLDER_URL, parameters);

        Assert.Equal("https://via.placeholder.com/400x300.jpg/ff0000/ffffff?text=Hello", result);
        _adapterMock.Verify(v => v.PlaceholderUrl(400, 300, "Hello", "jpg", "ff0000", "ffffff"), Times.Once);
    }

    [Fact]
    public void Generate_LoremFlickrUrl_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.LoremFlickrUrl(320, 240, null, false)).Returns("https://loremflickr.com/320/240");

        var result = _service.Generate(ImagesProperty.LOREM_FLICKR_URL, new Dictionary<string, object>());

        Assert.Equal("https://loremflickr.com/320/240", result);
        _adapterMock.Verify(v => v.LoremFlickrUrl(320, 240, null, false), Times.Once);
    }

    [Fact]
    public void Generate_LoremFlickrUrl_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.LoremFlickrUrl(640, 480, "cats", true)).Returns("https://loremflickr.com/640/480/cats?lock=1");

        var parameters = new Dictionary<string, object>
        {
            { ImagesDatasetService.PARAM_WIDTH, "640" },
            { ImagesDatasetService.PARAM_HEIGHT, "480" },
            { ImagesDatasetService.PARAM_KEYWORDS, "cats" },
            { ImagesDatasetService.PARAM_GRAYSCALE, "true" }
        };

        var result = _service.Generate(ImagesProperty.LOREM_FLICKR_URL, parameters);

        Assert.Equal("https://loremflickr.com/640/480/cats?lock=1", result);
        _adapterMock.Verify(v => v.LoremFlickrUrl(640, 480, "cats", true), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
