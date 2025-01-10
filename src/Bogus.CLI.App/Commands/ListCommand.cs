using Bogus.CLI.App.Constants;
using Bogus.CLI.App.Constants.Properties;
using Cocona;
using Cocona.Builder;

namespace Bogus.CLI.App.Commands;
public static class ListCommand
{
    private static readonly SortedDictionary<string, List<string>> _categories = new()
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

    public static CommandConventionBuilder AddListCommand(this ICoconaCommandsBuilder builder) => builder
        .AddCommand("list", GetCommand)
        .WithDescription("Lists all available categories.");

    private static void GetCommand([Option('g', Description = "")] string? generatorName)
    {
        if (!string.IsNullOrEmpty(generatorName) &&
            _categories.TryGetValue(generatorName.ToLower(), out var properties))
        {
            Console.WriteLine($"> {generatorName}");
            Console.WriteLine();

            foreach (var property in properties.Order())
                Console.WriteLine($"- {property}");

            return;
        }

        foreach (var category in _categories)
            Console.WriteLine($"- {category.Key}");
    }
}
