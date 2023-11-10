using Bogus;
using CookBook.Comunication.Request;

namespace Tests.Utils.Requests;

public class UserRequestRegisterBuilder
{
    public static RequestUserRegisterJson Builder() 
    {
        return new Faker<RequestUserRegisterJson>()
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Password, f => f.Internet.Password())
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"));
            
    }
}
