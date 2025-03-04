namespace Bogus.CLI.Infrastructure.Repository.Interface;
public interface IRepository
{
    void InsertBatch(string connectionString, string tableName, List<Dictionary<string, object>> records);
}
