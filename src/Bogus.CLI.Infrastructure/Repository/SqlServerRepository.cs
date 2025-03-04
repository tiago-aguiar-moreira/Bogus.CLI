using Bogus.CLI.Infrastructure.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace Bogus.CLI.Infrastructure.Repository;

public class SqlServerRepository : IRepository
{
    public SqlServerRepository()
    {
        
    }

    //TODO: Before executing, it is necessary to check if the table and fields exist.

    public void InsertBatch(string connectionString, string tableName, List<Dictionary<string, object>> records)
    {
        if (records.Count == 0) return;

        var columns = string.Join(", ", records[0].Keys);
        var parameters = string.Join(", ", records[0].Keys.Select((_, i) => $"@p{i}"));

        var query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        foreach (var record in records)
        {
            using var command = new SqlCommand(query, connection, transaction);
            int paramIndex = 0;

            foreach (var value in record.Values)
            {
                command.Parameters.AddWithValue($"@p{paramIndex++}", value ?? DBNull.Value);
            }

            command.ExecuteNonQuery();
        }

        transaction.Commit();
    }
}
