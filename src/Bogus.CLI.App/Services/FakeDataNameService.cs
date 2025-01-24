using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Extensions;
using Bogus.CLI.App.Services.Interface;
using static Bogus.DataSets.Name;

namespace Bogus.CLI.App.Services;
public class FakeDataNameService(INameDataset nameDataset) : IFakeDataNameService
{
    private const string PARAM_GENDER = "gender";
    private const string PARAM_GENDER_MALE = "male";
    private const string PARAM_GENDER_FEMALE = "female";
    private const string PARAM_FIRST_NAME = "firstName";
    private const string PARAM_LAST_NAME = "lastName";
    private const string PARAM_WITH_PREFIX = "withPrefix";
    private const string PARAM_WITH_SUFIX = "withSuffix";
    
    private readonly INameDataset _nameDataset = nameDataset;

    public string? Generate(string property, IDictionary<string, object> parameters) => property switch
    {
        NameProperty.FIRST_NAME => GenerateFirstName(parameters),
        NameProperty.LAST_NAME => GenerateLastName(parameters),
        NameProperty.FULL_NAME => GenerateFullName( parameters),
        NameProperty.PREFIX => GeneratePrefix(parameters),
        NameProperty.SUFFIX => _nameDataset.Suffix(),
        NameProperty.FIND_NAME => GenerateFindName(parameters),
        NameProperty.JOB_TITLE => _nameDataset.JobTitle(),
        NameProperty.JOB_DESCRIPTOR => _nameDataset.JobDescriptor(),
        NameProperty.JOB_AREA => _nameDataset.JobArea(),
        NameProperty.JOB_TYPE => _nameDataset.JobType(),
        _ => null
    };

    private string GenerateFirstName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameDataset.FirstName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameDataset.FirstName(Gender.Female),
            _ => _nameDataset.FirstName(),
        };
    }

    private string GenerateLastName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameDataset.LastName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameDataset.LastName(Gender.Female),
            _ => _nameDataset.LastName(),
        };
    }

    private string GenerateFullName(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameDataset.FullName(Gender.Male),
            PARAM_GENDER_FEMALE => _nameDataset.FullName(Gender.Female),
            _ => _nameDataset.FullName(),
        };
    }

    private string GeneratePrefix(IDictionary<string, object> parameters)
    {
        return parameters.ConvertToString(PARAM_GENDER, string.Empty) switch
        {
            PARAM_GENDER_MALE => _nameDataset.Prefix(Gender.Male),
            PARAM_GENDER_FEMALE => _nameDataset.Prefix(Gender.Female),
            _ => _nameDataset.Prefix(),
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
            PARAM_GENDER_MALE => _nameDataset.FindName(
                firstName, lastName, withPrefix, withSuffix, Gender.Male),
            PARAM_GENDER_FEMALE => _nameDataset.FindName(
                firstName, lastName, withPrefix, withSuffix, Gender.Female),
            _ => _nameDataset.FindName(
                firstName, lastName, withPrefix, withSuffix),
        };
    }
}