using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Extensions;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class FakeDataNameService(IFakerService fakerService) : IFakeDataNameService
{
    private const string PARAM_GENDER = "gender";
    private const string PARAM_GENDER_MALE = "male";
    private const string PARAM_GENDER_FEMALE = "female";
    private const string PARAM_FIRST_NAME = "firstName";
    private const string PARAM_LAST_NAME = "lastName";
    private const string PARAM_WITH_PREFIX = "withPrefix";
    private const string PARAM_WITH_SUFIX = "withSuffix";
    
    private readonly IFakerService _fakerService = fakerService;

    public string? Generate(string property, Dictionary<string, object> parameters) => property switch
    {
        NameProperty.FIRST_NAME => GenerateFirstName(parameters),
        NameProperty.LAST_NAME => GenerateLastName(parameters),
        NameProperty.FULL_NAME => GenerateFullName( parameters),
        NameProperty.PREFIX => GeneratePrefix(parameters),
        NameProperty.SUFFIX => _fakerService.Name.Suffix(),
        NameProperty.FIND_NAME => GenerateFindName(parameters),
        NameProperty.JOB_TITLE => _fakerService.Name.JobTitle(),
        NameProperty.JOB_DESCRIPTOR => _fakerService.Name.JobDescriptor(),
        NameProperty.JOB_AREA => _fakerService.Name.JobArea(),
        NameProperty.JOB_TYPE => _fakerService.Name.JobType(),
        _ => null
    };

    private string GenerateFirstName(Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _fakerService.Name.FirstName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => _fakerService.Name.FirstName(DataSets.Name.Gender.Female),
            _ => _fakerService.Name.FirstName(),
        };
    }

    private string GenerateLastName(Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _fakerService.Name.LastName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => _fakerService.Name.LastName(DataSets.Name.Gender.Female),
            _ => _fakerService.Name.LastName(),
        };
    }

    private string GenerateFullName(Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _fakerService.Name.FullName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => _fakerService.Name.FullName(DataSets.Name.Gender.Female),
            _ => _fakerService.Name.FullName(),
        };
    }

    private string GeneratePrefix(Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _fakerService.Name.Prefix(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => _fakerService.Name.Prefix(DataSets.Name.Gender.Female),
            _ => _fakerService.Name.Prefix(),
        };
    }

    private string GenerateFindName(Dictionary<string, object> parameters)
    {
        var firstName = parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty);
        var lastName = parameters.ConvertToString(PARAM_LAST_NAME, string.Empty);
        var withPrefix = parameters.ConvertToBool(PARAM_WITH_PREFIX, null);
        var withSuffix = parameters.ConvertToBool(PARAM_WITH_SUFIX, null);

        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _fakerService.Name.FindName(
                firstName, lastName, withPrefix, withSuffix, DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => _fakerService.Name.FindName(
                firstName, lastName, withPrefix, withSuffix, DataSets.Name.Gender.Female),
            _ => _fakerService.Name.FindName(
                firstName, lastName, withPrefix, withSuffix),
        };
    }
}