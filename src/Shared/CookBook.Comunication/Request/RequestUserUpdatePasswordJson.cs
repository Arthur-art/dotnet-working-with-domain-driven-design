namespace CookBook.Comunication.Request;

public class RequestUserUpdatePasswordJson
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
