namespace Bogus.CLI.App.Services.Interface;
public interface IFakeDataPhoneService
{
    string? Generate(string property, Dictionary<string, object> parameters);
}