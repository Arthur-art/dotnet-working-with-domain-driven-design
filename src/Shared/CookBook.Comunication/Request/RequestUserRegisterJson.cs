namespace CookBook.Comunication.Request;

public class RequestUserRegisterJson
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public RequestUserRegisterJson(string name, string email, string password, string phoneNumber)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }
}
