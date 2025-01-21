using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Extensions;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class FakeDataPhoneService(IFakerService fakerService) : IFakeDataPhoneService
{
    private const string PARAM_FORMAT = "format";

    private readonly IFakerService _fakerService = fakerService;

    public string? Generate(string property, Dictionary<string, object> parameters) => property switch
    {
        PhoneProperty.NUMBER => GeneratePhoneNumber(parameters),
        PhoneProperty.FORMAT => GeneratePhoneNumberFormat(),
        _ => null
    };

    private string GeneratePhoneNumber(Dictionary<string, object> parameters)
    {
        var format = parameters.ConvertToString(PARAM_FORMAT, string.Empty);
        
        if(!string.IsNullOrEmpty(format))
            return _fakerService.Phone.PhoneNumber(format);

        return _fakerService.Phone.PhoneNumber();
    }

    private string GeneratePhoneNumberFormat()
        => _fakerService.Phone.PhoneNumberFormat();
}