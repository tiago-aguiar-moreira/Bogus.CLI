namespace Bogus.CLI.Core.Services.Interface;
public interface ICommerceDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
