using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services;
public class LoremDatasetServiceTests
{
    private readonly IDictionary<string, object> _parameters;
    private readonly Mock<ILoremFakerAdapter> _loremAdapterMock;
    private readonly ILoremDatasetService _loremDatasetService;

    public LoremDatasetServiceTests()
    {
        _loremAdapterMock = new Mock<ILoremFakerAdapter>();
        _loremDatasetService = new LoremDatasetService(_loremAdapterMock.Object);
        _parameters = new Dictionary<string, object>();
    }

    [Fact]
    public void GenerateWord_ShouldCallWord()
    {
        // Arrange
        _loremAdapterMock.Setup(s => s.Word()).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.WORD, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Word(), Times.Once());
    }

    [Theory]
    [InlineData(3)]
    [InlineData(8)]
    public void GenerateWords_WithNum_ShouldCallWordsWithNum(int num)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_NUM, num);
        _loremAdapterMock.Setup(s => s.Words(It.IsAny<int>())).Returns([]);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.WORDS, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Words(num), Times.Once());
    }

    [Fact]
    public void GenerateWords_WithoutParams_ShouldUseDefaults()
    {
        // Arrange
        _loremAdapterMock.Setup(s => s.Words(It.IsAny<int>())).Returns([]);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.WORDS, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Words(3), Times.Once());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void GenerateLetter_WithNum_ShouldCallLetterWithNum(int num)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_NUM, num);
        _loremAdapterMock.Setup(s => s.Letter(It.IsAny<int>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.LETTER, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Letter(num), Times.Once());
    }

    [Theory]
    [InlineData(4)]
    [InlineData(10)]
    public void GenerateSentence_WithWordCount_ShouldCallSentenceWithWordCount(int wordCount)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_WORDCOUNT, wordCount);
        _loremAdapterMock.Setup(s => s.Sentence(It.IsAny<int?>(), It.IsAny<int?>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.SENTENCE, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Sentence(wordCount, 0), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void GenerateSentences_WithSentenceCount_ShouldCallSentencesWithCount(int count)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_SENTENCECOUNT, count);
        _loremAdapterMock.Setup(s => s.Sentences(It.IsAny<int?>(), It.IsAny<string>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.SENTENCES, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Sentences(count, "\n"), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void GenerateParagraph_WithMin_ShouldCallParagraphWithMin(int min)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_MIN, min);
        _loremAdapterMock.Setup(s => s.Paragraph(It.IsAny<int>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.PARAGRAPH, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Paragraph(min), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void GenerateParagraphs_WithCount_ShouldCallParagraphsWithCount(int count)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_COUNT, count);
        _loremAdapterMock.Setup(s => s.Paragraphs(It.IsAny<int>(), It.IsAny<string>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.PARAGRAPHS, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Paragraphs(count, "\n\n"), Times.Once());
    }

    [Theory]
    [InlineData(2, 4)]
    [InlineData(1, 6)]
    public void GenerateParagraphs_WithMinAndMax_ShouldCallParagraphsWithMinMax(int min, int max)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_MIN, min);
        _parameters.AddParameter(LoremDatasetService.PARAM_MAX, max);
        _loremAdapterMock.Setup(s => s.Paragraphs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.PARAGRAPHS, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Paragraphs(min, max, "\n\n"), Times.Once());
    }

    [Fact]
    public void GenerateText_ShouldCallText()
    {
        // Arrange
        _loremAdapterMock.Setup(s => s.Text()).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.TEXT, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Text(), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void GenerateLines_WithLineCount_ShouldCallLinesWithLineCount(int lineCount)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_LINECOUNT, lineCount);
        _loremAdapterMock.Setup(s => s.Lines(It.IsAny<int?>(), It.IsAny<string>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.LINES, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Lines(lineCount, "\n"), Times.Once());
    }

    [Theory]
    [InlineData(3)]
    [InlineData(8)]
    public void GenerateSlug_WithWordCount_ShouldCallSlugWithWordCount(int wordCount)
    {
        // Arrange
        _parameters.AddParameter(LoremDatasetService.PARAM_WORDCOUNT, wordCount);
        _loremAdapterMock.Setup(s => s.Slug(It.IsAny<int>())).Returns(string.Empty);

        // Act
        _ = _loremDatasetService.Generate(LoremProperty.SLUG, _parameters);

        // Assert
        _loremAdapterMock.Verify(v => v.Slug(wordCount), Times.Once());
    }

    [Theory]
    [InlineData("test")]
    [InlineData("xpto")]
    public void Generate_InvalidProperty_ReturnsNull(string property)
    {
        // Act
        var result = _loremDatasetService.Generate(property, _parameters);

        // Assert
        Assert.Null(result);
    }
}
