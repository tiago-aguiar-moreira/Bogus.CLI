using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class VehicleDatasetServiceTests
{
    private readonly VehicleDatasetService _service;
    private readonly Mock<IVehicleFakerAdapter> _adapterMock;

    public VehicleDatasetServiceTests()
    {
        _adapterMock = new Mock<IVehicleFakerAdapter>();
        _service = new VehicleDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Vin_ShouldCallAdapterWithStrictFalse()
    {
        _adapterMock.Setup(s => s.Vin(false)).Returns("1HGBH41JXMN109186");

        var result = _service.Generate(VehicleProperty.VIN, new Dictionary<string, object>());

        Assert.Equal("1HGBH41JXMN109186", result);
        _adapterMock.Verify(v => v.Vin(false), Times.Once);
    }

    [Fact]
    public void Generate_Vin_WithStrictParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Vin(true)).Returns("1HGBH41JXMN109186");

        var parameters = new Dictionary<string, object>
        {
            { VehicleDatasetService.PARAM_STRICT, "true" }
        };

        var result = _service.Generate(VehicleProperty.VIN, parameters);

        Assert.Equal("1HGBH41JXMN109186", result);
        _adapterMock.Verify(v => v.Vin(true), Times.Once);
    }

    [Fact]
    public void Generate_Manufacturer_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Manufacturer()).Returns("Toyota");

        var result = _service.Generate(VehicleProperty.MANUFACTURER, new Dictionary<string, object>());

        Assert.Equal("Toyota", result);
        _adapterMock.Verify(v => v.Manufacturer(), Times.Once);
    }

    [Fact]
    public void Generate_Model_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Model()).Returns("Camry");

        var result = _service.Generate(VehicleProperty.MODEL, new Dictionary<string, object>());

        Assert.Equal("Camry", result);
        _adapterMock.Verify(v => v.Model(), Times.Once);
    }

    [Fact]
    public void Generate_Type_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Type()).Returns("SUV");

        var result = _service.Generate(VehicleProperty.TYPE, new Dictionary<string, object>());

        Assert.Equal("SUV", result);
        _adapterMock.Verify(v => v.Type(), Times.Once);
    }

    [Fact]
    public void Generate_Fuel_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Fuel()).Returns("Electric");

        var result = _service.Generate(VehicleProperty.FUEL, new Dictionary<string, object>());

        Assert.Equal("Electric", result);
        _adapterMock.Verify(v => v.Fuel(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
