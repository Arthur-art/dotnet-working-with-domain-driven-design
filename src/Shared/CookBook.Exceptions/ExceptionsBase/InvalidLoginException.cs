namespace CookBook.Exceptions.ExceptionsBase;

public class InvalidLoginException : CookBookException
{
    public InvalidLoginException() : base(ResourceExceptionsMessages.INVALID_LOGIN)
    {
    }
}
