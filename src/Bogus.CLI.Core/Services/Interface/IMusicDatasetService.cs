namespace Bogus.CLI.Core.Services.Interface;
public interface IMusicDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
