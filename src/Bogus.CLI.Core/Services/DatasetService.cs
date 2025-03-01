﻿using CONST = Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services;
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

    public List<List<(string Value, string Alias)>> ExecuteCommand(
        string[] datasets, int count, string? locale, out string message)
    {
        // Controls the randomness of the values generated by the Bogus library.
        Randomizer.Seed = new Random();

        _fakerService.LocaleCode = locale ?? string.Empty;

        var results = new List<List<(string DatasetValue, string Alias)>>();

        if (count <= 0)
        {
            message = "The option --count must be greater than 1.";
            return results;
        }

        // Pre-processing: validation and extraction of information from datasets.
        var datasetInfos = new List<(
            string DatasetName,
            string PropertyName,
            string Alias,
            IDictionary<string, object> Parameters)>();

        foreach (var dataset in datasets)
        {
            if (!_datasetHelper.TryParseDataset(
                dataset, out string datasetName, out string propertyName, out string alias, out var parameters))
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

            datasetInfos.Add((datasetName, propertyName, alias, parameters));
        }

        // Main processing
        for (int i = 0; i < count; i++)
        {
            var row = new List<(string Value, string Alias)>();
            foreach (var (datasetName, propertyName, alias, parameters) in datasetInfos)
            {
                var value = Generate(datasetName, propertyName, parameters);

                if (string.IsNullOrEmpty(value))
                {
                    message = $"Dataset or property unknown: {datasetName}.{propertyName}";
                    return results;
                }

                row.Add((Value: value, Alias: alias));
            }

            results.Add(row);
        }

        message = string.Empty;
        return results;
    }

    private string? Generate(
        string datasetName, string propertyName, IDictionary<string, object> parameters) => datasetName switch
    {
        CONST.Datasets.LOREM => _fakeDataLoremService.Generate(propertyName, parameters),
        CONST.Datasets.NAME => _fakeDataNameService.Generate(propertyName, parameters),
        CONST.Datasets.PHONE => _fakeDataPhoneService.Generate(propertyName, parameters),
        _ => null
    };
}
