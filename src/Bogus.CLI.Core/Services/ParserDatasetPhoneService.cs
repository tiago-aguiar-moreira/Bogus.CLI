using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services;
public class ParserDatasetPhoneService(IDatasetPhoneService phoneDataset) : IParserDatasetPhoneService
{
    public const string PARAM_FORMAT = "format";
    public const string PARAM_PHONE_FORMATS_ARRAY_INDEX = "formatIndex";

    private readonly IDatasetPhoneService _phoneDataset = phoneDataset;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        PhoneProperty.NUMBER => GeneratePhoneNumber(parameters),
        PhoneProperty.FORMAT => GeneratePhoneNumberFormat(parameters),
        _ => null
    };

    private string GeneratePhoneNumber(IDictionary<string, object> parameters)
    {
        var format = parameters.ConvertToString(PARAM_FORMAT, null!);
        
        return _phoneDataset.PhoneNumber(format);
    }

    private string GeneratePhoneNumberFormat(IDictionary<string, object> parameters)
    {
        var phoneFormatsArrayIndex = parameters.ConvertToInt(PARAM_PHONE_FORMATS_ARRAY_INDEX, 0);

        return _phoneDataset.PhoneNumberFormat(phoneFormatsArrayIndex);
    }
}