using System.Globalization;

namespace Bogus.CLI.Core.Extensions;
public static class ParamaterExtension
{
    public static int ConvertToInt(this IDictionary<string, object> parameters, string key, int defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && int.TryParse(value.ToString(), out var intValue)
            ? intValue
            : defaultValue;

    public static int? ConvertToInt(this IDictionary<string, object> parameters, string key, int? defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && int.TryParse(value.ToString(), out var intValue)
            ? intValue
            : defaultValue;

    public static string ConvertToString(this IDictionary<string, object> parameters, string key, string defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value)
            ? value?.ToString() ?? defaultValue
            : defaultValue;

    public static char ConvertToChar(this IDictionary<string, object> parameters, string key, char defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && char.TryParse(value.ToString(), out var result)
            ? result
            : defaultValue;

    public static bool ConvertToBool(this IDictionary<string, object> parameters, string key, bool defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && bool.TryParse(value.ToString(), out var result)
            ? result
            : defaultValue;

    public static bool? ConvertToBool(this IDictionary<string, object> parameters, string key, bool? defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && bool.TryParse(value.ToString(), out var result)
            ? result
            : defaultValue;

    public static double ConvertToDouble(this IDictionary<string, object> parameters, string key, double defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value)
            && double.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var doubleValue)
            ? doubleValue
            : defaultValue;

    public static decimal ConvertToDecimal(this IDictionary<string, object> parameters, string key, decimal defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value)
            && decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalValue)
            ? decimalValue
            : defaultValue;

    public static float ConvertToFloat(this IDictionary<string, object> parameters, string key, float defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value)
            && float.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var floatValue)
            ? floatValue
            : defaultValue;

    public static long ConvertToLong(this IDictionary<string, object> parameters, string key, long defaultValue)
        => !string.IsNullOrEmpty(key) && parameters.TryGetValue(key.ToLower(), out var value) && long.TryParse(value.ToString(), out var longValue)
            ? longValue
            : defaultValue;

    public static void AddParameter(this IDictionary<string, object> parameters, string key, object values)
    {
        if (!string.IsNullOrEmpty(key) && values != null)
            parameters.Add(key.ToLower(), values);
    }
}
