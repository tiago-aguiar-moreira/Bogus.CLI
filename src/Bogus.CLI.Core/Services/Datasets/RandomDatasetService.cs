using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class RandomDatasetService(IRandomFakerAdapter randomAdapter) : IRandomDatasetService
{
    public const string PARAM_MIN = "min";
    public const string PARAM_MAX = "max";
    public const string PARAM_COUNT = "count";
    public const string PARAM_LENGTH = "length";
    public const string PARAM_UPPERCASE = "uppercase";
    public const string PARAM_WEIGHT = "weight";
    public const string PARAM_FORMAT = "format";
    public const string PARAM_SYMBOL = "symbol";
    public const string PARAM_PREFIX = "prefix";

    private readonly IRandomFakerAdapter _randomAdapter = randomAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        RandomProperty.NUMBER => _randomAdapter.Number(
            parameters.ConvertToInt(PARAM_MIN, 0),
            parameters.ConvertToInt(PARAM_MAX, 1)),
        RandomProperty.EVEN => _randomAdapter.Even(
            parameters.ConvertToInt(PARAM_MIN, 0),
            parameters.ConvertToInt(PARAM_MAX, 1)),
        RandomProperty.ODD => _randomAdapter.Odd(
            parameters.ConvertToInt(PARAM_MIN, 0),
            parameters.ConvertToInt(PARAM_MAX, 1)),
        RandomProperty.INT => _randomAdapter.Int(
            parameters.ConvertToInt(PARAM_MIN, int.MinValue),
            parameters.ConvertToInt(PARAM_MAX, int.MaxValue)),
        RandomProperty.LONG => _randomAdapter.Long(
            parameters.ConvertToLong(PARAM_MIN, long.MinValue),
            parameters.ConvertToLong(PARAM_MAX, long.MaxValue)),
        RandomProperty.DOUBLE => _randomAdapter.Double(
            parameters.ConvertToDouble(PARAM_MIN, 0d),
            parameters.ConvertToDouble(PARAM_MAX, 1d)),
        RandomProperty.DECIMAL => _randomAdapter.Decimal(
            parameters.ConvertToDecimal(PARAM_MIN, 0m),
            parameters.ConvertToDecimal(PARAM_MAX, 1m)),
        RandomProperty.FLOAT => _randomAdapter.Float(
            parameters.ConvertToFloat(PARAM_MIN, 0f),
            parameters.ConvertToFloat(PARAM_MAX, 1f)),
        RandomProperty.BOOL => _randomAdapter.Bool(
            parameters.ConvertToFloat(PARAM_WEIGHT, 0.5f)),
        RandomProperty.CHAR => _randomAdapter.Char(
            parameters.ConvertToChar(PARAM_MIN, char.MinValue),
            parameters.ConvertToChar(PARAM_MAX, char.MaxValue)),
        RandomProperty.GUID => _randomAdapter.Guid(),
        RandomProperty.HASH => _randomAdapter.Hash(
            parameters.ConvertToInt(PARAM_LENGTH, 40),
            parameters.ConvertToBool(PARAM_UPPERCASE, false)),
        RandomProperty.HEXADECIMAL => _randomAdapter.Hexadecimal(
            parameters.ConvertToInt(PARAM_LENGTH, 1),
            parameters.ConvertToString(PARAM_PREFIX, "0x")),
        RandomProperty.ALPHANUMERIC => _randomAdapter.AlphaNumeric(
            parameters.ConvertToInt(PARAM_LENGTH, 10)),
        RandomProperty.REPLACE => _randomAdapter.Replace(
            parameters.ConvertToString(PARAM_FORMAT, "???")),
        RandomProperty.REPLACE_NUMBERS => _randomAdapter.ReplaceNumbers(
            parameters.ConvertToString(PARAM_FORMAT, "###"),
            parameters.ConvertToChar(PARAM_SYMBOL, '#')),
        RandomProperty.WORD => _randomAdapter.Word(),
        RandomProperty.WORDS => _randomAdapter.Words(
            parameters.ConvertToInt(PARAM_COUNT, 1)),
        RandomProperty.RANDOM_LOCALE => _randomAdapter.RandomLocale(),
        _ => null
    };
}
