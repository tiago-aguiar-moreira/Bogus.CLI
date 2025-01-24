namespace Bogus.CLI.App.Extensions;
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

    public static void AddParameter(this IDictionary<string, object> parameters, string key, object values)
    {
        if (!string.IsNullOrEmpty(key) && values != null)
            parameters.Add(key.ToLower(), values);
    }
}