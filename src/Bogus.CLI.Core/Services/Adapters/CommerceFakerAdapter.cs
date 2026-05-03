using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class CommerceFakerAdapter(IFakerService fakerService) : ICommerceFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Commerce GetFaker() => _fakerService.GetFaker().Commerce;

    public string Department(int max = 1, bool returnMax = false) => GetFaker().Department(max, returnMax);

    public string Price(decimal min = 1, decimal max = 1000, int decimals = 2, string symbol = "")
        => GetFaker().Price(min, max, decimals, symbol);

    public string[] Categories(int num = 1) => GetFaker().Categories(num);

    public string ProductName() => GetFaker().ProductName();

    public string Color() => GetFaker().Color();

    public string Product() => GetFaker().Product();

    public string ProductAdjective() => GetFaker().ProductAdjective();

    public string ProductMaterial() => GetFaker().ProductMaterial();

    public string ProductDescription() => GetFaker().ProductDescription();

    public string Ean8() => GetFaker().Ean8();

    public string Ean13() => GetFaker().Ean13();
}
