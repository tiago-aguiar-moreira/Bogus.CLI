namespace Bogus.CLI.Core.Services.Interface;
public interface IDatasetService
{
    List<List<(string Value, string Alias)>> ExecuteCommand(string[] datasets, int count, string? locale, out string message);
}