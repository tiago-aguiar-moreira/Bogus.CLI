using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class PersonDatasetServiceTests
{
    private readonly PersonDatasetService _service;
    private readonly Mock<IPersonFakerAdapter> _adapterMock;

    public PersonDatasetServiceTests()
    {
        _adapterMock = new Mock<IPersonFakerAdapter>();
        _service = new PersonDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_FirstName_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FirstName()).Returns("Gilberto");

        var result = _service.Generate(PersonProperty.FIRST_NAME, new Dictionary<string, object>());

        Assert.Equal("Gilberto", result);
        _adapterMock.Verify(v => v.FirstName(), Times.Once);
    }

    [Fact]
    public void Generate_LastName_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.LastName()).Returns("Heller");

        var result = _service.Generate(PersonProperty.LAST_NAME, new Dictionary<string, object>());

        Assert.Equal("Heller", result);
        _adapterMock.Verify(v => v.LastName(), Times.Once);
    }

    [Fact]
    public void Generate_FullName_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.FullName()).Returns("Gilberto Heller");

        var result = _service.Generate(PersonProperty.FULL_NAME, new Dictionary<string, object>());

        Assert.Equal("Gilberto Heller", result);
        _adapterMock.Verify(v => v.FullName(), Times.Once);
    }

    [Fact]
    public void Generate_Gender_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Gender()).Returns("Male");

        var result = _service.Generate(PersonProperty.GENDER, new Dictionary<string, object>());

        Assert.Equal("Male", result);
        _adapterMock.Verify(v => v.Gender(), Times.Once);
    }

    [Fact]
    public void Generate_UserName_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.UserName()).Returns("Gilberto_Heller28");

        var result = _service.Generate(PersonProperty.USER_NAME, new Dictionary<string, object>());

        Assert.Equal("Gilberto_Heller28", result);
        _adapterMock.Verify(v => v.UserName(), Times.Once);
    }

    [Fact]
    public void Generate_Avatar_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Avatar()).Returns("https://example.com/avatar/57.jpg");

        var result = _service.Generate(PersonProperty.AVATAR, new Dictionary<string, object>());

        Assert.Equal("https://example.com/avatar/57.jpg", result);
        _adapterMock.Verify(v => v.Avatar(), Times.Once);
    }

    [Fact]
    public void Generate_Email_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Email()).Returns("gilberto.heller@example.com");

        var result = _service.Generate(PersonProperty.EMAIL, new Dictionary<string, object>());

        Assert.Equal("gilberto.heller@example.com", result);
        _adapterMock.Verify(v => v.Email(), Times.Once);
    }

    [Fact]
    public void Generate_Phone_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Phone()).Returns("344.905.0014 x84460");

        var result = _service.Generate(PersonProperty.PHONE, new Dictionary<string, object>());

        Assert.Equal("344.905.0014 x84460", result);
        _adapterMock.Verify(v => v.Phone(), Times.Once);
    }

    [Fact]
    public void Generate_Website_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Website()).Returns("korey.info");

        var result = _service.Generate(PersonProperty.WEBSITE, new Dictionary<string, object>());

        Assert.Equal("korey.info", result);
        _adapterMock.Verify(v => v.Website(), Times.Once);
    }

    [Fact]
    public void Generate_DateOfBirth_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.DateOfBirth()).Returns("2004-12-12");

        var result = _service.Generate(PersonProperty.DATE_OF_BIRTH, new Dictionary<string, object>());

        Assert.Equal("2004-12-12", result);
        _adapterMock.Verify(v => v.DateOfBirth(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
