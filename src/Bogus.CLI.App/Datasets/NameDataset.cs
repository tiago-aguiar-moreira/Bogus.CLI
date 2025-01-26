using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;
using static Bogus.DataSets.Name;

namespace Bogus.CLI.App.Datasets;

[ExcludeFromCodeCoverage]
public class NameDataset(IFakerService fakerService) : INameDataset
{
    private readonly IFakerService _fakerService = fakerService;

    private Name GetFaker() => _fakerService.GetFaker().Name;

    public string FirstName(Gender? gender = null)
        => GetFaker().FirstName(gender);

    public string LastName(Gender? gender = null)
        => GetFaker().LastName(gender);

    public string FullName(Gender? gender = null)
        => GetFaker().FullName(gender);
    
    public string Prefix(Gender? gender = null)
        => GetFaker().Prefix(gender);
    
    public string Suffix() => GetFaker().Suffix();
    
    public string FindName(string firstName = "", string lastName = "", bool? withPrefix = null, bool? withSuffix = null, Gender? gender = null)
        => GetFaker().FindName(firstName, lastName, withPrefix, withSuffix, gender);
    
    public string JobTitle() => GetFaker().JobTitle();
    
    public string JobDescriptor() => GetFaker().JobDescriptor();
    
    public string JobArea() => GetFaker().JobArea();
    
    public string JobType() => GetFaker().JobType();
}