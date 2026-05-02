namespace Bogus.CLI.Core.Services.Interface;
public interface IPhoneFakerAdapter
{
    string PhoneNumber(string? format = null);
    string PhoneNumberFormat(int phoneFormatsArrayIndex = 0);
}