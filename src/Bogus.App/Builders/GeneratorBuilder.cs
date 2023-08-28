using Bogus.App.Arguments;

namespace Bogus.App.Builders;
public class GeneratorBuilder
{
    private IList<string> _dataGenerator;
    private string? _locale;
    private string? _fileFormat;
    private string? _filePath;
    private string? _limitRows;
    private string? _separator;

    public GeneratorBuilder AddDataGenerator(DataGeneratorArgs dataGenerator)
    {
        _dataGenerator = dataGenerator.Value;
        return this;
    }

    public GeneratorBuilder AddLocale(LocaleArgs locale)
    {
        _locale = locale.Value;
        return this;
    }

    public GeneratorBuilder AddFileFormat(FileFormatArgs fileFormat)
    {
        _fileFormat = fileFormat.Value;
        return this;
    }

    public GeneratorBuilder AddFilePath(FilePathArgs filePath)
    {
        _filePath = filePath.Value;
        return this;
    }

    public GeneratorBuilder AddLimitRows(LimitRowsArgs limitRows)
    {
        _limitRows = limitRows.Value;
        return this;
    }

    public GeneratorBuilder AddSeparator(SeparatorArgs separator)
    {
        _separator = separator.Value;
        return this;
    }

    public OutputGenerator Build() => new OutputGenerator(
        _dataGenerator, _locale, _fileFormat, _filePath, _limitRows, _separator);
}
