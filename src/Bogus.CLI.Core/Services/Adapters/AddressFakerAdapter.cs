using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class AddressFakerAdapter(IFakerService fakerService) : IAddressFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Address GetFaker() => _fakerService.GetFaker().Address;

    public string ZipCode(string? format = null) => GetFaker().ZipCode(format);

    public string City() => GetFaker().City();

    public string StreetAddress(bool useFullAddress = false) => GetFaker().StreetAddress(useFullAddress);

    public string CityPrefix() => GetFaker().CityPrefix();

    public string CitySuffix() => GetFaker().CitySuffix();

    public string StreetName() => GetFaker().StreetName();

    public string BuildingNumber() => GetFaker().BuildingNumber();

    public string StreetSuffix() => GetFaker().StreetSuffix();

    public string SecondaryAddress() => GetFaker().SecondaryAddress();

    public string County() => GetFaker().County();

    public string Country() => GetFaker().Country();

    public string FullAddress() => GetFaker().FullAddress();

    public string CountryCode(string format = "alpha2")
    {
        var iso = format.Equals("alpha3", StringComparison.OrdinalIgnoreCase)
            ? Iso3166Format.Alpha3
            : Iso3166Format.Alpha2;
        return GetFaker().CountryCode(iso);
    }

    public string State() => GetFaker().State();

    public string StateAbbr() => GetFaker().StateAbbr();

    public string Latitude(double min = -90, double max = 90) => GetFaker().Latitude(min, max).ToString();

    public string Longitude(double min = -180, double max = 180) => GetFaker().Longitude(min, max).ToString();

    public string Direction(bool useAbbreviation = false) => GetFaker().Direction(useAbbreviation);

    public string CardinalDirection(bool useAbbreviation = false) => GetFaker().CardinalDirection(useAbbreviation);

    public string OrdinalDirection(bool useAbbreviation = false) => GetFaker().OrdinalDirection(useAbbreviation);
}
