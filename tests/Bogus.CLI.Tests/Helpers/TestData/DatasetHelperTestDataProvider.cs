namespace Bogus.CLI.Tests.Helpers.TestData;
public static class DatasetHelperTestDataProvider
{
    public static IEnumerable<object[]> ValidFormat =>
    [
        [
            "lorem.words",
            "lorem",
            "words",
            "",
            new Dictionary<string, object>()
        ],
        [
            "lorem.words=ws",
            "lorem",
            "words",
            "ws",
            new Dictionary<string, object>()
        ],
        [
            "lorem.words(num=8)",
            "lorem",
            "words",
            "",
            new Dictionary<string, object>() { { "num", "8" } }
        ],
        [
            "lorem.words(num=8)=ws",
            "lorem",
            "words",
            "ws",
            new Dictionary<string, object>() { { "num", "8" } }
        ],
        [
            "lorem.words(num=8,count=15)=ws",
            "lorem",
            "words",
            "ws",
            new Dictionary<string, object>() { { "num", "8" }, { "count", "15" } }
        ]
    ];
}
