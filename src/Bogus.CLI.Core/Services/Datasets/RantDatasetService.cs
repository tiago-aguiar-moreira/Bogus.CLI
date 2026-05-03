using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class RantDatasetService(IRantFakerAdapter rantAdapter) : IRantDatasetService
{
    public const string PARAM_PRODUCT = "product";
    public const string PARAM_LINES = "lines";
    public const string PARAM_SEPARATOR = "separator";

    private readonly IRantFakerAdapter _rantAdapter = rantAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        RantProperty.REVIEW => _rantAdapter.Review(parameters.ConvertToString(PARAM_PRODUCT, string.Empty)),
        RantProperty.REVIEWS => GenerateReviews(parameters),
        _ => null
    };

    private string GenerateReviews(IDictionary<string, object> parameters)
    {
        var product = parameters.ConvertToString(PARAM_PRODUCT, string.Empty);
        var lines = parameters.ConvertToInt(PARAM_LINES, 1);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, ", ");
        return string.Join(separator, _rantAdapter.Reviews(product, lines));
    }
}
