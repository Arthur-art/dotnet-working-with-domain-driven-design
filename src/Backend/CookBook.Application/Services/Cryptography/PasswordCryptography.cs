using System.Security.Cryptography;
using System.Text;

namespace CookBook.Application.Services.Cryptography;

public class PasswordCryptography
{
    private readonly string _encryptingKey;

    public PasswordCryptography(string encryptingKey)
    {
        _encryptingKey = encryptingKey;
    }

    public string Encrypt(string password)
    {
        var passwordWithKey = $"{password}{_encryptingKey}";

        var bytes = Encoding.UTF8.GetBytes(passwordWithKey);
        var sha512 = SHA512.Create();
        byte[] hashBytes= sha512.ComputeHash(bytes);

        return StringBytes(hashBytes);
    }

    public static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach(byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
