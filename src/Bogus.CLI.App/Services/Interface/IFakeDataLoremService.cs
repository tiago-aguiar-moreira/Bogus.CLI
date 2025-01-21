namespace Bogus.CLI.App.Services.Interface;
public interface IFakeDataLoremService
{
    string? Generate(string property, Dictionary<string, object> parameters);
}