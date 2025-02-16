namespace Bogus.CLI.Core.Services.Interface;
public interface IListDatasetService
{
    IList<string> ExecuteCommand(string? datasetName);
}