namespace Bogus.CLI.Core.Services.Interface;
public interface ICompanyDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
