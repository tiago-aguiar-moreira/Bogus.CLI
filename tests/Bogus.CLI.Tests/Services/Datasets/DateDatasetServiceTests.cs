using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services.Datasets;

public class DateDatasetServiceTests
{
    private readonly DateDatasetService _service;
    private readonly Mock<IDateFakerAdapter> _adapterMock;

    public DateDatasetServiceTests()
    {
        _adapterMock = new Mock<IDateFakerAdapter>();
        _service = new DateDatasetService(_adapterMock.Object);
    }

    [Fact]
    public void Generate_Past_ShouldCallAdapterWithDefaultYears()
    {
        _adapterMock.Setup(s => s.Past(1)).Returns("2023-01-15 10:30:00");

        var result = _service.Generate(DateProperty.PAST, new Dictionary<string, object>());

        Assert.Equal("2023-01-15 10:30:00", result);
        _adapterMock.Verify(v => v.Past(1), Times.Once);
    }

    [Fact]
    public void Generate_Past_WithYearsParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Past(3)).Returns("2021-06-20 08:00:00");

        var parameters = new Dictionary<string, object> { { DateDatasetService.PARAM_YEARS, "3" } };

        var result = _service.Generate(DateProperty.PAST, parameters);

        Assert.Equal("2021-06-20 08:00:00", result);
        _adapterMock.Verify(v => v.Past(3), Times.Once);
    }

    [Fact]
    public void Generate_PastOffset_ShouldCallAdapterWithDefaultYears()
    {
        _adapterMock.Setup(s => s.PastOffset(1)).Returns("2023-01-15T10:30:00+00:00");

        var result = _service.Generate(DateProperty.PAST_OFFSET, new Dictionary<string, object>());

        Assert.Equal("2023-01-15T10:30:00+00:00", result);
        _adapterMock.Verify(v => v.PastOffset(1), Times.Once);
    }

    [Fact]
    public void Generate_Future_ShouldCallAdapterWithDefaultYears()
    {
        _adapterMock.Setup(s => s.Future(1)).Returns("2025-08-10 14:00:00");

        var result = _service.Generate(DateProperty.FUTURE, new Dictionary<string, object>());

        Assert.Equal("2025-08-10 14:00:00", result);
        _adapterMock.Verify(v => v.Future(1), Times.Once);
    }

    [Fact]
    public void Generate_FutureOffset_ShouldCallAdapterWithDefaultYears()
    {
        _adapterMock.Setup(s => s.FutureOffset(1)).Returns("2025-08-10T14:00:00+00:00");

        var result = _service.Generate(DateProperty.FUTURE_OFFSET, new Dictionary<string, object>());

        Assert.Equal("2025-08-10T14:00:00+00:00", result);
        _adapterMock.Verify(v => v.FutureOffset(1), Times.Once);
    }

    [Fact]
    public void Generate_Recent_ShouldCallAdapterWithDefaultDays()
    {
        _adapterMock.Setup(s => s.Recent(1)).Returns("2024-05-01 09:00:00");

        var result = _service.Generate(DateProperty.RECENT, new Dictionary<string, object>());

        Assert.Equal("2024-05-01 09:00:00", result);
        _adapterMock.Verify(v => v.Recent(1), Times.Once);
    }

    [Fact]
    public void Generate_RecentOffset_ShouldCallAdapterWithDefaultDays()
    {
        _adapterMock.Setup(s => s.RecentOffset(1)).Returns("2024-05-01T09:00:00+00:00");

        var result = _service.Generate(DateProperty.RECENT_OFFSET, new Dictionary<string, object>());

        Assert.Equal("2024-05-01T09:00:00+00:00", result);
        _adapterMock.Verify(v => v.RecentOffset(1), Times.Once);
    }

    [Fact]
    public void Generate_Soon_ShouldCallAdapterWithDefaultDays()
    {
        _adapterMock.Setup(s => s.Soon(1)).Returns("2024-05-04 12:00:00");

        var result = _service.Generate(DateProperty.SOON, new Dictionary<string, object>());

        Assert.Equal("2024-05-04 12:00:00", result);
        _adapterMock.Verify(v => v.Soon(1), Times.Once);
    }

    [Fact]
    public void Generate_SoonOffset_ShouldCallAdapterWithDefaultDays()
    {
        _adapterMock.Setup(s => s.SoonOffset(1)).Returns("2024-05-04T12:00:00+00:00");

        var result = _service.Generate(DateProperty.SOON_OFFSET, new Dictionary<string, object>());

        Assert.Equal("2024-05-04T12:00:00+00:00", result);
        _adapterMock.Verify(v => v.SoonOffset(1), Times.Once);
    }

    [Fact]
    public void Generate_Between_WithDefaultsShouldCallAdapterWithParsedDates()
    {
        _adapterMock
            .Setup(s => s.Between(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns("2023-06-15 00:00:00");

        var result = _service.Generate(DateProperty.BETWEEN, new Dictionary<string, object>());

        Assert.Equal("2023-06-15 00:00:00", result);
        _adapterMock.Verify(v => v.Between(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
    }

    [Fact]
    public void Generate_Between_WithStartEndParams_ShouldCallAdapter()
    {
        var expectedStart = new DateTime(2020, 1, 1);
        var expectedEnd = new DateTime(2023, 12, 31);

        _adapterMock
            .Setup(s => s.Between(expectedStart, expectedEnd))
            .Returns("2021-07-04 00:00:00");

        var parameters = new Dictionary<string, object>
        {
            { DateDatasetService.PARAM_START, "2020-01-01" },
            { DateDatasetService.PARAM_END, "2023-12-31" }
        };

        var result = _service.Generate(DateProperty.BETWEEN, parameters);

        Assert.Equal("2021-07-04 00:00:00", result);
        _adapterMock.Verify(v => v.Between(expectedStart, expectedEnd), Times.Once);
    }

    [Fact]
    public void Generate_BetweenOffset_WithDefaultsShouldCallAdapterWithParsedDates()
    {
        _adapterMock
            .Setup(s => s.BetweenOffset(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
            .Returns("2023-06-15T00:00:00+00:00");

        var result = _service.Generate(DateProperty.BETWEEN_OFFSET, new Dictionary<string, object>());

        Assert.Equal("2023-06-15T00:00:00+00:00", result);
        _adapterMock.Verify(v => v.BetweenOffset(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Once);
    }

    [Fact]
    public void Generate_Month_ShouldCallAdapterWithDefaultAbbreviate()
    {
        _adapterMock.Setup(s => s.Month(false)).Returns("January");

        var result = _service.Generate(DateProperty.MONTH, new Dictionary<string, object>());

        Assert.Equal("January", result);
        _adapterMock.Verify(v => v.Month(false), Times.Once);
    }

    [Fact]
    public void Generate_Month_WithAbbreviateParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Month(true)).Returns("Jan");

        var parameters = new Dictionary<string, object> { { DateDatasetService.PARAM_ABBREVIATE, "true" } };

        var result = _service.Generate(DateProperty.MONTH, parameters);

        Assert.Equal("Jan", result);
        _adapterMock.Verify(v => v.Month(true), Times.Once);
    }

    [Fact]
    public void Generate_Weekday_ShouldCallAdapterWithDefaultAbbreviate()
    {
        _adapterMock.Setup(s => s.Weekday(false)).Returns("Monday");

        var result = _service.Generate(DateProperty.WEEKDAY, new Dictionary<string, object>());

        Assert.Equal("Monday", result);
        _adapterMock.Verify(v => v.Weekday(false), Times.Once);
    }

    [Fact]
    public void Generate_Weekday_WithAbbreviateParam_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Weekday(true)).Returns("Mon");

        var parameters = new Dictionary<string, object> { { DateDatasetService.PARAM_ABBREVIATE, "true" } };

        var result = _service.Generate(DateProperty.WEEKDAY, parameters);

        Assert.Equal("Mon", result);
        _adapterMock.Verify(v => v.Weekday(true), Times.Once);
    }

    [Fact]
    public void Generate_TimezoneString_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.TimeZoneString()).Returns("America/Los_Angeles");

        var result = _service.Generate(DateProperty.TIMEZONE_STRING, new Dictionary<string, object>());

        Assert.Equal("America/Los_Angeles", result);
        _adapterMock.Verify(v => v.TimeZoneString(), Times.Once);
    }

    [Fact]
    public void Generate_Timespan_ShouldCallAdapter()
    {
        _adapterMock.Setup(s => s.Timespan()).Returns("02:30:00");

        var result = _service.Generate(DateProperty.TIMESPAN, new Dictionary<string, object>());

        Assert.Equal("02:30:00", result);
        _adapterMock.Verify(v => v.Timespan(), Times.Once);
    }

    [Fact]
    public void Generate_UnknownProperty_ShouldReturnNull()
    {
        var result = _service.Generate("unknown", new Dictionary<string, object>());

        Assert.Null(result);
    }
}
