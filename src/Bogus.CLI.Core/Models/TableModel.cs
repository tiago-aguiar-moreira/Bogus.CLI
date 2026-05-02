namespace Bogus.CLI.Core.Models;
public class TableModel
{
    public string TableName { get; set; } = string.Empty;
    public int RecordsCount { get; set; }
    public int BatchSize { get; set; }
    public List<Field> Fields { get; set; } = [];
}
