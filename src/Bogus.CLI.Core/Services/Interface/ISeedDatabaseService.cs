using Bogus.CLI.App.Commands.DatasetFile.CommandModels;

namespace Bogus.CLI.Core.Services.Interface;
public interface ISeedDatabaseService
{
    bool ExecuteCommand(
        SeedFileModel seedFile,
        Action<(int TotalRecordsRequested, int TotalRecordsInserted, string TableName, int TotalTables, int TotalTablesProcessed, int RecordsRequested, int RecordsInserted)> onInsert);
}
