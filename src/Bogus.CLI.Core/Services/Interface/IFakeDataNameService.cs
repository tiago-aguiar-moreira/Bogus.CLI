namespace Bogus.CLI.Core.Services.Interface;
public interface IFakeDataNameService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}