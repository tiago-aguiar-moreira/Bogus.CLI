using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services;

[ExcludeFromCodeCoverage]
public class DatasetPhoneService(IFakerService fakerService) : IDatasetPhoneService
{
    private readonly IFakerService _fakerService = fakerService;

    private PhoneNumbers GetFaker() => _fakerService.GetFaker().Phone;

    public string PhoneNumber(string? format = null)
        => GetFaker().PhoneNumber(format);

    public string PhoneNumberFormat(int phoneFormatsArrayIndex = 0)
        => GetFaker().PhoneNumberFormat(phoneFormatsArrayIndex);
}