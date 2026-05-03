namespace Bogus.CLI.Core.Services.Interface;
public interface IInternetFakerAdapter
{
    string Avatar();
    string Email(string? firstName = null, string? lastName = null, string? provider = null, string? uniqueSuffix = null);
    string ExampleEmail(string? firstName = null, string? lastName = null);
    string UserName(string? firstName = null, string? lastName = null);
    string UserNameUnicode(string? firstName = null, string? lastName = null);
    string DomainName();
    string DomainWord();
    string DomainSuffix();
    string Ip();
    string Port();
    string IpAddress();
    string IpEndPoint();
    string Ipv6();
    string Ipv6Address();
    string Ipv6EndPoint();
    string UserAgent();
    string Mac(string separator = ":");
    string Password(int length = 10, bool memorable = false, string? regexPattern = null, string? prefix = null);
    string Color(byte baseRed = 0, byte baseGreen = 0, byte baseBlue = 0, bool grayscale = false, string format = "hex");
    string Protocol();
    string Url();
    string UrlWithPath(string? protocol = null, string? domain = null, string? fileExt = null);
    string UrlRootedPath(string? fileExt = null);
}
