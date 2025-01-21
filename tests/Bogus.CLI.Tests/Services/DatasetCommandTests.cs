using Bogus.CLI.App.Services;
using Bogus.CLI.App.Services.Interface;
using Moq;

namespace Bogus.CLI.Tests.Services;

public class DatasetServiceTest
{
    private readonly DatasetService _datasetService;
    private readonly Mock<IFakerService> _fakerService;
    private readonly Mock<IFakeDataLoremService> _fakeDataLoremService;
    private readonly Mock<IFakeDataNameService> _fakeDataNameService;
    private readonly Mock<IFakeDataPhoneService> _fakeDataPhoneService;

    public DatasetServiceTest()
    {
        //_fakerService = new Mock<IFakerService>();
        //_fakeDataLoremService = new Mock<IFakeDataLoremService>();
        //_fakeDataNameService = new Mock<IFakeDataNameService>();
        //_fakeDataPhoneService = new Mock<IFakeDataPhoneService>();

        //_datasetService = new DatasetService(
        //    _fakerService.Object,
        //    _fakeDataLoremService.Object,
        //    _fakeDataNameService.Object,
        //    _fakeDataPhoneService.Object);
    }

    [Theory]
    [InlineData("num=8", 1)]
    [InlineData("num=8 separator=;", 2)]
    [InlineData("num=8 separator=,", 2)]
    [InlineData("num=8 separator=-", 2)]
    [InlineData("num=8 separator=_", 2)]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    public void TryParseParameters_ValidInputs_ShouldReturnTrue(string parameters, int expectedParamsCount)
    {
        var actualResult = DatasetService.TryParseParameters(parameters, out var parsedParameters);

        Assert.True(actualResult);
        Assert.Equal(expectedParamsCount, parsedParameters.Count);
    }

    [Theory]
    [InlineData("num=", 0)]
    [InlineData("=8", 0)]
    [InlineData("=", 0)]
    public void TryParseParameters_InvalidInputs_ShouldReturnFalse(string parameters, int expectedParamsCount)
    {
        var actualResult = DatasetService.TryParseParameters(parameters, out var parsedParameters);

        Assert.False(actualResult);
        Assert.Equal(expectedParamsCount, parsedParameters.Count);
    }

}