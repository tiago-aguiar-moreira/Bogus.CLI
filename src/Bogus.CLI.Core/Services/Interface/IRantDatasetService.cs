namespace Bogus.CLI.Core.Services.Interface;
public interface IRantDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
