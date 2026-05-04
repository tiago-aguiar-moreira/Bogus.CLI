using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class SystemDatasetServiceTests
{
    private readonly SystemDatasetService _service;
    private readonly Mock<ISystemFakerAdapter> _adapterMock;

    public SystemDatasetServiceTests()
    {
        _adapterMock = new Mock<ISystemFakerAdapter>();
        _service = new SystemDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_FileName_ShouldCallAdapterWithNullExt()
    {
        _adapterMock.Setup(s => s.FileName(null)).Returns("report.csv");

        var result = _service.Generate(SystemProperty.FILE_NAME, new Dictionary<string, object>());

        Assert.Equal("report.csv", result);
        _adapterMock.Verify(v => v.FileName(null), Times.Once);
    }

    [Fact]
    public void Generate_FileName_WithExtParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FileName("pdf")).Returns("report.pdf");

        var parameters = new Dictionary<string, object> { { SystemDatasetService.PARAM_EXT, "pdf" } };

        var result = _service.Generate(SystemProperty.FILE_NAME, parameters);

        Assert.Equal("report.pdf", result);
        _adapterMock.Verify(v => v.FileName("pdf"), Times.Once);
    }

    [Fact]
    public void Generate_DirectoryPath_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.DirectoryPath()).Returns("/usr/local/bin");

        var result = _service.Generate(SystemProperty.DIRECTORY_PATH, new Dictionary<string, object>());

        Assert.Equal("/usr/local/bin", result);
        _adapterMock.Verify(v => v.DirectoryPath(), Times.Once);
    }

    [Fact]
    public void Generate_FilePath_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FilePath()).Returns("/etc/config/app.conf");

        var result = _service.Generate(SystemProperty.FILE_PATH, new Dictionary<string, object>());

        Assert.Equal("/etc/config/app.conf", result);
        _adapterMock.Verify(v => v.FilePath(), Times.Once);
    }

    [Fact]
    public void Generate_CommonFileName_ShouldCallAdapterWithNullExt()
    {
        _adapterMock.Setup(s => s.CommonFileName(null)).Returns("document.pdf");

        var result = _service.Generate(SystemProperty.COMMON_FILE_NAME, new Dictionary<string, object>());

        Assert.Equal("document.pdf", result);
        _adapterMock.Verify(v => v.CommonFileName(null), Times.Once);
    }

    [Fact]
    public void Generate_MimeType_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.MimeType()).Returns("application/json");

        var result = _service.Generate(SystemProperty.MIME_TYPE, new Dictionary<string, object>());

        Assert.Equal("application/json", result);
        _adapterMock.Verify(v => v.MimeType(), Times.Once);
    }

    [Fact]
    public void Generate_CommonFileType_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.CommonFileType()).Returns("video");

        var result = _service.Generate(SystemProperty.COMMON_FILE_TYPE, new Dictionary<string, object>());

        Assert.Equal("video", result);
        _adapterMock.Verify(v => v.CommonFileType(), Times.Once);
    }

    [Fact]
    public void Generate_CommonFileExt_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.CommonFileExt()).Returns("mp4");

        var result = _service.Generate(SystemProperty.COMMON_FILE_EXT, new Dictionary<string, object>());

        Assert.Equal("mp4", result);
        _adapterMock.Verify(v => v.CommonFileExt(), Times.Once);
    }

    [Fact]
    public void Generate_FileType_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FileType()).Returns("image");

        var result = _service.Generate(SystemProperty.FILE_TYPE, new Dictionary<string, object>());

        Assert.Equal("image", result);
        _adapterMock.Verify(v => v.FileType(), Times.Once);
    }

    [Fact]
    public void Generate_FileExt_ShouldCallAdapterWithNullMimeType()
    {
        _adapterMock.Setup(s => s.FileExt(null)).Returns("png");

        var result = _service.Generate(SystemProperty.FILE_EXT, new Dictionary<string, object>());

        Assert.Equal("png", result);
        _adapterMock.Verify(v => v.FileExt(null), Times.Once);
    }

    [Fact]
    public void Generate_FileExt_WithMimeTypeParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FileExt("image/png")).Returns("png");

        var parameters = new Dictionary<string, object> { { SystemDatasetService.PARAM_MIME_TYPE, "image/png" } };

        var result = _service.Generate(SystemProperty.FILE_EXT, parameters);

        Assert.Equal("png", result);
        _adapterMock.Verify(v => v.FileExt("image/png"), Times.Once);
    }

    [Fact]
    public void Generate_Semver_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Semver()).Returns("3.1.4");

        var result = _service.Generate(SystemProperty.SEMVER, new Dictionary<string, object>());

        Assert.Equal("3.1.4", result);
        _adapterMock.Verify(v => v.Semver(), Times.Once);
    }

    [Fact]
    public void Generate_Version_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Version()).Returns("2.4.1.0");

        var result = _service.Generate(SystemProperty.VERSION, new Dictionary<string, object>());

        Assert.Equal("2.4.1.0", result);
        _adapterMock.Verify(v => v.Version(), Times.Once);
    }

    [Fact]
    public void Generate_Exception_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Exception()).Returns("Object reference not set to an instance of an object.");

        var result = _service.Generate(SystemProperty.EXCEPTION, new Dictionary<string, object>());

        Assert.Equal("Object reference not set to an instance of an object.", result);
        _adapterMock.Verify(v => v.Exception(), Times.Once);
    }

    [Fact]
    public void Generate_AndroidId_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.AndroidId()).Returns("APA91bHPRgkFz...");

        var result = _service.Generate(SystemProperty.ANDROID_ID, new Dictionary<string, object>());

        Assert.Equal("APA91bHPRgkFz...", result);
        _adapterMock.Verify(v => v.AndroidId(), Times.Once);
    }

    [Fact]
    public void Generate_ApplePushToken_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.ApplePushToken()).Returns("7256d7bae45a60b...");

        var result = _service.Generate(SystemProperty.APPLE_PUSH_TOKEN, new Dictionary<string, object>());

        Assert.Equal("7256d7bae45a60b...", result);
        _adapterMock.Verify(v => v.ApplePushToken(), Times.Once);
    }

    [Fact]
    public void Generate_BlackBerryPin_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.BlackBerryPin()).Returns("a1b2c3d4");

        var result = _service.Generate(SystemProperty.BLACKBERRY_PIN, new Dictionary<string, object>());

        Assert.Equal("a1b2c3d4", result);
        _adapterMock.Verify(v => v.BlackBerryPin(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
