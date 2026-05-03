namespace Bogus.CLI.Core.Services.Interface;
public interface IDatabaseDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
