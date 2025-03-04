namespace Bogus.CLI.Core.Services.Interface;
public interface IParserDatasetLoremService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}