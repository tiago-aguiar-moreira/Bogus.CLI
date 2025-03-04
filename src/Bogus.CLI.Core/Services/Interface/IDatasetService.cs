namespace Bogus.CLI.Core.Services.Interface;
public interface IDatasetService
{
    void ExecuteCommand(string[] datasets, int count, string? locale, Action<List<(string Value, string Alias)>> onGenerateFakedata);
}