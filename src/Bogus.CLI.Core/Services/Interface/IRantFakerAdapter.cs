namespace Bogus.CLI.Core.Services.Interface;
public interface IRantFakerAdapter
{
    string Review(string product = "");
    string[] Reviews(string product = "", int lines = 1);
}
