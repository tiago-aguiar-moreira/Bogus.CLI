namespace Bogus.CLI.Core.Services.Interface;
public interface IPhoneDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}