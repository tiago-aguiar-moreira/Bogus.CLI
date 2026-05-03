using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class HackerDatasetService(IHackerFakerAdapter hackerAdapter) : IHackerDatasetService
{
    private readonly IHackerFakerAdapter _hackerAdapter = hackerAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        HackerProperty.ABBREVIATION => _hackerAdapter.Abbreviation(),
        HackerProperty.ADJECTIVE => _hackerAdapter.Adjective(),
        HackerProperty.NOUN => _hackerAdapter.Noun(),
        HackerProperty.VERB => _hackerAdapter.Verb(),
        HackerProperty.ING_VERB => _hackerAdapter.IngVerb(),
        HackerProperty.PHRASE => _hackerAdapter.Phrase(),
        _ => null
    };
}
