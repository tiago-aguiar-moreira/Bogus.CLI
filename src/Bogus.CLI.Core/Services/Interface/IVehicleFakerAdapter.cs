namespace Bogus.CLI.Core.Services.Interface;
public interface IVehicleFakerAdapter
{
    string Vin(bool strict = false);
    string Manufacturer();
    string Model();
    string Type();
    string Fuel();
}
