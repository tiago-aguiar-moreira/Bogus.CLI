using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.App.Commands;
public static class FakeDataName
{
    private const string PARAM_GENDER = "gender";
    private const string PARAM_GENDER_MALE = "male";
    private const string PARAM_GENDER_FEMALE = "female";
    private const string PARAM_FIRST_NAME = "firstName";
    private const string PARAM_LAST_NAME = "lastName";
    private const string PARAM_WITH_PREFIX = "withPrefix";
    private const string PARAM_WITH_SUFIX = "withSuffix";

    public static string? Generate(
        Faker faker,
        string property,
        Dictionary<string, object> parameters) => property switch
    {
        NameProperty.FIRST_NAME => GenerateFirstName(faker, parameters),
        NameProperty.LAST_NAME => GenerateLastName(faker, parameters),
        NameProperty.FULL_NAME => GenerateFullName(faker, parameters),
        NameProperty.PREFIX => GeneratePrefix(faker, parameters),
        NameProperty.SUFFIX => faker.Name.Suffix(),
        NameProperty.FIND_NAME => GenerateFindName(faker, parameters),
        NameProperty.JOB_TITLE => faker.Name.JobTitle(),
        NameProperty.JOB_DESCRIPTOR => faker.Name.JobDescriptor(),
        NameProperty.JOB_AREA => faker.Name.JobArea(),
        NameProperty.JOB_TYPE => faker.Name.JobType(),
        _ => null
    };

    private static string GenerateFirstName(Faker faker, Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => faker.Name.FirstName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => faker.Name.FirstName(DataSets.Name.Gender.Female),
            _ => faker.Name.FirstName(),
        };
    }

    private static string GenerateLastName(Faker faker, Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => faker.Name.LastName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => faker.Name.LastName(DataSets.Name.Gender.Female),
            _ => faker.Name.LastName(),
        };
    }

    private static string GenerateFullName(Faker faker, Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => faker.Name.FullName(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => faker.Name.FullName(DataSets.Name.Gender.Female),
            _ => faker.Name.FullName(),
        };
    }

    private static string GeneratePrefix(Faker faker, Dictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => faker.Name.Prefix(DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => faker.Name.Prefix(DataSets.Name.Gender.Female),
            _ => faker.Name.Prefix(),
        };
    }

    private static string GenerateFindName(Faker faker, Dictionary<string, object> parameters)
    {
        var firstName = parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty);
        var lastName = parameters.ConvertToString(PARAM_LAST_NAME, string.Empty);
        var withPrefix = parameters.ConvertToBool(PARAM_WITH_PREFIX, null);
        var withSuffix = parameters.ConvertToBool(PARAM_WITH_SUFIX, null);

        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => faker.Name.FindName(
                firstName, lastName, withPrefix, withSuffix, DataSets.Name.Gender.Male),
            PARAM_GENDER_FEMALE => faker.Name.FindName(
                firstName, lastName, withPrefix, withSuffix, DataSets.Name.Gender.Female),
            _ => faker.Name.FindName(
                firstName, lastName, withPrefix, withSuffix),
        };
    }
}