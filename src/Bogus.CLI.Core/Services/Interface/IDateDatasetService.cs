namespace Bogus.CLI.Core.Services.Interface;
public interface IDateDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
