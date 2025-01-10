using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.App.Commands;
public static class FakeDataPhone
{
    private const string PARAM_FORMAT = "format";

    public static string? Generate(Faker faker, string property, Dictionary<string, object> parameters) => property switch
    {
        PhoneProperty.NUMBER => GeneratePhoneNumber(faker, parameters),
        PhoneProperty.FORMAT => GeneratePhoneNumberFormat(faker),
        _ => null
    };

    private static string GeneratePhoneNumber(Faker faker, Dictionary<string, object> parameters)
    {
        var format = parameters.ConvertToString(PARAM_FORMAT, string.Empty);
        
        if(!string.IsNullOrEmpty(format))
            return faker.Phone.PhoneNumber(format);

        return faker.Phone.PhoneNumber();
    }

    private static string GeneratePhoneNumberFormat(Faker faker)
        => faker.Phone.PhoneNumberFormat();
}