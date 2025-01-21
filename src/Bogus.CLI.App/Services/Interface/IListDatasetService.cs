namespace Bogus.CLI.App.Services.Interface;
public interface IListDatasetService
{
    IList<string> ExecuteCommand(string? datasetName);
}