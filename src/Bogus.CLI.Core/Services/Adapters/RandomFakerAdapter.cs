using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;
[ExcludeFromCodeCoverage]
public class RandomFakerAdapter(IFakerService fakerService) : IRandomFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    public string Number(int min = 0, int max = 1) => _fakerService.GetFaker().Random.Number(min, max).ToString();
    public string Even(int min = 0, int max = 1) => _fakerService.GetFaker().Random.Even(min, max).ToString();
    public string Odd(int min = 0, int max = 1) => _fakerService.GetFaker().Random.Odd(min, max).ToString();
    public string Int(int min = int.MinValue, int max = int.MaxValue) => _fakerService.GetFaker().Random.Int(min, max).ToString();
    public string Long(long min = long.MinValue, long max = long.MaxValue) => _fakerService.GetFaker().Random.Long(min, max).ToString();
    public string Double(double min = 0d, double max = 1d) => _fakerService.GetFaker().Random.Double(min, max).ToString();
    public string Decimal(decimal min = 0m, decimal max = 1m) => _fakerService.GetFaker().Random.Decimal(min, max).ToString();
    public string Float(float min = 0f, float max = 1f) => _fakerService.GetFaker().Random.Float(min, max).ToString();
    public string Bool(float weight = 0.5f) => _fakerService.GetFaker().Random.Bool(weight).ToString();
    public string Char(char min = char.MinValue, char max = char.MaxValue) => _fakerService.GetFaker().Random.Char(min, max).ToString();
    public string Guid() => _fakerService.GetFaker().Random.Guid().ToString();
    public string Hash(int length = 40, bool upperCase = false) => _fakerService.GetFaker().Random.Hash(length, upperCase);
    public string Hexadecimal(int length = 1, string prefix = "0x") => _fakerService.GetFaker().Random.Hexadecimal(length, prefix);
    public string AlphaNumeric(int length) => _fakerService.GetFaker().Random.AlphaNumeric(length);
    public string Replace(string format) => _fakerService.GetFaker().Random.Replace(format);
    public string ReplaceNumbers(string format, char symbol = '#') => _fakerService.GetFaker().Random.ReplaceNumbers(format, symbol);
    public string Word() => _fakerService.GetFaker().Random.Word();
    public string Words(int count = 1) => _fakerService.GetFaker().Random.Words(count);
    public string RandomLocale() => _fakerService.GetFaker().Random.RandomLocale();
}
