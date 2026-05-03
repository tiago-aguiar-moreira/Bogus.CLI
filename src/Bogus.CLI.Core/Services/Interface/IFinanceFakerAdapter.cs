namespace Bogus.CLI.Core.Services.Interface;
public interface IFinanceFakerAdapter
{
    string Account(int length = 8);
    string AccountName();
    string Amount(decimal min = 0, decimal max = 1000, int decimals = 2);
    string TransactionType();
    string Currency(bool returnCode = false);
    string CreditCardNumber(string cardType = "all");
    string CreditCardCvv();
    string BitcoinAddress();
    string EthereumAddress();
    string RoutingNumber();
    string Bic();
    string Iban(bool formatted = false, string? countryCode = null);
}
