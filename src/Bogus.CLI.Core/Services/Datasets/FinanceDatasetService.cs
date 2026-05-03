using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class FinanceDatasetService(IFinanceFakerAdapter financeAdapter) : IFinanceDatasetService
{
    public const string PARAM_LENGTH = "length";
    public const string PARAM_MIN = "min";
    public const string PARAM_MAX = "max";
    public const string PARAM_DECIMALS = "decimals";
    public const string PARAM_RETURN_CODE = "returnCode";
    public const string PARAM_CARD_TYPE = "cardType";
    public const string PARAM_FORMATTED = "formatted";
    public const string PARAM_COUNTRY_CODE = "countryCode";

    private readonly IFinanceFakerAdapter _financeAdapter = financeAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        FinanceProperty.ACCOUNT => GenerateAccount(parameters),
        FinanceProperty.ACCOUNT_NAME => _financeAdapter.AccountName(),
        FinanceProperty.AMOUNT => GenerateAmount(parameters),
        FinanceProperty.TRANSACTION_TYPE => _financeAdapter.TransactionType(),
        FinanceProperty.CURRENCY => GenerateCurrency(parameters),
        FinanceProperty.CREDIT_CARD_NUMBER => GenerateCreditCardNumber(parameters),
        FinanceProperty.CREDIT_CARD_CVV => _financeAdapter.CreditCardCvv(),
        FinanceProperty.BITCOIN_ADDRESS => _financeAdapter.BitcoinAddress(),
        FinanceProperty.ETHEREUM_ADDRESS => _financeAdapter.EthereumAddress(),
        FinanceProperty.ROUTING_NUMBER => _financeAdapter.RoutingNumber(),
        FinanceProperty.BIC => _financeAdapter.Bic(),
        FinanceProperty.IBAN => GenerateIban(parameters),
        _ => null
    };

    private string GenerateAccount(IDictionary<string, object> parameters)
    {
        var length = parameters.ConvertToInt(PARAM_LENGTH, 8);
        return _financeAdapter.Account(length);
    }

    private string GenerateAmount(IDictionary<string, object> parameters)
    {
        var min = parameters.ConvertToDecimal(PARAM_MIN, 0);
        var max = parameters.ConvertToDecimal(PARAM_MAX, 1000);
        var decimals = parameters.ConvertToInt(PARAM_DECIMALS, 2);
        return _financeAdapter.Amount(min, max, decimals);
    }

    private string GenerateCurrency(IDictionary<string, object> parameters)
    {
        var returnCode = parameters.ConvertToBool(PARAM_RETURN_CODE, false);
        return _financeAdapter.Currency(returnCode);
    }

    private string GenerateCreditCardNumber(IDictionary<string, object> parameters)
    {
        var cardType = parameters.ConvertToString(PARAM_CARD_TYPE, "all");
        return _financeAdapter.CreditCardNumber(cardType);
    }

    private string GenerateIban(IDictionary<string, object> parameters)
    {
        var formatted = parameters.ConvertToBool(PARAM_FORMATTED, false);
        var countryCode = parameters.ConvertToString(PARAM_COUNTRY_CODE, string.Empty);
        return _financeAdapter.Iban(formatted, string.IsNullOrEmpty(countryCode) ? null : countryCode);
    }
}
