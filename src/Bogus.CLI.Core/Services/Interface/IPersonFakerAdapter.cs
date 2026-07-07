namespace Bogus.CLI.Core.Services.Interface;
public interface IPersonFakerAdapter
{
    string FirstName();
    string LastName();
    string FullName();
    string Gender();
    string UserName();
    string Avatar();
    string Email();
    string Phone();
    string Website();
    string DateOfBirth();
}
