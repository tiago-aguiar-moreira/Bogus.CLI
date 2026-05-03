using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class RantFakerAdapter(IFakerService fakerService) : IRantFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Rant GetFaker() => _fakerService.GetFaker().Rant;

    public string Review(string product = "") => GetFaker().Review(product);
    public string[] Reviews(string product = "", int lines = 1) => GetFaker().Reviews(product, lines);
}
