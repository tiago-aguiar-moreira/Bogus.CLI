namespace Bogus.CLI.Core.Models;
public class SeedFileModel
{
    public string? Locale { get; set; }
    public DatabaseModel Database { get; set; } = new();
    public List<TableModel> Tables { get; set; } = [];
}
