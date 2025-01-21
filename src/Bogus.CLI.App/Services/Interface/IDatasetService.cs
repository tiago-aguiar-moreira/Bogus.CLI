namespace Bogus.CLI.App.Services.Interface;
public interface IDatasetService
{
    List<List<string>> ExecuteCommand(string[] datasets, int count, string? locale, string? parameters, out string message);
}