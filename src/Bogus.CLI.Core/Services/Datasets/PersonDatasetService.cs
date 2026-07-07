using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class PersonDatasetService(IPersonFakerAdapter personAdapter) : IPersonDatasetService
{
    private readonly IPersonFakerAdapter _personAdapter = personAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        PersonProperty.FIRST_NAME => _personAdapter.FirstName(),
        PersonProperty.LAST_NAME => _personAdapter.LastName(),
        PersonProperty.FULL_NAME => _personAdapter.FullName(),
        PersonProperty.GENDER => _personAdapter.Gender(),
        PersonProperty.USER_NAME => _personAdapter.UserName(),
        PersonProperty.AVATAR => _personAdapter.Avatar(),
        PersonProperty.EMAIL => _personAdapter.Email(),
        PersonProperty.PHONE => _personAdapter.Phone(),
        PersonProperty.WEBSITE => _personAdapter.Website(),
        PersonProperty.DATE_OF_BIRTH => _personAdapter.DateOfBirth(),
        _ => null
    };
}
