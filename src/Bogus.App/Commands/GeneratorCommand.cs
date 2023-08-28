using Bogus.App.Arguments;
using Bogus.App.Builders;
using CommandDotNet;

namespace Bogus.App.Commands;
public class GeneratorCommand
{
    private GeneratorBuilder _generatorBuilder;

    public GeneratorCommand()
        => _generatorBuilder = new GeneratorBuilder();

    [Command("generate")]
    public void Generator(
        IConsole console,
        DataGeneratorArgs dataGenerator,
        LocaleArgs locale,
        FileFormatArgs fileFormat,
        FilePathArgs filePath,
        LimitRowsArgs limitRows,
        SeparatorArgs separator)
    {
        console.WriteLine("--> generate");
        //Validate


        //Execute
        var generator = _generatorBuilder
            .AddDataGenerator(dataGenerator)
            .AddLocale(locale)
            .AddFileFormat(fileFormat)
            .AddFilePath(filePath)
            .AddLimitRows(limitRows)
            .AddSeparator(separator)
            .Build();

        generator.Execute();
    }
}