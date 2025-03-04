namespace Bogus.CLI.Core.Services.Interface;
public interface IParserDatasetPhoneService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}