namespace Bogus.CLI.Core.Services.Interface;
public interface IHackerDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
