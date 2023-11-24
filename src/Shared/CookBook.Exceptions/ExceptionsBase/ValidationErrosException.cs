namespace CookBook.Exceptions.ExceptionsBase;

public class ValidationErrosException : CookBookException
{
    public List<string> ErrorMessages { get; set; }

    public ValidationErrosException(List<string> messages) : base(String.Empty)
    {
        ErrorMessages = messages;
    }
}
