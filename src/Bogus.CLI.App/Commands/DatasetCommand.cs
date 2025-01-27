using Bogus.CLI.App.Services.Interface;
using Cocona;
using Cocona.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Commands;

[ExcludeFromCodeCoverage]
public static class DatasetCommand
{
    private const string DESCRIPTION_DATASET = "Datasets to produce the desired data, specified in the format <category.property> (e.g., lorem.word).";
    private const string DESCRIPTION_COUNT = "Specifies the number of records to generate. Default is 10.";
    private const string DESCRIPTION_LOCALE = "Defines the locale to use for generating data. Default is 'en'.";
    private const string DESCRIPTION_TEMPLATE = "The template parameter defines a dynamic text model with placeholders to be replaced by specific values. Example syntax: {{name}} or {{0}}.";
    private const string DESCRIPTION_PARAMETERS = "Provides additional parameters for the selected dataset(s), formatted as key-value pairs (e.g., key1=value1;key2=value2).";

    public static CommandConventionBuilder ConfigureDatasetCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("dataset", GetCommand)
        .WithDescription("Datasets customizable fake data using predefined datasets.");

    private static void GetCommand(
        IDatasetService datasetService,
        ITemplateService templateService,
        [Argument(Description = DESCRIPTION_DATASET)] string[] datasets,
        [Option('c', Description = DESCRIPTION_COUNT)] int count = 10,
        [Option('l', Description = DESCRIPTION_LOCALE)] string? locale = null,
        [Option('t', Description = DESCRIPTION_TEMPLATE)] string? template = null,
        [Option('p', Description = DESCRIPTION_PARAMETERS)] string? parameters = null)
    {
        var fakeData = datasetService.ExecuteCommand(
            datasets, count, locale, parameters, out var message);

        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine(message);
            return;
        }

        if (string.IsNullOrEmpty(template))
        {
            foreach (var row in fakeData)
                Console.WriteLine(string.Join(" ", row));

            return;
        }
        
        if (!templateService.SetTemplate(template, out var errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }

        foreach (var row in fakeData)
            Console.WriteLine(templateService.Format(row));
    }
}