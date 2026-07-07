using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class MusicDatasetService(IMusicFakerAdapter musicAdapter) : IMusicDatasetService
{
    private readonly IMusicFakerAdapter _musicAdapter = musicAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        MusicProperty.GENRE => _musicAdapter.Genre(),
        _ => null
    };
}
