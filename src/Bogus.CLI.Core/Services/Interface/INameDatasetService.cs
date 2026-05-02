namespace Bogus.CLI.Core.Services.Interface;
public interface INameDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}