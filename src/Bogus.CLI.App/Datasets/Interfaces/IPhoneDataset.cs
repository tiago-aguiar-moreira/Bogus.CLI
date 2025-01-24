namespace Bogus.CLI.App.Datasets.Interfaces;
public interface IPhoneDataset
{
    string PhoneNumber(string? format = null);
    string PhoneNumberFormat(int phoneFormatsArrayIndex = 0);
}