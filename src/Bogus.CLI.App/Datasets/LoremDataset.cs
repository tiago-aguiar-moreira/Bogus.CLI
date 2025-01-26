using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Datasets;

[ExcludeFromCodeCoverage]
public class LoremDataset(IFakerService fakerService) : ILoremDataset
{
    private readonly IFakerService _fakerService = fakerService;

    private Lorem GetFaker() => _fakerService.GetFaker().Lorem;

    public string Word() => GetFaker().Word();
    
    public string[] Words(int num = 3) => GetFaker().Words(num);

    public string Letter(int num = 1)
        => GetFaker().Letter(num);

    public string Sentence(int? wordCount = null, int? range = 0)
        => GetFaker().Sentence(wordCount, range);

    public string Sentences(int? sentenceCount = null, string separator = "\n")
        => GetFaker().Sentences(sentenceCount, separator);

    public string Paragraph(int min = 3)
        => GetFaker().Paragraph(min);

    public string Paragraphs(int count = 3, string separator = "\n\n")
        => GetFaker().Paragraphs(count, separator);

    public string Paragraphs(int min, int max, string separator = "\n\n")
        => GetFaker().Paragraphs(min, max, separator);
    
    public string Text() => GetFaker().Text();

    public string Lines(int? lineCount = null, string separator = "\n")
        => GetFaker().Lines(lineCount, separator);

    public string Slug(int wordcount = 3)
        => GetFaker().Slug(wordcount);
}