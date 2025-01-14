using Bogus.CLI.App.Constants.Properties;
using Bogus.CLI.App.Extensions;

namespace Bogus.CLI.App.Commands;
public static class FakeDataLorem
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

    public static string? Generate(Faker faker, string category, Dictionary<string, object> parameters) => category switch
    {
        LoremProperty.WORD => faker.Lorem.Word(),
        LoremProperty.WORDS => GenerateWords(faker, parameters),
        LoremProperty.LETTER => GenerateLetter(faker, parameters),
        LoremProperty.SENTENCE => GenerateSentence(faker, parameters),
        LoremProperty.SENTENCES => GenerateSentences(faker, parameters),
        LoremProperty.PARAGRAPH => GenerateParagraph(faker, parameters),
        LoremProperty.PARAGRAPHS => GenerateParagraphs(faker, parameters),
        LoremProperty.TEXT => faker.Lorem.Text(),
        LoremProperty.LINES => GenerateLines(faker, parameters),
        LoremProperty.SLUG => GenerateSlug(faker, parameters),
        _ => null
    };

    private static string GenerateWords(Faker faker, Dictionary<string, object> parameters)
    {
        var num = parameters.ConvertToInt(PARAM_NUM, 3);
        var separator = parameters.ConvertToChar(PARAM_SEPARATOR, ' ');
        return string.Join(separator, faker.Lorem.Words(num));
    }

    private static string GenerateLetter(Faker faker, Dictionary<string, object> parameters)
    {
        var num = parameters.ConvertToInt(PARAM_NUM, 1);
        return faker.Lorem.Letter(num);
    }

    private static string GenerateSentence(Faker faker, Dictionary<string, object> parameters)
    {
        var wordCount = parameters.ConvertToInt(PARAM_WORDCOUNT, null);
        var range = parameters.ConvertToInt(PARAM_RANGE, 0);
        return faker.Lorem.Sentence(wordCount, range);
    }

    private static string GenerateSentences(Faker faker, Dictionary<string, object> parameters)
    {
        var sentenceCount = parameters.ConvertToInt(PARAM_SENTENCECOUNT, null);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n");
        return faker.Lorem.Sentences(sentenceCount, separator);
    }

    private static string GenerateParagraph(Faker faker, Dictionary<string, object> parameters)
    {
        var min = parameters.ConvertToInt(PARAM_MIN, 3);
        return faker.Lorem.Paragraph(min);
    }

    private static string GenerateParagraphs(Faker faker, Dictionary<string, object> parameters)
    {
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n\n");

        if (parameters.ContainsKey(PARAM_MIN) && parameters.ContainsKey(PARAM_MAX))
        {
            // Override 2: min, max, separator
            var min = parameters.ConvertToInt(PARAM_MIN, 0);
            var max = parameters.ConvertToInt(PARAM_MAX, 0);
            return faker.Lorem.Paragraphs(min, max, separator);
        }
        else
        {
            // Override 1: count, separator
            var count = parameters.ConvertToInt(PARAM_COUNT, 3);
            return faker.Lorem.Paragraphs(count, separator);
        }
    }

    private static string GenerateLines(Faker faker, Dictionary<string, object> parameters)
    {
        var lineCount = parameters.ConvertToInt(PARAM_LINECOUNT, 3);
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, "\n");
        return faker.Lorem.Lines(lineCount, separator);
    }

    private static string GenerateSlug(Faker faker, Dictionary<string, object> parameters)
    {
        var wordCount = parameters.ConvertToInt(PARAM_WORDCOUNT, 3);
        return faker.Lorem.Slug(wordCount);
    }
}