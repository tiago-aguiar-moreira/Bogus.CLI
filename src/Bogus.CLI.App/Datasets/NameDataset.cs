using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;
using static Bogus.DataSets.Name;

namespace Bogus.CLI.App.Datasets;

[ExcludeFromCodeCoverage]
public class NameDataset(IFakerService fakerService) : INameDataset
{
    private readonly Name _name = fakerService.GetFaker().Name;

    public string FirstName(Gender? gender = null)
        => _name.FirstName(gender);

    public string LastName(Gender? gender = null)
        => _name.LastName(gender);

    public string FullName(Gender? gender = null)
        => _name.FullName(gender);
    
    public string Prefix(Gender? gender = null)
        => _name.Prefix(gender);
    
    public string Suffix() => _name.Suffix();
    
    public string FindName(string firstName = "", string lastName = "", bool? withPrefix = null, bool? withSuffix = null, Gender? gender = null)
        => _name.FindName(firstName, lastName, withPrefix, withSuffix, gender);
    
    public string JobTitle() => _name.JobTitle();
    
    public string JobDescriptor() => _name.JobDescriptor();
    
    public string JobArea() => _name.JobArea();
    
    public string JobType() => _name.JobType();
}