using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class DateDatasetService(IDateFakerAdapter dateAdapter) : IDateDatasetService
{
    public const string PARAM_YEARS = "years";
    public const string PARAM_DAYS = "days";
    public const string PARAM_START = "start";
    public const string PARAM_END = "end";
    public const string PARAM_ABBREVIATE = "abbreviate";

    private readonly IDateFakerAdapter _dateAdapter = dateAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        DateProperty.PAST => _dateAdapter.Past(parameters.ConvertToInt(PARAM_YEARS, 1)),
        DateProperty.PAST_OFFSET => _dateAdapter.PastOffset(parameters.ConvertToInt(PARAM_YEARS, 1)),
        DateProperty.FUTURE => _dateAdapter.Future(parameters.ConvertToInt(PARAM_YEARS, 1)),
        DateProperty.FUTURE_OFFSET => _dateAdapter.FutureOffset(parameters.ConvertToInt(PARAM_YEARS, 1)),
        DateProperty.RECENT => _dateAdapter.Recent(parameters.ConvertToInt(PARAM_DAYS, 1)),
        DateProperty.RECENT_OFFSET => _dateAdapter.RecentOffset(parameters.ConvertToInt(PARAM_DAYS, 1)),
        DateProperty.SOON => _dateAdapter.Soon(parameters.ConvertToInt(PARAM_DAYS, 1)),
        DateProperty.SOON_OFFSET => _dateAdapter.SoonOffset(parameters.ConvertToInt(PARAM_DAYS, 1)),
        DateProperty.BETWEEN => GenerateBetween(parameters),
        DateProperty.BETWEEN_OFFSET => GenerateBetweenOffset(parameters),
        DateProperty.MONTH => _dateAdapter.Month(parameters.ConvertToBool(PARAM_ABBREVIATE, false)),
        DateProperty.WEEKDAY => _dateAdapter.Weekday(parameters.ConvertToBool(PARAM_ABBREVIATE, false)),
        DateProperty.TIMEZONE_STRING => _dateAdapter.TimeZoneString(),
        DateProperty.TIMESPAN => _dateAdapter.Timespan(),
        _ => null
    };

    private string GenerateBetween(IDictionary<string, object> parameters)
    {
        var start = ParseDate(parameters.ConvertToString(PARAM_START, string.Empty), DateTime.Now.AddYears(-1));
        var end = ParseDate(parameters.ConvertToString(PARAM_END, string.Empty), DateTime.Now);
        return _dateAdapter.Between(start, end);
    }

    private string GenerateBetweenOffset(IDictionary<string, object> parameters)
    {
        var start = ParseDateOffset(parameters.ConvertToString(PARAM_START, string.Empty), DateTimeOffset.Now.AddYears(-1));
        var end = ParseDateOffset(parameters.ConvertToString(PARAM_END, string.Empty), DateTimeOffset.Now);
        return _dateAdapter.BetweenOffset(start, end);
    }

    private static DateTime ParseDate(string value, DateTime defaultValue)
        => DateTime.TryParse(value, out var result) ? result : defaultValue;

    private static DateTimeOffset ParseDateOffset(string value, DateTimeOffset defaultValue)
        => DateTimeOffset.TryParse(value, out var result) ? result : defaultValue;
}
