using Bogus.CLI.App.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.App.Services;

[ExcludeFromCodeCoverage]
public class FakerService : IFakerService
{
    public string LocaleCode { get; set; }

    public FakerService() => LocaleCode = string.Empty;

    public Faker GetFaker() => string.IsNullOrEmpty(LocaleCode)
        ? new Faker()
        : new Faker(LocaleCode);
}