using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Extensions;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class FakeDataPhoneService(IPhoneDataset phoneDataset) : IFakeDataPhoneService
{
    public const string PARAM_FORMAT = "format";

    private readonly IPhoneDataset _phoneDataset = phoneDataset;

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
            return _phoneDataset.PhoneNumber(format);

        return _phoneDataset.PhoneNumber();
    }

    private string GeneratePhoneNumberFormat()
        => _phoneDataset.PhoneNumberFormat();
}