namespace Bogus.CLI.App.Services.Interface;
public interface IFakerService
{
    string LocaleCode { get; set; }
    Faker GetFaker();
}