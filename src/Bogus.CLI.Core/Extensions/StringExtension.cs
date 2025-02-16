namespace Bogus.CLI.Core.Extensions;
public static class StringExtension
{
    public static int CountCharacter(this string str, char character)
        => str.Count(c => c == character);

    public static int CountNumbers(this string str)
        => str.Count(char.IsNumber);
}