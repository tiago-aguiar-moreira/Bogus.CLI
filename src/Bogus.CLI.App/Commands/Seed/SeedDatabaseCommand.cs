using Bogus.CLI.App.Commands.DatasetFile.CommandModels;
using Bogus.CLI.Core.Services.Interface;
using Cocona;
using Cocona.Builder;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Bogus.CLI.App.Commands.DatasetFile;

[ExcludeFromCodeCoverage]
public static class SeedDatabaseCommand
{
    #region CONSTANTS

    private const string DESCRIPTION_COMMAND = "Reads a YAML file containing the definition of mock data and inserts the records into the database according to the specified configuration.";
    private const string DESCRIPTION_DATASETPATH = "Path to the YAML file that contains the configuration for the data to be generated and inserted into the database.";

    #endregion

    public static CommandConventionBuilder ConfigureDatasetFileCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("seed-database", GetCommand)
        .WithDescription(DESCRIPTION_COMMAND);

    private static void GetCommand(
        ISeedDatabaseService datasetFileService,
        [Argument(Description = DESCRIPTION_DATASETPATH)] string filePath)
    {
        Console.WriteLine($"[{GetTimestampFormatted()}] Process started.");
        Console.WriteLine($"[{GetTimestampFormatted()}] Reading configurations from file: \"{Path.GetFileName(filePath)}\"...");

        SeedFileModel seedFile;

        try
        {
            seedFile = ReadSeedFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{GetTimestampFormatted()}] Failed to read configuration file.");
            Console.WriteLine($"[{GetTimestampFormatted()}] Error: {ex.Message}");
            return;
        }

        Console.WriteLine($"[{GetTimestampFormatted()}] Configurations successfully loaded. Starting database insertions...");

        if (datasetFileService.ExecuteCommand(seedFile, OnInsert))
            Console.WriteLine($"[{GetTimestampFormatted()}] Process completed successfully.");
        else
            Console.WriteLine($"[{GetTimestampFormatted()}] Process failed during database insertion.");
    }

    private static SeedFileModel ReadSeedFile(string filePath)
    {
        using var stream = File.OpenRead(filePath);

        return JsonSerializer.Deserialize<SeedFileModel>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    private static void OnInsert((int TotalRecordsRequested, int TotalRecordsInserted, string TableName, int TotalTables, int TotalTablesProcessed, int RecordsRequested, int RecordsInserted) values)
    {
        // Current
        var tableProgressDetails = $"Records inserted: {values.RecordsInserted}/{values.RecordsRequested} ({values.RecordsInserted * 100 / values.RecordsRequested}%)";
        var currentTable = $"[{GetTimestampFormatted()}] Table: {values.TableName} | {tableProgressDetails}";

        // Overall
        var generalProgress = $"Overall: {values.TotalRecordsInserted}/{values.TotalRecordsRequested} ({values.TotalRecordsInserted * 100 / values.TotalRecordsRequested}%)";
        var overallTableProgress = $"Tables: {values.TotalTablesProcessed}/{values.TotalTables} ({values.TotalTablesProcessed * 100 / values.TotalTables}%)";
        var overall = $"{generalProgress} | {overallTableProgress}";

        Console.WriteLine();
        Console.WriteLine(currentTable);
        Console.WriteLine(overall);
    }

    private static string GetTimestampFormatted() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}