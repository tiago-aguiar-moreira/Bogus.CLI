using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class DatabaseDatasetServiceTests
{
    private readonly DatabaseDatasetService _service;
    private readonly Mock<IDatabaseFakerAdapter> _adapterMock;

    public DatabaseDatasetServiceTests()
    {
        _adapterMock = new Mock<IDatabaseFakerAdapter>();
        _service = new DatabaseDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Column_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Column()).Returns("created_at");

        var result = _service.Generate(DatabaseProperty.COLUMN, new Dictionary<string, object>());

        Assert.Equal("created_at", result);
        _adapterMock.Verify(v => v.Column(), Times.Once);
    }

    [Fact]
    public void Generate_Type_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Type()).Returns("varchar");

        var result = _service.Generate(DatabaseProperty.TYPE, new Dictionary<string, object>());

        Assert.Equal("varchar", result);
        _adapterMock.Verify(v => v.Type(), Times.Once);
    }

    [Fact]
    public void Generate_Collation_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Collation()).Returns("utf8_general_ci");

        var result = _service.Generate(DatabaseProperty.COLLATION, new Dictionary<string, object>());

        Assert.Equal("utf8_general_ci", result);
        _adapterMock.Verify(v => v.Collation(), Times.Once);
    }

    [Fact]
    public void Generate_Engine_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Engine()).Returns("InnoDB");

        var result = _service.Generate(DatabaseProperty.ENGINE, new Dictionary<string, object>());

        Assert.Equal("InnoDB", result);
        _adapterMock.Verify(v => v.Engine(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
