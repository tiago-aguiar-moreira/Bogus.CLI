using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class CommerceDatasetService(ICommerceFakerAdapter commerceAdapter) : ICommerceDatasetService
{
    public const string PARAM_MAX = "max";
    public const string PARAM_RETURN_MAX = "returnMax";
    public const string PARAM_MIN = "min";
    public const string PARAM_DECIMALS = "decimals";
    public const string PARAM_SYMBOL = "symbol";
    public const string PARAM_NUM = "num";
    public const string PARAM_SEPARATOR = "separator";

    private readonly ICommerceFakerAdapter _commerceAdapter = commerceAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        CommerceProperty.DEPARTMENT => GenerateDepartment(parameters),
        CommerceProperty.PRICE => GeneratePrice(parameters),
        CommerceProperty.CATEGORIES => GenerateCategories(parameters),
        CommerceProperty.PRODUCT_NAME => _commerceAdapter.ProductName(),
        CommerceProperty.COLOR => _commerceAdapter.Color(),
        CommerceProperty.PRODUCT => _commerceAdapter.Product(),
        CommerceProperty.PRODUCT_ADJECTIVE => _commerceAdapter.ProductAdjective(),
        CommerceProperty.PRODUCT_MATERIAL => _commerceAdapter.ProductMaterial(),
        CommerceProperty.PRODUCT_DESCRIPTION => _commerceAdapter.ProductDescription(),
        CommerceProperty.EAN8 => _commerceAdapter.Ean8(),
        CommerceProperty.EAN13 => _commerceAdapter.Ean13(),
        _ => null
    };

    private string GenerateDepartment(IDictionary<string, object> parameters)
    {
        var max = parameters.ConvertToInt(PARAM_MAX, 1);
        var returnMax = parameters.ConvertToBool(PARAM_RETURN_MAX, false);
        return _commerceAdapter.Department(max, returnMax);
    }

    private string GeneratePrice(IDictionary<string, object> parameters)
    {
        var min = parameters.ConvertToDecimal(PARAM_MIN, 1);
        var max = parameters.ConvertToDecimal(PARAM_MAX, 1000);
        var decimals = parameters.ConvertToInt(PARAM_DECIMALS, 2);
        var symbol = parameters.ConvertToString(PARAM_SYMBOL, string.Empty);
        return _commerceAdapter.Price(min, max, decimals, symbol);
    }

    private string GenerateCategories(IDictionary<string, object> parameters)
    {
        var num = parameters.ConvertToInt(PARAM_NUM, 1);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, ", ");
        return string.Join(separator, _commerceAdapter.Categories(num));
    }
}
