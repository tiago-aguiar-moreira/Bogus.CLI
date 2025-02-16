namespace Bogus.CLI.Core.Services.Interface;
public interface IListLocaleService
{
    IList<(string Code, string Description)> ExecuteCommand();
}