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
            SigningCredentials = new SigningCredentials(SimetricKey(),SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var paramsValidation = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = SimetricKey(),
            ClockSkew = new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        var claims = tokenHandler.ValidateToken(token, paramsValidation, out _);

        return claims;
    }

    public string RecoverEmail(string token)
    {
        var claims = ValidateToken(token);

        return claims.FindFirst(EmailAlias).Value;
    }

    private SymmetricSecurityKey SimetricKey()
    {
        var symmetricKey = Convert.FromBase64String(_securityKey);
        return new SymmetricSecurityKey(symmetricKey);
    }
}
