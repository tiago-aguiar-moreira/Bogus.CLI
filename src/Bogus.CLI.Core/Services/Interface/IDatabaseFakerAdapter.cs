namespace Bogus.CLI.Core.Services.Interface;
public interface IDatabaseFakerAdapter
{
    string Column();
    string Type();
    string Collation();
    string Engine();
}
