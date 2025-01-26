﻿using CONST = Bogus.CLI.App.Constants;
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

        _fakerService.LocaleCode = locale ?? string.Empty;

        var results = new List<List<string>>();
        if (!_datasetHelper.TryParseParameters(parameters, out var parsedParams))
        {
            message = "Sorry, but there is an issue with the parameters option. Please check.";
            return results;
        }

        if (count <= 0)
        {
            message = "The option --count must be greater than 1.";
            return results;
        }

        // Pré-processamento: validação e extração de informações dos datasets
        var datasetInfos = new List<(
            string DatasetName, string PropertyName, Func<string, IDictionary<string, object>, string?> Generator)>();

        foreach (var dataset in datasets)
        {
            if (!_datasetHelper.TryParseDatasetAndProperty(dataset, out string datasetName, out string propertyName))
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

            // Define a função geradora para o dataset atual
            Func<string, IDictionary<string, object>, string?> generator = datasetName switch
            {
                CONST.Datasets.LOREM => _fakeDataLoremService.Generate,
                CONST.Datasets.NAME => _fakeDataNameService.Generate,
                CONST.Datasets.PHONE => _fakeDataPhoneService.Generate,
                _ => (_, _) => null
            };

            if (generator == null)
            {
                message = $"Dataset or property unknown: {datasetName}.{propertyName}";
                return results;
            }

            datasetInfos.Add((datasetName, propertyName, generator));
        }

        // Processamento principal
        for (int i = 0; i < count; i++)
        {
            var row = new List<string>();
            foreach (var (_, propertyName, generator) in datasetInfos)
            {
                var value = generator(propertyName, parsedParams);
                row.Add(value ?? string.Empty);
            }

            results.Add(row);
        }

        message = string.Empty;
        return results;
    }
}
