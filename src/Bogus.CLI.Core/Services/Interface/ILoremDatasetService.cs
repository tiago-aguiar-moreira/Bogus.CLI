namespace Bogus.CLI.Core.Services.Interface;
public interface ILoremDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}