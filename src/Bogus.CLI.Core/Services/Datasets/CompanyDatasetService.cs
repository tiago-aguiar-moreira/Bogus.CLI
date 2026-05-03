using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class CompanyDatasetService(ICompanyFakerAdapter companyAdapter) : ICompanyDatasetService
{
    public const string PARAM_FORMAT = "format";

    private readonly ICompanyFakerAdapter _companyAdapter = companyAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        CompanyProperty.COMPANY_SUFFIX => _companyAdapter.CompanySuffix(),
        CompanyProperty.COMPANY_NAME => _companyAdapter.CompanyName(parameters.ConvertToInt(PARAM_FORMAT, (int?)null)),
        CompanyProperty.CATCH_PHRASE => _companyAdapter.CatchPhrase(),
        CompanyProperty.BS => _companyAdapter.Bs(),
        _ => null
    };
}
