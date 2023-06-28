using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudyHere.API.Interfaces;
using StudyHere.Domain.Models;

namespace StudyHere.API.Auth;

public class TokenService : ITokenService
{
    public Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthInfo.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Task.FromResult(tokenHandler.WriteToken(token));
    }

    public Task<bool> ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthInfo.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out _);
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            return Task.FromResult(false);
        }
    }
}