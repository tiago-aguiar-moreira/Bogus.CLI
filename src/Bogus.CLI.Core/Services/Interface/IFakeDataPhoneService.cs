namespace Bogus.CLI.Core.Services.Interface;
public interface IFakeDataPhoneService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}