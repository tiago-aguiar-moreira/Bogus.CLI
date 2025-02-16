using static Bogus.DataSets.Name;

namespace Bogus.CLI.Core.Datasets.Interfaces;
public interface INameDataset
{
    public string FirstName(Gender? gender = null);
    string LastName(Gender? gender = null);
    string FullName(Gender? gender = null);
    string Prefix(Gender? gender = null);
    string Suffix();
    string FindName(string firstName = "", string lastName = "", bool? withPrefix = null, bool? withSuffix = null, Gender? gender = null);
    string JobTitle();
    string JobDescriptor();
    string JobArea();
    string JobType();
}