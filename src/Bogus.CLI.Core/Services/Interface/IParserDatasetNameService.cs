namespace Bogus.CLI.Core.Services.Interface;
public interface IParserDatasetNameService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}