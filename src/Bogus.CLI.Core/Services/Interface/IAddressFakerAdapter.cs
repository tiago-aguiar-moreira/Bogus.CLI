namespace Bogus.CLI.Core.Services.Interface;
public interface IAddressFakerAdapter
{
    string ZipCode(string? format = null);
    string City();
    string StreetAddress(bool useFullAddress = false);
    string CityPrefix();
    string CitySuffix();
    string StreetName();
    string BuildingNumber();
    string StreetSuffix();
    string SecondaryAddress();
    string County();
    string Country();
    string FullAddress();
    string CountryCode(string format = "alpha2");
    string State();
    string StateAbbr();
    string Latitude(double min = -90, double max = 90);
    string Longitude(double min = -180, double max = 180);
    string Direction(bool useAbbreviation = false);
    string CardinalDirection(bool useAbbreviation = false);
    string OrdinalDirection(bool useAbbreviation = false);
}
