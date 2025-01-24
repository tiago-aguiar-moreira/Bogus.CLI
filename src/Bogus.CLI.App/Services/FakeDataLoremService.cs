using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Extensions;
using Bogus.CLI.App.Services.Interface;

namespace Bogus.CLI.App.Services;
public class FakeDataLoremService(ILoremDataset loremDataset) : IFakeDataLoremService
{
    public const string PARAM_NUM = "num";
    public const string PARAM_SEPARATOR = "separator";
    public const string PARAM_WORDCOUNT = "wordcount";
    public const string PARAM_RANGE = "range";
    public const string PARAM_SENTENCECOUNT = "sentencecount";
    public const string PARAM_MIN = "min";
    public const string PARAM_MAX = "max";
    public const string PARAM_COUNT = "count";
    public const string PARAM_LINECOUNT = "linecount";
    
    private readonly ILoremDataset _loremDataset = loremDataset;

    public string? Generate(string property, Dictionary<string, object> parameters) => property switch
    {
        LoremProperty.WORD => _loremDataset.Word(),
        LoremProperty.WORDS => GenerateWords(parameters),
        LoremProperty.LETTER => GenerateLetter(parameters),
        LoremProperty.SENTENCE => GenerateSentence(parameters),
        LoremProperty.SENTENCES => GenerateSentences(parameters),
        LoremProperty.PARAGRAPH => GenerateParagraph(parameters),
        LoremProperty.PARAGRAPHS => GenerateParagraphs(parameters),
        LoremProperty.TEXT => _loremDataset.Text(),
        LoremProperty.LINES => GenerateLines(parameters),
        LoremProperty.SLUG => GenerateSlug(parameters),
        _ => null
    };

    private string GenerateWords(Dictionary<string, object> parameters)
    {
        var num = parameters.ConvertToInt(PARAM_NUM, 3);
        var separator = parameters.ConvertToChar(PARAM_SEPARATOR, ' ');
        return string.Join(separator, _loremDataset.Words(num));
    }

    private string GenerateLetter(Dictionary<string, object> parameters)
    {
        var num = parameters.ConvertToInt(PARAM_NUM, 1);
        return _loremDataset.Letter(num);
    }

    private string GenerateSentence(Dictionary<string, object> parameters)
    {
        var wordCount = parameters.ConvertToInt(PARAM_WORDCOUNT, null);
        var range = parameters.ConvertToInt(PARAM_RANGE, 0);
        return _loremDataset.Sentence(wordCount, range);
    }

    private string GenerateSentences(Dictionary<string, object> parameters)
    {
        var sentenceCount = parameters.ConvertToInt(PARAM_SENTENCECOUNT, null);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n");
        return _loremDataset.Sentences(sentenceCount, separator);
    }

    private string GenerateParagraph(Dictionary<string, object> parameters)
    {
        var min = parameters.ConvertToInt(PARAM_MIN, 3);
        return _loremDataset.Paragraph(min);
    }

    private string GenerateParagraphs(Dictionary<string, object> parameters)
    {
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n\n");

        if (parameters.ContainsKey(PARAM_MIN) && parameters.ContainsKey(PARAM_MAX))
        {
            // Override 2: min, max, separator
            var min = parameters.ConvertToInt(PARAM_MIN, 0);
            var max = parameters.ConvertToInt(PARAM_MAX, 0);
            return _loremDataset.Paragraphs(min, max, separator);
        }
        else
        {
            // Override 1: count, separator
            var count = parameters.ConvertToInt(PARAM_COUNT, 3);
            return _loremDataset.Paragraphs(count, separator);
        }
    }

    private string GenerateLines(Dictionary<string, object> parameters)
    {
        var lineCount = parameters.ConvertToInt(PARAM_LINECOUNT, 3);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n");
        return _loremDataset.Lines(lineCount, separator);
    }

    private string GenerateSlug(Dictionary<string, object> parameters)
    {
        var wordCount = parameters.ConvertToInt(PARAM_WORDCOUNT, 3);
        return _loremDataset.Slug(wordCount);
    }
}