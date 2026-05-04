using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class DateFakerAdapter(IFakerService fakerService) : IDateFakerAdapter
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private const string OFFSET_FORMAT = "yyyy-MM-ddTHH:mm:sszzz";

    private readonly IFakerService _fakerService = fakerService;

    private Date GetFaker() => _fakerService.GetFaker().Date;

    public string Past(int yearsToGoBack = 1) => GetFaker().Past(yearsToGoBack).ToString(DATE_FORMAT);
    public string PastOffset(int yearsToGoBack = 1) => GetFaker().PastOffset(yearsToGoBack).ToString(OFFSET_FORMAT);
    public string Future(int yearsToGoForward = 1) => GetFaker().Future(yearsToGoForward).ToString(DATE_FORMAT);
    public string FutureOffset(int yearsToGoForward = 1) => GetFaker().FutureOffset(yearsToGoForward).ToString(OFFSET_FORMAT);
    public string Recent(int days = 1) => GetFaker().Recent(days).ToString(DATE_FORMAT);
    public string RecentOffset(int days = 1) => GetFaker().RecentOffset(days).ToString(OFFSET_FORMAT);
    public string Soon(int days = 1) => GetFaker().Soon(days).ToString(DATE_FORMAT);
    public string SoonOffset(int days = 1) => GetFaker().SoonOffset(days).ToString(OFFSET_FORMAT);
    public string Between(DateTime start, DateTime end) => GetFaker().Between(start, end).ToString(DATE_FORMAT);
    public string BetweenOffset(DateTimeOffset start, DateTimeOffset end) => GetFaker().BetweenOffset(start, end).ToString(OFFSET_FORMAT);
    public string Month(bool abbreviate = false) => GetFaker().Month(abbreviate);
    public string Weekday(bool abbreviate = false) => GetFaker().Weekday(abbreviate);
    public string TimeZoneString() => GetFaker().TimeZoneString();
    public string Timespan() => GetFaker().Timespan().ToString();
}
