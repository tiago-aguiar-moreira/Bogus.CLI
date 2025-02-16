using Bogus.CLI.Core.Datasets.Interfaces;
using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Datasets;

[ExcludeFromCodeCoverage]
public class PhoneDataset(IFakerService fakerService) : IPhoneDataset
{
    private readonly IFakerService _fakerService = fakerService;

    private PhoneNumbers GetFaker() => _fakerService.GetFaker().Phone;

    public string PhoneNumber(string? format = null)
        => GetFaker().PhoneNumber(format);

    public string PhoneNumberFormat(int phoneFormatsArrayIndex = 0)
        => GetFaker().PhoneNumberFormat(phoneFormatsArrayIndex);
}