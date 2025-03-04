using Bogus.CLI.Core.Services.Interface;
using Cocona;
using Cocona.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Commands.ListDataset;

[ExcludeFromCodeCoverage]
public static class ListDatasetCommand
{
    public static CommandConventionBuilder ConfigureListDatasetCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("list-datasets", GetCommand)
        .WithDescription("Lists all available dataset's category.");

    private static void GetCommand(
        IListDatasetService listDatasetService,
        [Option('d', Description = "")] string? datasetName)
    {
        var datasets = listDatasetService.ExecuteCommand(datasetName);

        if (!string.IsNullOrEmpty(datasetName))
        {
            if (datasets.Count > 0)
            {
                foreach (var property in datasets)
                    Console.WriteLine($"- {property}");

                return;
            }

            Console.WriteLine($"Dataset {datasetName} not found. Check complete list.");

            return;
        }

        foreach (var dataset in datasets)
            Console.WriteLine($"- {dataset}");
    }
}
