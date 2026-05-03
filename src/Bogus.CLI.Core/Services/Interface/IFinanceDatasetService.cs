namespace Bogus.CLI.Core.Services.Interface;
public interface IFinanceDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
