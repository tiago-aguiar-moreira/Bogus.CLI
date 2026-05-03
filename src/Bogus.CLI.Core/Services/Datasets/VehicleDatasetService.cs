using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class VehicleDatasetService(IVehicleFakerAdapter vehicleAdapter) : IVehicleDatasetService
{
    public const string PARAM_STRICT = "strict";

    private readonly IVehicleFakerAdapter _vehicleAdapter = vehicleAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        VehicleProperty.VIN => _vehicleAdapter.Vin(parameters.ConvertToBool(PARAM_STRICT, false)),
        VehicleProperty.MANUFACTURER => _vehicleAdapter.Manufacturer(),
        VehicleProperty.MODEL => _vehicleAdapter.Model(),
        VehicleProperty.TYPE => _vehicleAdapter.Type(),
        VehicleProperty.FUEL => _vehicleAdapter.Fuel(),
        _ => null
    };
}
