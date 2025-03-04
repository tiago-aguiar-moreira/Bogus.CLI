using Bogus.CLI.Core.Constants;

namespace Bogus.CLI.App.Commands.DatasetFile.CommandModels;
public class DatabaseModel
{
    public string Type { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool TrustServerCertificate { get; set; } = false;

    public string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(ConnectionString))
            return ConnectionString;

        return Type switch
        {
            Databases.SQL_SERVER => $"Server={Host},{Port};Database={Name};User Id={User};Password={Password};TrustServerCertificate={TrustServerCertificate};",
            _ => throw new NotImplementedException($"Database {Type} unavaible"),
        };
    }
}
