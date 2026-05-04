namespace Bogus.CLI.Core.Services.Interface;
public interface IImagesDatasetService
{
    string? Generate(string property, IDictionary<string, object> parameters);
}
