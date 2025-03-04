using Bogus.CLI.App.Commands.DatasetFile.CommandModels;
using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Services.Interface;
using Bogus.CLI.Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Bogus.CLI.Core.Services;
public class SeedDatabaseService(
    IDatasetService datasetService,
    [FromKeyedServices(Databases.SQL_SERVER)] IRepository repository) : ISeedDatabaseService
{
    private readonly IDatasetService _datasetService = datasetService;
    private readonly IRepository _repository = repository;

    public bool ExecuteCommand(
        SeedFileModel seedFile,
        Action<(
            int TotalRecordsRequested,
            int TotalRecordsInserted,
            string TableName,
            int TotalTables,
            int TotalTablesProcessed,
            int RecordsRequested,
            int RecordsInserted)> onInsert)
    {
        var totalRecordsRequested = seedFile.Tables.Sum(s => s.RecordsCount);
        var totalRecordsInserted = 0;
        var totalTablesProcessed = 0;

        foreach (var table in seedFile.Tables)
        {
            totalTablesProcessed++;

            for (int batch = 0; batch < table.RecordsCount; batch += table.BatchSize)
            {
                var records = Enumerable.Range(0, table.BatchSize)
                    .Where(i => batch + i < table.RecordsCount)
                    .Select(_ =>
                    {
                        var record = new Dictionary<string, object>();

                        _datasetService.ExecuteCommand(
                            table.Fields.Select(f => f.Dataset).ToArray(),
                            table.BatchSize,
                            seedFile.Locale,
                            generatedValues =>
                            {
                                for (int j = 0; j < table.Fields.Count; j++)
                                {
                                    record[table.Fields[j].FieldName] = generatedValues[j].Value;
                                }
                            });

                        return record;
                    }).ToList();

                _repository.InsertBatch(
                    seedFile.Database.GetConnectionString(), table.TableName, records);

                totalRecordsInserted += records.Count;

                onInsert((
                    TotalRecordsRequested: totalRecordsRequested,
                    TotalRecordsInserted: totalRecordsInserted,
                    TableName: table.TableName,
                    TotalTables: seedFile.Tables.Count,
                    TotalTablesProcessed: totalTablesProcessed,
                    RecordsRequested: table.RecordsCount,
                    RecordsInserted: batch + records.Count));
            }
        }

        return true;
    }
}
