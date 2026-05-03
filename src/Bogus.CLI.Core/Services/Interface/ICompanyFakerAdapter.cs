namespace Bogus.CLI.Core.Services.Interface;
public interface ICompanyFakerAdapter
{
    string CompanySuffix();
    string CompanyName(int? formatIndex = null);
    string CatchPhrase();
    string Bs();
}
