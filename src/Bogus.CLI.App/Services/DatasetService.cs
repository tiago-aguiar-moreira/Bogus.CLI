﻿using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Helpers.Interface;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class DatasetService(
    IDatasetHelper datasetHelper,
    IFakerService fakerService,
    IFakeDataLoremService fakeDataLoremService,
    IFakeDataNameService fakeDataNameService,
    IFakeDataPhoneService fakeDataPhoneService) : IDatasetService
{
    private readonly IDatasetHelper _datasetHelper = datasetHelper;
    private readonly IFakerService _fakerService = fakerService;
    private readonly IFakeDataLoremService _fakeDataLoremService = fakeDataLoremService;
    private readonly IFakeDataNameService _fakeDataNameService = fakeDataNameService;
    private readonly IFakeDataPhoneService _fakeDataPhoneService = fakeDataPhoneService;

    public List<List<string>> ExecuteCommand(string[] datasets, int count, string? locale, string? parameters, out string message)
    {
        // Controls the randomness of the values generated by the Bogus library.
        Randomizer.Seed = new Random();

        _fakerService.SetLanguage(locale);

        var results = new List<List<string>>();
        if (!_datasetHelper.TryParseParameters(parameters, out var parsedParams))
        {
            message = $"Sorry, but there is an issue with the parameters option. Please check.";
            return results;
        }

        if (count <= 0)
        {
            message = $"The option --count must be greater than 1.";
            return results;
        }

        for (int i = 0; i < count; i++)
        {
            var row = new List<string>();
            foreach (var dataset in datasets)
            {
                if (!_datasetHelper.TryParseDatasetAndProperty(
                    dataset, out var datasetName, out var propertyName))
                {
                    message = $"Invalid format for dataset: {dataset}. Use <dataset.sub-option>.";
                    return results;
                }

                if (!_datasetHelper.DatasetExists(datasetName))
                {
                    message = $"Dataset '{datasetName}' not found.";
                    return results;
                }

                if (!_datasetHelper.PropertyExists(datasetName, propertyName))
                {
                    message = $"The '{datasetName}' does not contain the property '{propertyName}'.";
                    return results;
                }

                var value = datasetName switch
                {
                    Datasets.LOREM => _fakeDataLoremService.Generate(propertyName, parsedParams),
                    Datasets.NAME => _fakeDataNameService.Generate(propertyName, parsedParams),
                    Datasets.PHONE => _fakeDataPhoneService.Generate(propertyName, parsedParams),
                    _ => null
                };

                if (string.IsNullOrEmpty(value))
                {
                    message = $"Dataset or property unknown: {datasetName}.{propertyName}";
                    return results;
                }

                row.Add(value);
            }

            results.Add(row);
        }

        message = string.Empty;
        return results;
    }


}