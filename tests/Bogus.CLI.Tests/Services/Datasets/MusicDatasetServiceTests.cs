using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class MusicDatasetServiceTests
{
    private readonly MusicDatasetService _service;
    private readonly Mock<IMusicFakerAdapter> _adapterMock;

    public MusicDatasetServiceTests()
    {
        _adapterMock = new Mock<IMusicFakerAdapter>();
        _service = new MusicDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Genre_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Genre()).Returns("Rock");

        var result = _service.Generate(MusicProperty.GENRE, new Dictionary<string, object>());

        Assert.Equal("Rock", result);
        _adapterMock.Verify(v => v.Genre(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
