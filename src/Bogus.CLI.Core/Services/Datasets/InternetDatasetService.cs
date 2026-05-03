using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class InternetDatasetService(IInternetFakerAdapter internetAdapter) : IInternetDatasetService
{
    public const string PARAM_FIRST_NAME = "firstName";
    public const string PARAM_LAST_NAME = "lastName";
    public const string PARAM_PROVIDER = "provider";
    public const string PARAM_UNIQUE_SUFFIX = "uniqueSuffix";
    public const string PARAM_SEPARATOR = "separator";
    public const string PARAM_LENGTH = "length";
    public const string PARAM_MEMORABLE = "memorable";
    public const string PARAM_REGEX = "regex";
    public const string PARAM_PREFIX = "prefix";
    public const string PARAM_RED = "red";
    public const string PARAM_GREEN = "green";
    public const string PARAM_BLUE = "blue";
    public const string PARAM_GRAYSCALE = "grayscale";
    public const string PARAM_FORMAT = "format";
    public const string PARAM_PROTOCOL = "protocol";
    public const string PARAM_DOMAIN = "domain";
    public const string PARAM_FILE_EXT = "fileExt";

    private readonly IInternetFakerAdapter _internetAdapter = internetAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        InternetProperty.AVATAR => _internetAdapter.Avatar(),
        InternetProperty.EMAIL => GenerateEmail(parameters),
        InternetProperty.EXAMPLE_EMAIL => GenerateExampleEmail(parameters),
        InternetProperty.USERNAME => GenerateUserName(parameters),
        InternetProperty.USERNAME_UNICODE => GenerateUserNameUnicode(parameters),
        InternetProperty.DOMAIN_NAME => _internetAdapter.DomainName(),
        InternetProperty.DOMAIN_WORD => _internetAdapter.DomainWord(),
        InternetProperty.DOMAIN_SUFFIX => _internetAdapter.DomainSuffix(),
        InternetProperty.IP => _internetAdapter.Ip(),
        InternetProperty.PORT => _internetAdapter.Port(),
        InternetProperty.IP_ADDRESS => _internetAdapter.IpAddress(),
        InternetProperty.IP_ENDPOINT => _internetAdapter.IpEndPoint(),
        InternetProperty.IPV6 => _internetAdapter.Ipv6(),
        InternetProperty.IPV6_ADDRESS => _internetAdapter.Ipv6Address(),
        InternetProperty.IPV6_ENDPOINT => _internetAdapter.Ipv6EndPoint(),
        InternetProperty.USER_AGENT => _internetAdapter.UserAgent(),
        InternetProperty.MAC => GenerateMac(parameters),
        InternetProperty.PASSWORD => GeneratePassword(parameters),
        InternetProperty.COLOR => GenerateColor(parameters),
        InternetProperty.PROTOCOL => _internetAdapter.Protocol(),
        InternetProperty.URL => _internetAdapter.Url(),
        InternetProperty.URL_WITH_PATH => GenerateUrlWithPath(parameters),
        InternetProperty.URL_ROOTED_PATH => GenerateUrlRootedPath(parameters),
        _ => null
    };

    private string GenerateEmail(IDictionary<string, object> parameters)
    {
        var firstName = NullIfEmpty(parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty));
        var lastName = NullIfEmpty(parameters.ConvertToString(PARAM_LAST_NAME, string.Empty));
        var provider = NullIfEmpty(parameters.ConvertToString(PARAM_PROVIDER, string.Empty));
        var uniqueSuffix = NullIfEmpty(parameters.ConvertToString(PARAM_UNIQUE_SUFFIX, string.Empty));
        return _internetAdapter.Email(firstName, lastName, provider, uniqueSuffix);
    }

    private string GenerateExampleEmail(IDictionary<string, object> parameters)
    {
        var firstName = NullIfEmpty(parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty));
        var lastName = NullIfEmpty(parameters.ConvertToString(PARAM_LAST_NAME, string.Empty));
        return _internetAdapter.ExampleEmail(firstName, lastName);
    }

    private string GenerateUserName(IDictionary<string, object> parameters)
    {
        var firstName = NullIfEmpty(parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty));
        var lastName = NullIfEmpty(parameters.ConvertToString(PARAM_LAST_NAME, string.Empty));
        return _internetAdapter.UserName(firstName, lastName);
    }

    private string GenerateUserNameUnicode(IDictionary<string, object> parameters)
    {
        var firstName = NullIfEmpty(parameters.ConvertToString(PARAM_FIRST_NAME, string.Empty));
        var lastName = NullIfEmpty(parameters.ConvertToString(PARAM_LAST_NAME, string.Empty));
        return _internetAdapter.UserNameUnicode(firstName, lastName);
    }

    private string GenerateMac(IDictionary<string, object> parameters)
    {
        var separator = parameters.ConvertToString(PARAM_SEPARATOR, ":");
        return _internetAdapter.Mac(separator);
    }

    private string GeneratePassword(IDictionary<string, object> parameters)
    {
        var length = parameters.ConvertToInt(PARAM_LENGTH, 10);
        var memorable = parameters.ConvertToBool(PARAM_MEMORABLE, false);
        var regex = NullIfEmpty(parameters.ConvertToString(PARAM_REGEX, string.Empty));
        var prefix = NullIfEmpty(parameters.ConvertToString(PARAM_PREFIX, string.Empty));
        return _internetAdapter.Password(length, memorable, regex, prefix);
    }

    private string GenerateColor(IDictionary<string, object> parameters)
    {
        var red = (byte)parameters.ConvertToInt(PARAM_RED, 0);
        var green = (byte)parameters.ConvertToInt(PARAM_GREEN, 0);
        var blue = (byte)parameters.ConvertToInt(PARAM_BLUE, 0);
        var grayscale = parameters.ConvertToBool(PARAM_GRAYSCALE, false);
        var format = parameters.ConvertToString(PARAM_FORMAT, "hex");
        return _internetAdapter.Color(red, green, blue, grayscale, format);
    }

    private string GenerateUrlWithPath(IDictionary<string, object> parameters)
    {
        var protocol = NullIfEmpty(parameters.ConvertToString(PARAM_PROTOCOL, string.Empty));
        var domain = NullIfEmpty(parameters.ConvertToString(PARAM_DOMAIN, string.Empty));
        var fileExt = NullIfEmpty(parameters.ConvertToString(PARAM_FILE_EXT, string.Empty));
        return _internetAdapter.UrlWithPath(protocol, domain, fileExt);
    }

    private string GenerateUrlRootedPath(IDictionary<string, object> parameters)
    {
        var fileExt = NullIfEmpty(parameters.ConvertToString(PARAM_FILE_EXT, string.Empty));
        return _internetAdapter.UrlRootedPath(fileExt);
    }

    private static string? NullIfEmpty(string value) => string.IsNullOrEmpty(value) ? null : value;
}
