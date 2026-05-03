using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class HackerFakerAdapter(IFakerService fakerService) : IHackerFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Hacker GetFaker() => _fakerService.GetFaker().Hacker;

    public string Abbreviation() => GetFaker().Abbreviation();
    public string Adjective() => GetFaker().Adjective();
    public string Noun() => GetFaker().Noun();
    public string Verb() => GetFaker().Verb();
    public string IngVerb() => GetFaker().IngVerb();
    public string Phrase() => GetFaker().Phrase();
}
