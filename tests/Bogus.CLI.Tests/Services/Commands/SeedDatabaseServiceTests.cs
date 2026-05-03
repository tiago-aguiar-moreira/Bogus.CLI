using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Models;
using Bogus.CLI.Core.Services.Commands;
using Bogus.CLI.Core.Services.Interface;
using Bogus.CLI.Infrastructure.Repository.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Commands;
public class SeedDatabaseServiceTests
{
    private readonly Mock<IDatasetService> _datasetServiceMock;
    private readonly Mock<IRepository> _repositoryMock;
    private readonly SeedDatabaseService _seedDatabaseService;

    public SeedDatabaseServiceTests()
    {
        _datasetServiceMock = new Mock<IDatasetService>();
        _repositoryMock = new Mock<IRepository>();
        _seedDatabaseService = new SeedDatabaseService(_datasetServiceMock.Object, _repositoryMock.Object);

        _datasetServiceMock
            .Setup(s => s.ExecuteCommand(
                It.IsAny<string[]>(),
                It.IsAny<int>(),
                It.IsAny<string?>(),
                It.IsAny<Action<List<(string Value, string Alias)>>>()))
            .Callback<string[], int, string?, Action<List<(string Value, string Alias)>>>(
                (datasets, _, _, onGenerate) =>
                    onGenerate(datasets.Select(d => ("fake_value", d)).ToList()));
    }

    [Fact]
    public void ExecuteCommand_ShouldReturnTrue()
    {
        // Arrange
        var seedFile = BuildSeedFile(tables: [BuildTable(recordsCount: 1, batchSize: 10)]);

        // Act
        var result = _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ExecuteCommand_SingleTable_RecordsFitInOneBatch_ShouldCallInsertBatchOnce()
    {
        // Arrange
        var seedFile = BuildSeedFile(tables: [BuildTable(recordsCount: 3, batchSize: 10)]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        _repositoryMock.Verify(v => v.InsertBatch(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<List<Dictionary<string, object>>>()), Times.Once);
    }

    [Theory]
    [InlineData(7, 3, 3)]
    [InlineData(10, 4, 3)]
    [InlineData(6, 2, 3)]
    public void ExecuteCommand_SingleTable_RecordsSpanMultipleBatches_ShouldCallInsertBatchPerBatch(
        int recordsCount, int batchSize, int expectedBatches)
    {
        // Arrange
        var seedFile = BuildSeedFile(tables: [BuildTable(recordsCount, batchSize)]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        _repositoryMock.Verify(v => v.InsertBatch(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<List<Dictionary<string, object>>>()), Times.Exactly(expectedBatches));
    }

    [Fact]
    public void ExecuteCommand_MultipleTables_ShouldCallInsertBatchForEachTable()
    {
        // Arrange
        var seedFile = BuildSeedFile(tables:
        [
            BuildTable(recordsCount: 2, batchSize: 10, tableName: "users"),
            BuildTable(recordsCount: 3, batchSize: 10, tableName: "orders"),
        ]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        _repositoryMock.Verify(v => v.InsertBatch(
            It.IsAny<string>(), "users", It.IsAny<List<Dictionary<string, object>>>()), Times.Once);
        _repositoryMock.Verify(v => v.InsertBatch(
            It.IsAny<string>(), "orders", It.IsAny<List<Dictionary<string, object>>>()), Times.Once);
    }

    [Fact]
    public void ExecuteCommand_ShouldPassLocaleToDatasetService()
    {
        // Arrange
        var seedFile = BuildSeedFile(locale: LocaleCodes.PORTUGUESE_BRAZIL, tables: [BuildTable(recordsCount: 1, batchSize: 10)]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        _datasetServiceMock.Verify(v => v.ExecuteCommand(
            It.IsAny<string[]>(),
            It.IsAny<int>(),
            LocaleCodes.PORTUGUESE_BRAZIL,
            It.IsAny<Action<List<(string Value, string Alias)>>>()), Times.Once);
    }

    [Fact]
    public void ExecuteCommand_ShouldPassFieldDatasetsToDatasetService()
    {
        // Arrange
        var fields = new List<Field>
        {
            new() { FieldName = "name", Dataset = "name.firstName" },
            new() { FieldName = "phone", Dataset = "phone.number" },
        };
        var seedFile = BuildSeedFile(tables: [BuildTable(recordsCount: 1, batchSize: 10, fields: fields)]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, _ => { });

        // Assert
        _datasetServiceMock.Verify(v => v.ExecuteCommand(
            new[] { "name.firstName", "phone.number" },
            It.IsAny<int>(),
            It.IsAny<string?>(),
            It.IsAny<Action<List<(string Value, string Alias)>>>()), Times.Once);
    }

    [Fact]
    public void ExecuteCommand_ShouldInvokeOnInsertWithCorrectTotals()
    {
        // Arrange
        var calls = new List<(int TotalRequested, int TotalInserted)>();
        var seedFile = BuildSeedFile(tables:
        [
            BuildTable(recordsCount: 3, batchSize: 10, tableName: "users"),
            BuildTable(recordsCount: 2, batchSize: 10, tableName: "orders"),
        ]);

        // Act
        _seedDatabaseService.ExecuteCommand(seedFile, args =>
            calls.Add((args.TotalRecordsRequested, args.TotalRecordsInserted)));

        // Assert
        Assert.Equal(2, calls.Count);
        Assert.All(calls, c => Assert.Equal(5, c.TotalRequested));
        Assert.Equal(3, calls[0].TotalInserted);
        Assert.Equal(5, calls[1].TotalInserted);
    }

    private static SeedFileModel BuildSeedFile(
        List<TableModel>? tables = null,
        string? locale = null) => new()
    {
        Locale = locale,
        Database = new DatabaseModel { ConnectionString = "Server=test" },
        Tables = tables ?? [],
    };

    private static TableModel BuildTable(
        int recordsCount,
        int batchSize,
        string tableName = "test_table",
        List<Field>? fields = null) => new()
    {
        TableName = tableName,
        RecordsCount = recordsCount,
        BatchSize = batchSize,
        Fields = fields ?? [new Field { FieldName = "col", Dataset = "lorem.word" }],
    };
}
