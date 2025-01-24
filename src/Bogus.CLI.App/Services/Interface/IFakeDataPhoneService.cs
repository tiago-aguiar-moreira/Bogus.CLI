namespace Bogus.CLI.App.Services.Interface;
public interface IFakeDataPhoneService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}