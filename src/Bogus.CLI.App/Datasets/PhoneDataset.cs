using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Datasets;

[ExcludeFromCodeCoverage]
public class PhoneDataset(IFakerService fakerService) : IPhoneDataset
{
    private readonly PhoneNumbers _phone = fakerService.GetFaker().Phone;

    public string PhoneNumber(string? format = null)
        => _phone.PhoneNumber(format);

    public string PhoneNumberFormat(int phoneFormatsArrayIndex = 0)
        => _phone.PhoneNumberFormat(phoneFormatsArrayIndex);
}