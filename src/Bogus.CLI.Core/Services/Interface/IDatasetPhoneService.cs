namespace Bogus.CLI.Core.Services.Interface;
public interface IDatasetPhoneService
{
    string PhoneNumber(string? format = null);
    string PhoneNumberFormat(int phoneFormatsArrayIndex = 0);
}