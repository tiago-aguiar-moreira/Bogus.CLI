using Bogus.CLI.App.Services.Interface;
using Cocona;
using Cocona.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Commands;

[ExcludeFromCodeCoverage]
public static class ListLocaleCommand
{
    public static CommandConventionBuilder ConfigureListLocaleCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("list-locales", GetCommand)
        .WithDescription("Lists all available locales.");

    private static void GetCommand(IListLocaleService listLocaleService)
    {
        var locales = listLocaleService.ExecuteCommand();
        var headers = new string[] { "CODE", "DESCRIPTION" };

        DrawTable(headers, [.. locales.OrderBy(o => o.Description)]);
    }

    static void DrawTable(string[] headers, IList<(string Code, string Description)> rows)
    {
        var codeWidth = Math.Max(headers[0].Length, rows.Max(r => r.Code.Length));
        var descWidth = Math.Max(headers[1].Length, rows.Max(r => r.Description.Length));

        // Draw the top line
        DrawLine(codeWidth, descWidth);

        // Draw the header
        DrawRow(headers[0], headers[1], codeWidth, descWidth);

        // Separator line
        DrawLine(codeWidth, descWidth);
        
        foreach (var (code, description) in rows)
            DrawRow(code, description, codeWidth, descWidth);

        // Draw the bottom line
        DrawLine(codeWidth, descWidth);
    }

    static void DrawLine(int codeWidth, int descWidth)
        => Console.WriteLine($"+{new string('-', codeWidth + 2)}+{new string('-', descWidth + 2)}+");

    static void DrawRow(string code, string description, int codeWidth, int descWidth)
        => Console.WriteLine($"| {code.PadRight(codeWidth)} | {description.PadRight(descWidth)} |");
}