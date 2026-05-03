using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class VehicleFakerAdapter(IFakerService fakerService) : IVehicleFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Vehicle GetFaker() => _fakerService.GetFaker().Vehicle;

    public string Vin(bool strict = false) => GetFaker().Vin(strict);
    public string Manufacturer() => GetFaker().Manufacturer();
    public string Model() => GetFaker().Model();
    public string Type() => GetFaker().Type();
    public string Fuel() => GetFaker().Fuel();
}
