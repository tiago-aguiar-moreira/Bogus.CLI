using Bogus.CLI.App.Datasets.Interfaces;
using Bogus.CLI.App.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Datasets;

[ExcludeFromCodeCoverage]
public class LoremDataset(IFakerService fakerService) : ILoremDataset
{
    private readonly Lorem _lorem = fakerService.GetFaker().Lorem;

    public string Word() => _lorem.Word();
    
    public string[] Words(int num = 3) => _lorem.Words(num);

    public string Letter(int num = 1)
        => _lorem.Letter(num);

    public string Sentence(int? wordCount = null, int? range = 0)
        => _lorem.Sentence(wordCount, range);

    public string Sentences(int? sentenceCount = null, string separator = "\n")
        => _lorem.Sentences(sentenceCount, separator);

    public string Paragraph(int min = 3)
        => _lorem.Paragraph(min);

    public string Paragraphs(int count = 3, string separator = "\n\n")
        => _lorem.Paragraphs(count, separator);

    public string Paragraphs(int min, int max, string separator = "\n\n")
        => _lorem.Paragraphs(min, max, separator);
    
    public string Text() => _lorem.Text();

    public string Lines(int? lineCount = null, string separator = "\n")
        => _lorem.Lines(lineCount, separator);

    public string Slug(int wordcount = 3)
        => _lorem.Slug(wordcount);
}