using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;
public class FinanceDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<IFinanceFakerAdapter> _financeAdapterMock;
    private readonly IFinanceDatasetService _financeDatasetService;

    public FinanceDatasetServiceTests()
    {
        _financeAdapterMock = new Mock<IFinanceFakerAdapter>();
        _financeDatasetService = new FinanceDatasetService(_financeAdapterMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Fact]
    public void GenerateAccountName_ShouldCallAccountName()
    {
        _financeAdapterMock.Setup(s => s.AccountName()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.ACCOUNT_NAME, _parameters);
        _financeAdapterMock.Verify(v => v.AccountName(), Times.Once());
    }

    [Fact]
    public void GenerateTransactionType_ShouldCallTransactionType()
    {
        _financeAdapterMock.Setup(s => s.TransactionType()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.TRANSACTION_TYPE, _parameters);
        _financeAdapterMock.Verify(v => v.TransactionType(), Times.Once());
    }

    [Fact]
    public void GenerateCreditCardCvv_ShouldCallCreditCardCvv()
    {
        _financeAdapterMock.Setup(s => s.CreditCardCvv()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.CREDIT_CARD_CVV, _parameters);
        _financeAdapterMock.Verify(v => v.CreditCardCvv(), Times.Once());
    }

    [Fact]
    public void GenerateBitcoinAddress_ShouldCallBitcoinAddress()
    {
        _financeAdapterMock.Setup(s => s.BitcoinAddress()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.BITCOIN_ADDRESS, _parameters);
        _financeAdapterMock.Verify(v => v.BitcoinAddress(), Times.Once());
    }

    [Fact]
    public void GenerateEthereumAddress_ShouldCallEthereumAddress()
    {
        _financeAdapterMock.Setup(s => s.EthereumAddress()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.ETHEREUM_ADDRESS, _parameters);
        _financeAdapterMock.Verify(v => v.EthereumAddress(), Times.Once());
    }

    [Fact]
    public void GenerateRoutingNumber_ShouldCallRoutingNumber()
    {
        _financeAdapterMock.Setup(s => s.RoutingNumber()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.ROUTING_NUMBER, _parameters);
        _financeAdapterMock.Verify(v => v.RoutingNumber(), Times.Once());
    }

    [Fact]
    public void GenerateBic_ShouldCallBic()
    {
        _financeAdapterMock.Setup(s => s.Bic()).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.BIC, _parameters);
        _financeAdapterMock.Verify(v => v.Bic(), Times.Once());
    }

    [Theory]
    [InlineData(6)]
    [InlineData(12)]
    public void GenerateAccount_WithLength_ShouldCallAccountWithLength(int length)
    {
        _parameters.AddParameter(FinanceDatasetService.PARAM_LENGTH, length);
        _financeAdapterMock.Setup(s => s.Account(It.IsAny<int>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.ACCOUNT, _parameters);
        _financeAdapterMock.Verify(v => v.Account(length), Times.Once());
    }

    [Fact]
    public void GenerateAccount_WithoutParams_ShouldUseDefault()
    {
        _financeAdapterMock.Setup(s => s.Account(It.IsAny<int>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.ACCOUNT, _parameters);
        _financeAdapterMock.Verify(v => v.Account(8), Times.Once());
    }

    [Theory]
    [InlineData("10", "500", 2)]
    [InlineData("0", "9999", 0)]
    public void GenerateAmount_WithParams_ShouldPassParams(string min, string max, int decimals)
    {
        _parameters.AddParameter(FinanceDatasetService.PARAM_MIN, min);
        _parameters.AddParameter(FinanceDatasetService.PARAM_MAX, max);
        _parameters.AddParameter(FinanceDatasetService.PARAM_DECIMALS, decimals);
        _financeAdapterMock.Setup(s => s.Amount(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.AMOUNT, _parameters);
        _financeAdapterMock.Verify(v => v.Amount(decimal.Parse(min), decimal.Parse(max), decimals), Times.Once());
    }

    [Fact]
    public void GenerateAmount_WithoutParams_ShouldUseDefaults()
    {
        _financeAdapterMock.Setup(s => s.Amount(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.AMOUNT, _parameters);
        _financeAdapterMock.Verify(v => v.Amount(0, 1000, 2), Times.Once());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GenerateCurrency_WithReturnCode_ShouldPassFlag(bool returnCode)
    {
        _parameters.AddParameter(FinanceDatasetService.PARAM_RETURN_CODE, returnCode);
        _financeAdapterMock.Setup(s => s.Currency(It.IsAny<bool>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.CURRENCY, _parameters);
        _financeAdapterMock.Verify(v => v.Currency(returnCode), Times.Once());
    }

    [Fact]
    public void GenerateCurrency_WithoutParams_ShouldUseDefault()
    {
        _financeAdapterMock.Setup(s => s.Currency(It.IsAny<bool>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.CURRENCY, _parameters);
        _financeAdapterMock.Verify(v => v.Currency(false), Times.Once());
    }

    [Theory]
    [InlineData("visa")]
    [InlineData("mastercard")]
    [InlineData("amex")]
    public void GenerateCreditCardNumber_WithCardType_ShouldPassCardType(string cardType)
    {
        _parameters.AddParameter(FinanceDatasetService.PARAM_CARD_TYPE, cardType);
        _financeAdapterMock.Setup(s => s.CreditCardNumber(It.IsAny<string>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.CREDIT_CARD_NUMBER, _parameters);
        _financeAdapterMock.Verify(v => v.CreditCardNumber(cardType), Times.Once());
    }

    [Fact]
    public void GenerateCreditCardNumber_WithoutParams_ShouldUseDefault()
    {
        _financeAdapterMock.Setup(s => s.CreditCardNumber(It.IsAny<string>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.CREDIT_CARD_NUMBER, _parameters);
        _financeAdapterMock.Verify(v => v.CreditCardNumber("all"), Times.Once());
    }

    [Theory]
    [InlineData(true, "BR")]
    [InlineData(false, "US")]
    public void GenerateIban_WithParams_ShouldPassParams(bool formatted, string countryCode)
    {
        _parameters.AddParameter(FinanceDatasetService.PARAM_FORMATTED, formatted);
        _parameters.AddParameter(FinanceDatasetService.PARAM_COUNTRY_CODE, countryCode);
        _financeAdapterMock.Setup(s => s.Iban(It.IsAny<bool>(), It.IsAny<string?>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.IBAN, _parameters);
        _financeAdapterMock.Verify(v => v.Iban(formatted, countryCode), Times.Once());
    }

    [Fact]
    public void GenerateIban_WithoutParams_ShouldUseDefaults()
    {
        _financeAdapterMock.Setup(s => s.Iban(It.IsAny<bool>(), It.IsAny<string?>())).Returns(string.Empty);
        _ = _financeDatasetService.Generate(FinanceProperty.IBAN, _parameters);
        _financeAdapterMock.Verify(v => v.Iban(false, null), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void Generate_InvalidProperty_ReturnsNull(string property)
    {
        var result = _financeDatasetService.Generate(property, _parameters);
        Assert.Null(result);
    }
}
