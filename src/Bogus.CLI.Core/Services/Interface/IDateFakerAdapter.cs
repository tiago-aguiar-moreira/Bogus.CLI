namespace Bogus.CLI.Core.Services.Interface;
public interface IDateFakerAdapter
{
    string Past(int yearsToGoBack = 1);
    string PastOffset(int yearsToGoBack = 1);
    string Future(int yearsToGoForward = 1);
    string FutureOffset(int yearsToGoForward = 1);
    string Recent(int days = 1);
    string RecentOffset(int days = 1);
    string Soon(int days = 1);
    string SoonOffset(int days = 1);
    string Between(DateTime start, DateTime end);
    string BetweenOffset(DateTimeOffset start, DateTimeOffset end);
    string Month(bool abbreviate = false);
    string Weekday(bool abbreviate = false);
    string TimeZoneString();
    string Timespan();
}
