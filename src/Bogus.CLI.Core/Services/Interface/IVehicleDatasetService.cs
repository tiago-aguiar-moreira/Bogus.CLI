namespace Bogus.CLI.Core.Services.Interface;
public interface IVehicleDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
