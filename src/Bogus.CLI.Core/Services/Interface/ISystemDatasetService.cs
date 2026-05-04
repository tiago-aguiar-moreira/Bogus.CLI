namespace Bogus.CLI.Core.Services.Interface;
public interface ISystemDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
