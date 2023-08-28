using CommandDotNet.TestTools;

namespace Bogus.Test;

public class GeneratorTests
{
    [Theory]
    [InlineData("generate FirstName=name.firstname:male name.lastname:male --locale pt_BR --file-format sql --file-path c:\\temp --limit-rows 5 --separator ;")]
    //[InlineData("generate FirstName=name.firstname:male name.lastname:male email=internet.email --locale pt_BR --file-format sql --file-path c:\\temp --limit-rows 5 --separator ;")]
    public void Test1(string command)
    {
        //command = $"generate name.firstname:male name.lastname:female {command}";

        var result = App.Program.AppRunner.RunInMem(command);

        var abc = result.Console.ErrorText();
    }
}