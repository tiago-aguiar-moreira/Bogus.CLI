﻿using Bogus.CLI.App.Constants;
using Cocona;
using Cocona.Builder;

namespace Bogus.CLI.App.Commands;
public static class GenerateCommand
{
    public static CommandConventionBuilder AddGenerateCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("generate", GetCommand)
        .WithDescription("Generates customizable fake data using predefined generators.");

    private static void GetCommand(
        [Argument(Description = "Generators to produce the desired data, specified in the format <category.property> (e.g., lorem.word).")]
        string[] generators,
        [Option('c', Description = "Specifies the number of records to generate. Default is 10.")]
        int count = 10,
        [Option('l', Description = "Defines the locale to use for generating data. Default is 'en'.")]
        string? locale = null,
        [Option('p', Description = "Provides additional parameters for the selected generator(s), formatted as key-value pairs (e.g., key1=value1;key2=value2).")]
        string? parameters = null)
    {
        // Controls the randomness of the values generated by the Bogus library.
        Randomizer.Seed = new Random();

        var faker = string.IsNullOrEmpty(locale) ? new Faker() : new Faker(locale);
        var results = new List<List<string>>();
        var parsedParams = ParseParameters(parameters);

        for (int i = 0; i < count; i++)
        {
            var row = new List<string>();
            foreach (var generator in generators)
            {
                if (TryGetCategoryAndProperty(generator, out var category, out var property))
                {
                    Console.WriteLine($"Invalid format for generator: {generator}. Use <generator.sub-option>.");
                    return;
                }

                var value = GetFakeData(faker, category, property, parsedParams);

                if (value != null)
                    row.Add(value);
                else
                    Console.WriteLine($"Generator or sub-option unknown: {generator}");
            }

            results.Add(row);
        }

        foreach (var row in results)
            Console.WriteLine(string.Join(" ", row));
    }

    private static bool TryGetCategoryAndProperty(string generator, out string category, out string property)
    {
        var parts = generator.Split('.');
        if (parts.Length != 2)
        {
            category = string.Empty;
            property = string.Empty;
            return false;
        }

        category = parts[0].ToLower();
        property = parts[1].ToLower();
        return true;
    }

    private static Dictionary<string, object> ParseParameters(string? parameters)
    {
        var parsed = new Dictionary<string, object>();

        if (string.IsNullOrWhiteSpace(parameters))
            return parsed;
        
        var splitParams = parameters.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var param in splitParams)
        {
            var keyValue = param.Split('=');
            if (keyValue.Length == 2)
                parsed[keyValue[0].ToLower()] = keyValue[1];
        }

        return parsed;
    }

    private static string? GetFakeData(
        Faker faker,
        string category,
        string property,
        Dictionary<string, object> parameters) => category switch
    {
        Categories.LOREM => FakeDataLorem.Generate(faker, property, parameters),
        Categories.PHONE => FakeDataPhone.Generate(faker, property, parameters),
        Categories.NAME => FakeDataName.Generate(faker, property, parameters),
        _ => null,
    };
}