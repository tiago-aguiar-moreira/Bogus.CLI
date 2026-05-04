namespace Bogus.CLI.Core.Services.Interface;
public interface IRandomDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
