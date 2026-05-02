using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;
using static Bogus.DataSets.Name;

namespace Bogus.CLI.Core.Services;
public class NameDatasetService(INameFakerAdapter nameAdapter) : INameDatasetService
{
    private const string PARAM_GENDER = "gender";
    private const string PARAM_GENDER_MALE = "male";
    private const string PARAM_GENDER_FEMALE = "female";
    private const string PARAM_FIRST_NAME = "firstName";
    private const string PARAM_LAST_NAME = "lastName";
    private const string PARAM_WITH_PREFIX = "withPrefix";
    private const string PARAM_WITH_SUFIX = "withSuffix";

    private readonly INameFakerAdapter _nameAdapter = nameAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        NameProperty.FIRST_NAME => GenerateFirstName(parameters),
        NameProperty.LAST_NAME => GenerateLastName(parameters),
        NameProperty.FULL_NAME => GenerateFullName( parameters),
        NameProperty.PREFIX => GeneratePrefix(parameters),
        NameProperty.SUFFIX => _nameAdapter.Suffix(),
        NameProperty.FIND_NAME => GenerateFindName(parameters),
        NameProperty.JOB_TITLE => _nameAdapter.JobTitle(),
        NameProperty.JOB_DESCRIPTOR => _nameAdapter.JobDescriptor(),
        NameProperty.JOB_AREA => _nameAdapter.JobArea(),
        NameProperty.JOB_TYPE => _nameAdapter.JobType(),
        _ => null
    };

    private string GenerateFirstName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameAdapter.FirstName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameAdapter.FirstName(Gender.Female),
            _ => _nameAdapter.FirstName(),
        };
    }

    private string GenerateLastName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameAdapter.LastName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameAdapter.LastName(Gender.Female),
            _ => _nameAdapter.LastName(),
        };
    }

    private string GenerateFullName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameAdapter.FullName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameAdapter.FullName(Gender.Female),
            _ => _nameAdapter.FullName(),
        };
    }

    private string GeneratePrefix(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameAdapter.Prefix(Gender.Male),
            PARAM_GENDER_FEMALE => _nameAdapter.Prefix(Gender.Female),
            _ => _nameAdapter.Prefix(),
        };
    }

    private string GenerateFindName(IDictionary<string, object> parameters)
    {
        var firstName = parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty);
        var lastName = parameters.ConvertToString(PARAM_LAST_NAME, string.Empty);
        var withPrefix = parameters.ConvertToBool(PARAM_WITH_PREFIX, null);
        var withSuffix = parameters.ConvertToBool(PARAM_WITH_SUFIX, null);

        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameAdapter.FindName(
                firstName, lastName, withPrefix, withSuffix, Gender.Male),
            PARAM_GENDER_FEMALE => _nameAdapter.FindName(
                firstName, lastName, withPrefix, withSuffix, Gender.Female),
            _ => _nameAdapter.FindName(
                firstName, lastName, withPrefix, withSuffix),
        };
    }
}