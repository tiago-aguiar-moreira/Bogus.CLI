using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class ListDatasetService : IListDatasetService
{
    private static readonly IDictionary<string, IList<string>> _categories = new Dictionary<string, IList<string>>()
    {
        {
            Categories.LOREM, new List<string>
            {
                LoremProperty.WORD,
                LoremProperty.WORDS,
                LoremProperty.LETTER,
                LoremProperty.SENTENCE,
                LoremProperty.SENTENCES,
                LoremProperty.PARAGRAPH,
                LoremProperty.PARAGRAPHS,
                LoremProperty.TEXT,
                LoremProperty.LINES,
                LoremProperty.SLUG
}
        },
        {
            Categories.NAME, new List<string>
            {
                NameProperty.FIRST_NAME,
                NameProperty.LAST_NAME,
                NameProperty.FULL_NAME,
                NameProperty.PREFIX,
                NameProperty.SUFFIX,
                NameProperty.FIND_NAME,
                NameProperty.JOB_TITLE,
                NameProperty.JOB_DESCRIPTOR,
                NameProperty.JOB_AREA,
                NameProperty.JOB_TYPE
            }
        },
        {
            Categories.PHONE, new List<string>
            {
                PhoneProperty.NUMBER,
                PhoneProperty.FORMAT
            }
        }
    };

    public IList<string> ExecuteCommand(string? datasetName)
    {
        var datasets = new List<string>();

        if (string.IsNullOrEmpty(datasetName))
        {
            datasets.AddRange(_categories.Select(s => s.Key).Order());
        }
        else
        {
            if (_categories.TryGetValue(datasetName.ToLower(), out var properties))
                datasets.AddRange(properties.Order());
        }

        return datasets;
    }
}