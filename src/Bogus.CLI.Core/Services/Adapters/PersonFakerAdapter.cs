using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class PersonFakerAdapter(IFakerService fakerService) : IPersonFakerAdapter
{
    private const string DATE_FORMAT = "yyyy-MM-dd";

    private readonly IFakerService _fakerService = fakerService;

    private Person GetFaker() => _fakerService.GetFaker().Person;

    public string FirstName() => GetFaker().FirstName;
    public string LastName() => GetFaker().LastName;
    public string FullName() => GetFaker().FullName;
    public string Gender() => GetFaker().Gender.ToString();
    public string UserName() => GetFaker().UserName;
    public string Avatar() => GetFaker().Avatar;
    public string Email() => GetFaker().Email;
    public string Phone() => GetFaker().Phone;
    public string Website() => GetFaker().Website;
    public string DateOfBirth() => GetFaker().DateOfBirth.ToString(DATE_FORMAT);
}
