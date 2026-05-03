using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class InternetFakerAdapter(IFakerService fakerService) : IInternetFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Internet GetFaker() => _fakerService.GetFaker().Internet;

    public string Avatar() => GetFaker().Avatar();

    public string Email(string? firstName = null, string? lastName = null, string? provider = null, string? uniqueSuffix = null)
        => GetFaker().Email(firstName, lastName, provider, uniqueSuffix);

    public string ExampleEmail(string? firstName = null, string? lastName = null)
        => GetFaker().ExampleEmail(firstName, lastName);

    public string UserName(string? firstName = null, string? lastName = null)
        => GetFaker().UserName(firstName, lastName);

    public string UserNameUnicode(string? firstName = null, string? lastName = null)
        => GetFaker().UserNameUnicode(firstName, lastName);

    public string DomainName() => GetFaker().DomainName();

    public string DomainWord() => GetFaker().DomainWord();

    public string DomainSuffix() => GetFaker().DomainSuffix();

    public string Ip() => GetFaker().Ip();

    public string Port() => GetFaker().Port().ToString();

    public string IpAddress() => GetFaker().IpAddress().ToString();

    public string IpEndPoint() => GetFaker().IpEndPoint().ToString();

    public string Ipv6() => GetFaker().Ipv6();

    public string Ipv6Address() => GetFaker().Ipv6Address().ToString();

    public string Ipv6EndPoint() => GetFaker().Ipv6EndPoint().ToString();

    public string UserAgent() => GetFaker().UserAgent();

    public string Mac(string separator = ":") => GetFaker().Mac(separator);

    public string Password(int length = 10, bool memorable = false, string? regexPattern = null, string? prefix = null)
        => GetFaker().Password(length, memorable, regexPattern, prefix);

    public string Color(byte baseRed = 0, byte baseGreen = 0, byte baseBlue = 0, bool grayscale = false, string format = "hex")
    {
        var colorFormat = format.ToLower() switch
        {
            "rgb" => ColorFormat.Rgb,
            "delimited" => ColorFormat.Delimited,
            _ => ColorFormat.Hex
        };
        return GetFaker().Color(baseRed, baseGreen, baseBlue, grayscale, colorFormat);
    }

    public string Protocol() => GetFaker().Protocol();

    public string Url() => GetFaker().Url();

    public string UrlWithPath(string? protocol = null, string? domain = null, string? fileExt = null)
        => GetFaker().UrlWithPath(protocol, domain, fileExt);

    public string UrlRootedPath(string? fileExt = null) => GetFaker().UrlRootedPath(fileExt);
}
