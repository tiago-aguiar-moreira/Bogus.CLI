using Bogus.App.Commands;
using CommandDotNet;
using CommandDotNet.DataAnnotations;
using CommandDotNet.NameCasing;

namespace Bogus.App;

public class Program
{
    static int Main(string[] args) => AppRunner.Run(args);

    public static AppRunner AppRunner
        => new AppRunner<GeneratorCommand>()
        .UseNameCasing(Case.LowerCase)
        .UseDataAnnotationValidations();
}