using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class CompanyFakerAdapter(IFakerService fakerService) : ICompanyFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Company GetFaker() => _fakerService.GetFaker().Company;

    public string CompanySuffix() => GetFaker().CompanySuffix();
    public string CompanyName(int? formatIndex = null) => GetFaker().CompanyName(formatIndex);
    public string CatchPhrase() => GetFaker().CatchPhrase();
    public string Bs() => GetFaker().Bs();
}
