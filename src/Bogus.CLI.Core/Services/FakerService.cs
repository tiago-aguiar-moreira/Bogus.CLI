using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services;

[ExcludeFromCodeCoverage]
public class FakerService : IFakerService
{
    public string LocaleCode { get; set; }

    public FakerService() => LocaleCode = string.Empty;

    public Faker GetFaker() => string.IsNullOrEmpty(LocaleCode)
        ? new Faker()
        : new Faker(LocaleCode);
}