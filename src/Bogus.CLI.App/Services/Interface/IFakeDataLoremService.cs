namespace Bogus.CLI.App.Services.Interface;
public interface IFakeDataLoremService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}