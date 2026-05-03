namespace Bogus.CLI.Core.Services.Interface;
public interface IInternetDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
