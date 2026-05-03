namespace Bogus.CLI.Core.Services.Interface;
public interface IAddressDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
