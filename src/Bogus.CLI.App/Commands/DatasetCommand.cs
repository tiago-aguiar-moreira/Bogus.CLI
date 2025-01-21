using Bogus.CLI.App.Services.Interface;
using Cocona;
using Cocona.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Commands;

[ExcludeFromCodeCoverage]
public static class DatasetCommand
{
    public static CommandConventionBuilder ConfigureDatasetCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("dataset", GetCommand)
        .WithDescription("Datasets customizable fake data using predefined datasets.");

    private static void GetCommand(
        IDatasetService datasetService,
        [Argument(Description = "Datasets to produce the desired data, specified in the format <category.property> (e.g., lorem.word).")]
        string[] datasets,
        [Option('c', Description = "Specifies the number of records to generate. Default is 10.")]
        int count = 10,
        [Option('l', Description = "Defines the locale to use for generating data. Default is 'en'.")]
        string? locale = null,
        [Option('p', Description = "Provides additional parameters for the selected dataset(s), formatted as key-value pairs (e.g., key1=value1;key2=value2).")]
        string? parameters = null)
    {
        var fakeData = datasetService.ExecuteCommand(
            datasets, count, locale, parameters, out var message);

        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine(message);
            return;
        }

        foreach (var row in fakeData)
            Console.WriteLine(string.Join(" ", row));
    }
}