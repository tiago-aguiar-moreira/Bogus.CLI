namespace Bogus.CLI.Core.Services.Interface;
public interface ICommerceFakerAdapter
{
    string Department(int max = 1, bool returnMax = false);
    string Price(decimal min = 1, decimal max = 1000, int decimals = 2, string symbol = "");
    string[] Categories(int num = 1);
    string ProductName();
    string Color();
    string Product();
    string ProductAdjective();
    string ProductMaterial();
    string ProductDescription();
    string Ean8();
    string Ean13();
}
