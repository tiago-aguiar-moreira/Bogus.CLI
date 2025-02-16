namespace Bogus.CLI.Core.Services.Interface;
public interface IFakerService
{
    string LocaleCode { get; set; }
    Faker GetFaker();
}