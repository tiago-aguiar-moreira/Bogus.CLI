using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class MusicFakerAdapter(IFakerService fakerService) : IMusicFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Music GetFaker() => _fakerService.GetFaker().Music;

    public string Genre() => GetFaker().Genre();
}
