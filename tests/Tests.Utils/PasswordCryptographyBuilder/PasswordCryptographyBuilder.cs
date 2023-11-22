using CookBook.Application.Services.Cryptography;

namespace Tests.Utils.PasswordCryptographyBuilder;

public class PasswordCryptographyBuilder
{
    public static PasswordCryptography Instance()
    {
        return new PasswordCryptography("abcd123");
    }
}
