using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class FinanceFakerAdapter(IFakerService fakerService) : IFinanceFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Finance GetFaker() => _fakerService.GetFaker().Finance;

    public string Account(int length = 8) => GetFaker().Account(length);

    public string AccountName() => GetFaker().AccountName();

    public string Amount(decimal min = 0, decimal max = 1000, int decimals = 2)
        => GetFaker().Amount(min, max, decimals).ToString();

    public string TransactionType() => GetFaker().TransactionType();

    public string Currency(bool returnCode = false)
    {
        var currency = GetFaker().Currency();
        return returnCode ? currency.Code : currency.Description;
    }

    public string CreditCardNumber(string cardType = "all")
    {
        CardType? type = cardType.ToLower() switch
        {
            "visa" => CardType.Visa,
            "mastercard" => CardType.Mastercard,
            "discover" => CardType.Discover,
            "amex" or "americanexpress" => CardType.AmericanExpress,
            "dinersclub" => CardType.DinersClub,
            "jcb" => CardType.Jcb,
            "switch" => CardType.Switch,
            _ => null
        };
        return GetFaker().CreditCardNumber(type!);
    }

    public string CreditCardCvv() => GetFaker().CreditCardCvv();

    public string BitcoinAddress() => GetFaker().BitcoinAddress();

    public string EthereumAddress() => GetFaker().EthereumAddress();

    public string RoutingNumber() => GetFaker().RoutingNumber();

    public string Bic() => GetFaker().Bic();

    public string Iban(bool formatted = false, string? countryCode = null)
        => GetFaker().Iban(formatted, countryCode);
}
