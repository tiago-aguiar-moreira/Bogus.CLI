using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class CommerceDatasetServiceTests
{
    private readonly CommerceDatasetService _service;
    private readonly Mock<ICommerceFakerAdapter> _adapterMock;

    public CommerceDatasetServiceTests()
    {
        _adapterMock = new Mock<ICommerceFakerAdapter>();
        _service = new CommerceDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Department_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Department(It.IsAny<int>(), It.IsAny<bool>())).Returns("Electronics");

        var result = _service.Generate(CommerceProperty.DEPARTMENT, new Dictionary<string, object>());

        Assert.Equal("Electronics", result);
        _adapterMock.Verify(v => v.Department(1, false), Times.Once);
    }

    [Fact]
    public void Generate_Department_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Department(It.IsAny<int>(), It.IsAny<bool>())).Returns("Clothing & Games");

        var parameters = new Dictionary<string, object>
        {
            { CommerceDatasetService.PARAM_MAX.ToLower(), "3" },
            { CommerceDatasetService.PARAM_RETURN_MAX.ToLower(), "true" }
        };

        var result = _service.Generate(CommerceProperty.DEPARTMENT, parameters);

        Assert.Equal("Clothing & Games", result);
        _adapterMock.Verify(v => v.Department(3, true), Times.Once);
    }

    [Fact]
    public void Generate_Price_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Price(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<string>())).Returns("49.99");

        var result = _service.Generate(CommerceProperty.PRICE, new Dictionary<string, object>());

        Assert.Equal("49.99", result);
        _adapterMock.Verify(v => v.Price(1m, 1000m, 2, string.Empty), Times.Once);
    }

    [Fact]
    public void Generate_Price_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Price(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<string>())).Returns("$9.99");

        var parameters = new Dictionary<string, object>
        {
            { CommerceDatasetService.PARAM_MIN, "5" },
            { CommerceDatasetService.PARAM_MAX, "50" },
            { CommerceDatasetService.PARAM_DECIMALS, "2" },
            { CommerceDatasetService.PARAM_SYMBOL, "$" }
        };

        var result = _service.Generate(CommerceProperty.PRICE, parameters);

        Assert.Equal("$9.99", result);
        _adapterMock.Verify(v => v.Price(5m, 50m, 2, "$"), Times.Once);
    }

    [Fact]
    public void Generate_Categories_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Categories(It.IsAny<int>())).Returns(["Books", "Music"]);

        var result = _service.Generate(CommerceProperty.CATEGORIES, new Dictionary<string, object>());

        Assert.Equal("Books, Music", result);
        _adapterMock.Verify(v => v.Categories(1), Times.Once);
    }

    [Fact]
    public void Generate_Categories_WithParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Categories(It.IsAny<int>())).Returns(["Books", "Music", "Toys"]);

        var parameters = new Dictionary<string, object>
        {
            { CommerceDatasetService.PARAM_NUM, "3" },
            { CommerceDatasetService.PARAM_SEPARATOR, " | " }
        };

        var result = _service.Generate(CommerceProperty.CATEGORIES, parameters);

        Assert.Equal("Books | Music | Toys", result);
        _adapterMock.Verify(v => v.Categories(3), Times.Once);
    }

    [Fact]
    public void Generate_ProductName_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.ProductName()).Returns("Ergonomic Chair");

        var result = _service.Generate(CommerceProperty.PRODUCT_NAME, new Dictionary<string, object>());

        Assert.Equal("Ergonomic Chair", result);
        _adapterMock.Verify(v => v.ProductName(), Times.Once);
    }

    [Fact]
    public void Generate_Color_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Color()).Returns("blue");

        var result = _service.Generate(CommerceProperty.COLOR, new Dictionary<string, object>());

        Assert.Equal("blue", result);
        _adapterMock.Verify(v => v.Color(), Times.Once);
    }

    [Fact]
    public void Generate_Product_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Product()).Returns("Shoes");

        var result = _service.Generate(CommerceProperty.PRODUCT, new Dictionary<string, object>());

        Assert.Equal("Shoes", result);
        _adapterMock.Verify(v => v.Product(), Times.Once);
    }

    [Fact]
    public void Generate_ProductAdjective_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.ProductAdjective()).Returns("Sleek");

        var result = _service.Generate(CommerceProperty.PRODUCT_ADJECTIVE, new Dictionary<string, object>());

        Assert.Equal("Sleek", result);
        _adapterMock.Verify(v => v.ProductAdjective(), Times.Once);
    }

    [Fact]
    public void Generate_ProductMaterial_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.ProductMaterial()).Returns("Steel");

        var result = _service.Generate(CommerceProperty.PRODUCT_MATERIAL, new Dictionary<string, object>());

        Assert.Equal("Steel", result);
        _adapterMock.Verify(v => v.ProductMaterial(), Times.Once);
    }

    [Fact]
    public void Generate_ProductDescription_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.ProductDescription()).Returns("A great product.");

        var result = _service.Generate(CommerceProperty.PRODUCT_DESCRIPTION, new Dictionary<string, object>());

        Assert.Equal("A great product.", result);
        _adapterMock.Verify(v => v.ProductDescription(), Times.Once);
    }

    [Fact]
    public void Generate_Ean8_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Ean8()).Returns("12345678");

        var result = _service.Generate(CommerceProperty.EAN8, new Dictionary<string, object>());

        Assert.Equal("12345678", result);
        _adapterMock.Verify(v => v.Ean8(), Times.Once);
    }

    [Fact]
    public void Generate_Ean13_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Ean13()).Returns("1234567890123");

        var result = _service.Generate(CommerceProperty.EAN13, new Dictionary<string, object>());

        Assert.Equal("1234567890123", result);
        _adapterMock.Verify(v => v.Ean13(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
