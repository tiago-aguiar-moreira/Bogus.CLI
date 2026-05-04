using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class RandomDatasetServiceTests
{
    private readonly RandomDatasetService _service;
    private readonly Mock<IRandomFakerAdapter> _adapterMock;

    public RandomDatasetServiceTests()
    {
        _adapterMock = new Mock<IRandomFakerAdapter>();
        _service = new RandomDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Number_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Number(0, 1)).Returns("1");

        var result = _service.Generate(RandomProperty.NUMBER, new Dictionary<string, object>());

        Assert.Equal("1", result);
        _adapterMock.Verify(v => v.Number(0, 1), Times.Once);
    }

    [Fact]
    public void Generate_Number_WithMinMaxParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Number(5, 100)).Returns("42");

        var parameters = new Dictionary<string, object>
        {
            { RandomDatasetService.PARAM_MIN, "5" },
            { RandomDatasetService.PARAM_MAX, "100" }
        };

        var result = _service.Generate(RandomProperty.NUMBER, parameters);

        Assert.Equal("42", result);
        _adapterMock.Verify(v => v.Number(5, 100), Times.Once);
    }

    [Fact]
    public void Generate_Even_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Even(0, 1)).Returns("0");

        var result = _service.Generate(RandomProperty.EVEN, new Dictionary<string, object>());

        Assert.Equal("0", result);
        _adapterMock.Verify(v => v.Even(0, 1), Times.Once);
    }

    [Fact]
    public void Generate_Odd_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Odd(0, 1)).Returns("1");

        var result = _service.Generate(RandomProperty.ODD, new Dictionary<string, object>());

        Assert.Equal("1", result);
        _adapterMock.Verify(v => v.Odd(0, 1), Times.Once);
    }

    [Fact]
    public void Generate_Int_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Int(int.MinValue, int.MaxValue)).Returns("123456");

        var result = _service.Generate(RandomProperty.INT, new Dictionary<string, object>());

        Assert.Equal("123456", result);
        _adapterMock.Verify(v => v.Int(int.MinValue, int.MaxValue), Times.Once);
    }

    [Fact]
    public void Generate_Long_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Long(long.MinValue, long.MaxValue)).Returns("9876543210");

        var result = _service.Generate(RandomProperty.LONG, new Dictionary<string, object>());

        Assert.Equal("9876543210", result);
        _adapterMock.Verify(v => v.Long(long.MinValue, long.MaxValue), Times.Once);
    }

    [Fact]
    public void Generate_Double_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Double(0d, 1d)).Returns("0.75");

        var result = _service.Generate(RandomProperty.DOUBLE, new Dictionary<string, object>());

        Assert.Equal("0.75", result);
        _adapterMock.Verify(v => v.Double(0d, 1d), Times.Once);
    }

    [Fact]
    public void Generate_Decimal_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Decimal(0m, 1m)).Returns("0.5");

        var result = _service.Generate(RandomProperty.DECIMAL, new Dictionary<string, object>());

        Assert.Equal("0.5", result);
        _adapterMock.Verify(v => v.Decimal(0m, 1m), Times.Once);
    }

    [Fact]
    public void Generate_Float_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Float(0f, 1f)).Returns("0.25");

        var result = _service.Generate(RandomProperty.FLOAT, new Dictionary<string, object>());

        Assert.Equal("0.25", result);
        _adapterMock.Verify(v => v.Float(0f, 1f), Times.Once);
    }

    [Fact]
    public void Generate_Bool_ShouldCallAdapterWithDefaultWeight()
    {
        _adapterMock.Setup(s => s.Bool(0.5f)).Returns("True");

        var result = _service.Generate(RandomProperty.BOOL, new Dictionary<string, object>());

        Assert.Equal("True", result);
        _adapterMock.Verify(v => v.Bool(0.5f), Times.Once);
    }

    [Fact]
    public void Generate_Bool_WithWeightParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Bool(0.8f)).Returns("True");

        var parameters = new Dictionary<string, object> { { RandomDatasetService.PARAM_WEIGHT, "0.8" } };

        var result = _service.Generate(RandomProperty.BOOL, parameters);

        Assert.Equal("True", result);
        _adapterMock.Verify(v => v.Bool(0.8f), Times.Once);
    }

    [Fact]
    public void Generate_Char_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Char(char.MinValue, char.MaxValue)).Returns("a");

        var result = _service.Generate(RandomProperty.CHAR, new Dictionary<string, object>());

        Assert.Equal("a", result);
        _adapterMock.Verify(v => v.Char(char.MinValue, char.MaxValue), Times.Once);
    }

    [Fact]
    public void Generate_Guid_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Guid()).Returns("550e8400-e29b-41d4-a716-446655440000");

        var result = _service.Generate(RandomProperty.GUID, new Dictionary<string, object>());

        Assert.Equal("550e8400-e29b-41d4-a716-446655440000", result);
        _adapterMock.Verify(v => v.Guid(), Times.Once);
    }

    [Fact]
    public void Generate_Hash_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Hash(40, false)).Returns("da39a3ee5e6b4b0d3255bfef95601890afd80709");

        var result = _service.Generate(RandomProperty.HASH, new Dictionary<string, object>());

        Assert.Equal("da39a3ee5e6b4b0d3255bfef95601890afd80709", result);
        _adapterMock.Verify(v => v.Hash(40, false), Times.Once);
    }

    [Fact]
    public void Generate_Hash_WithLengthAndUppercaseParams_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Hash(8, true)).Returns("DA39A3EE");

        var parameters = new Dictionary<string, object>
        {
            { RandomDatasetService.PARAM_LENGTH, "8" },
            { RandomDatasetService.PARAM_UPPERCASE, "true" }
        };

        var result = _service.Generate(RandomProperty.HASH, parameters);

        Assert.Equal("DA39A3EE", result);
        _adapterMock.Verify(v => v.Hash(8, true), Times.Once);
    }

    [Fact]
    public void Generate_Hexadecimal_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.Hexadecimal(1, "0x")).Returns("0xA");

        var result = _service.Generate(RandomProperty.HEXADECIMAL, new Dictionary<string, object>());

        Assert.Equal("0xA", result);
        _adapterMock.Verify(v => v.Hexadecimal(1, "0x"), Times.Once);
    }

    [Fact]
    public void Generate_AlphaNumeric_ShouldCallAdapterWithDefaultLength()
    {
        _adapterMock.Setup(s => s.AlphaNumeric(10)).Returns("a1b2c3d4e5");

        var result = _service.Generate(RandomProperty.ALPHANUMERIC, new Dictionary<string, object>());

        Assert.Equal("a1b2c3d4e5", result);
        _adapterMock.Verify(v => v.AlphaNumeric(10), Times.Once);
    }

    [Fact]
    public void Generate_Replace_ShouldCallAdapterWithDefaultFormat()
    {
        _adapterMock.Setup(s => s.Replace("???")).Returns("abc");

        var result = _service.Generate(RandomProperty.REPLACE, new Dictionary<string, object>());

        Assert.Equal("abc", result);
        _adapterMock.Verify(v => v.Replace("???"), Times.Once);
    }

    [Fact]
    public void Generate_Replace_WithFormatParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Replace("??-##")).Returns("ab-12");

        var parameters = new Dictionary<string, object> { { RandomDatasetService.PARAM_FORMAT, "??-##" } };

        var result = _service.Generate(RandomProperty.REPLACE, parameters);

        Assert.Equal("ab-12", result);
        _adapterMock.Verify(v => v.Replace("??-##"), Times.Once);
    }

    [Fact]
    public void Generate_ReplaceNumbers_ShouldCallAdapterWithDefaults()
    {
        _adapterMock.Setup(s => s.ReplaceNumbers("###", '#')).Returns("123");

        var result = _service.Generate(RandomProperty.REPLACE_NUMBERS, new Dictionary<string, object>());

        Assert.Equal("123", result);
        _adapterMock.Verify(v => v.ReplaceNumbers("###", '#'), Times.Once);
    }

    [Fact]
    public void Generate_Word_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Word()).Returns("hello");

        var result = _service.Generate(RandomProperty.WORD, new Dictionary<string, object>());

        Assert.Equal("hello", result);
        _adapterMock.Verify(v => v.Word(), Times.Once);
    }

    [Fact]
    public void Generate_Words_ShouldCallAdapterWithDefaultCount()
    {
        _adapterMock.Setup(s => s.Words(1)).Returns("hello");

        var result = _service.Generate(RandomProperty.WORDS, new Dictionary<string, object>());

        Assert.Equal("hello", result);
        _adapterMock.Verify(v => v.Words(1), Times.Once);
    }

    [Fact]
    public void Generate_Words_WithCountParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Words(3)).Returns("hello world foo");

        var parameters = new Dictionary<string, object> { { RandomDatasetService.PARAM_COUNT, "3" } };

        var result = _service.Generate(RandomProperty.WORDS, parameters);

        Assert.Equal("hello world foo", result);
        _adapterMock.Verify(v => v.Words(3), Times.Once);
    }

    [Fact]
    public void Generate_RandomLocale_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.RandomLocale()).Returns("en_US");

        var result = _service.Generate(RandomProperty.RANDOM_LOCALE, new Dictionary<string, object>());

        Assert.Equal("en_US", result);
        _adapterMock.Verify(v => v.RandomLocale(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
