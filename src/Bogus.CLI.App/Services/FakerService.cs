using Bogus.CLI.App.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Services;

[ExcludeFromCodeCoverage]
public class FakerService : IFakerService
{
    private string? _language = null;
    
    public DataSets.Lorem Lorem => GetFaker().Lorem;
    public DataSets.Name Name => GetFaker().Name;
    public DataSets.PhoneNumbers Phone => GetFaker().Phone;
    
    public void SetLanguage(string? language)
        => _language = language;

    private Faker GetFaker() => string.IsNullOrEmpty(_language)
        ? new Faker() 
        : new Faker(_language);


}