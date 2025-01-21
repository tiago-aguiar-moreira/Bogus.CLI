namespace Bogus.CLI.App.Services.Interface;
public interface IFakerService
{
    DataSets.Lorem Lorem { get; }
    DataSets.Name Name { get; }
    DataSets.PhoneNumbers Phone { get; }
    void SetLanguage(string? language);
}