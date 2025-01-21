using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class FakerService : IFakerService
{
    private string? _language = null;
    private Faker? _faker = null;
    
    public DataSets.Lorem Lorem => GetFaker().Lorem;
    public DataSets.Name Name => GetFaker().Name;
    public DataSets.PhoneNumbers Phone => GetFaker().Phone;

    public void SetLanguage(string? language)
        => _language = language;

    private Faker GetFaker()
    {
        _faker = string.IsNullOrEmpty(_language)
            ? new Faker() 
            : new Faker(_language);

        return _faker!;
    }
}