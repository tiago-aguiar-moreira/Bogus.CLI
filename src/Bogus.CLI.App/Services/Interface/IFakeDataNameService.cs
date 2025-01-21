namespace Bogus.CLI.App.Services.Interface;
public interface IFakeDataNameService
{
    string? Generate(string property, Dictionary<string, object> parameters);
}