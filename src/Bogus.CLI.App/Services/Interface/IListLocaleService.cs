namespace Bogus.CLI.App.Services.Interface;
public interface IListLocaleService
{
    IList<(string Code, string Description)> ExecuteCommand();
}