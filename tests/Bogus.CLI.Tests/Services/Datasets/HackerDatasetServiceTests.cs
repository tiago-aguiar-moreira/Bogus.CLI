using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class HackerDatasetServiceTests
{
    private readonly HackerDatasetService _service;
    private readonly Mock<IHackerFakerAdapter> _adapterMock;

    public HackerDatasetServiceTests()
    {
        _adapterMock = new Mock<IHackerFakerAdapter>();
        _service = new HackerDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Abbreviation_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Abbreviation()).Returns("TCP");

        var result = _service.Generate(HackerProperty.ABBREVIATION, new Dictionary<string, object>());

        Assert.Equal("TCP", result);
        _adapterMock.Verify(v => v.Abbreviation(), Times.Once);
    }

    [Fact]
    public void Generate_Adjective_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Adjective()).Returns("neural");

        var result = _service.Generate(HackerProperty.ADJECTIVE, new Dictionary<string, object>());

        Assert.Equal("neural", result);
        _adapterMock.Verify(v => v.Adjective(), Times.Once);
    }

    [Fact]
    public void Generate_Noun_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Noun()).Returns("protocol");

        var result = _service.Generate(HackerProperty.NOUN, new Dictionary<string, object>());

        Assert.Equal("protocol", result);
        _adapterMock.Verify(v => v.Noun(), Times.Once);
    }

    [Fact]
    public void Generate_Verb_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Verb()).Returns("hack");

        var result = _service.Generate(HackerProperty.VERB, new Dictionary<string, object>());

        Assert.Equal("hack", result);
        _adapterMock.Verify(v => v.Verb(), Times.Once);
    }

    [Fact]
    public void Generate_IngVerb_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.IngVerb()).Returns("bypassing");

        var result = _service.Generate(HackerProperty.ING_VERB, new Dictionary<string, object>());

        Assert.Equal("bypassing", result);
        _adapterMock.Verify(v => v.IngVerb(), Times.Once);
    }

    [Fact]
    public void Generate_Phrase_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Phrase()).Returns("Try to reboot the EXE bus!");

        var result = _service.Generate(HackerProperty.PHRASE, new Dictionary<string, object>());

        Assert.Equal("Try to reboot the EXE bus!", result);
        _adapterMock.Verify(v => v.Phrase(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
