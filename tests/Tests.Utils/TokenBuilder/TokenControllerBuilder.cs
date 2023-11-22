using CookBook.Application.Services.Token;

namespace Tests.Utils.TokenBuilder;

public class TokenControllerBuilder
{
    public static TokenController Instance()
    {
        return new TokenController(1000, "ZHN3SztWQXcvb05kVzRlaDdMXlBxb0x0OkNYO21DJzkvZlwzUzQlLzpgTzk4QDVXUTQ=");
    }
}
