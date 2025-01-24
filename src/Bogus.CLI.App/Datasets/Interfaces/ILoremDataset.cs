namespace Bogus.CLI.App.Datasets.Interfaces;
public interface ILoremDataset
{
    string Word();
    string[] Words(int num = 3);
    string Letter(int num = 1);
    string Sentence(int? wordCount = null, int? range = 0);
    string Sentences(int? sentenceCount = null, string separator = "\n");
    string Paragraph(int min = 3);
    string Paragraphs(int count = 3, string separator = "\n\n");
    string Paragraphs(int min, int max, string separator = "\n\n");
    string Text();
    string Lines(int? lineCount = null, string separator = "\n");
    string Slug(int wordcount = 3);
}