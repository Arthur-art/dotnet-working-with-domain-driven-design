using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CookBook.Application.Services.Token;

public class TokenController
{
    private const string EmailAlias = "eml";
    private readonly double _lifeTimeToken;
    private readonly string _securityKey;

    public TokenController(double lifeTimeToken, string securityKey)
    {
        _lifeTimeToken = lifeTimeToken;
        _securityKey = securityKey;
    }

    public string GenerateToken(string userEmail)
    {
        var claims = new List<Claim>
        {
            new Claim(EmailAlias, userEmail),
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_lifeTimeToken),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_securityKey)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
    }
}
