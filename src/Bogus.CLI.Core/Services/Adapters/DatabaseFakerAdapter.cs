using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class DatabaseFakerAdapter(IFakerService fakerService) : IDatabaseFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    public string Column() => _fakerService.GetFaker().Database.Column();
    public string Type() => _fakerService.GetFaker().Database.Type();
    public string Collation() => _fakerService.GetFaker().Database.Collation();
    public string Engine() => _fakerService.GetFaker().Database.Engine();
}
