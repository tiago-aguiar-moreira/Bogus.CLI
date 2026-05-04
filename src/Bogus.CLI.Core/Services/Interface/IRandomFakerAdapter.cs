namespace Bogus.CLI.Core.Services.Interface;
public interface IRandomFakerAdapter
{
    string Number(int min = 0, int max = 1);
    string Even(int min = 0, int max = 1);
    string Odd(int min = 0, int max = 1);
    string Int(int min = int.MinValue, int max = int.MaxValue);
    string Long(long min = long.MinValue, long max = long.MaxValue);
    string Double(double min = 0d, double max = 1d);
    string Decimal(decimal min = 0m, decimal max = 1m);
    string Float(float min = 0f, float max = 1f);
    string Bool(float weight = 0.5f);
    string Char(char min = char.MinValue, char max = char.MaxValue);
    string Guid();
    string Hash(int length = 40, bool upperCase = false);
    string Hexadecimal(int length = 1, string prefix = "0x");
    string AlphaNumeric(int length);
    string Replace(string format);
    string ReplaceNumbers(string format, char symbol = '#');
    string Word();
    string Words(int count = 1);
    string RandomLocale();
}
