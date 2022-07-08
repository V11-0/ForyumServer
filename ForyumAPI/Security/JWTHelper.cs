using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using Microsoft.IdentityModel.Tokens;

namespace ForyumAPI.Security;

public interface IJWTHelper
{
    string GenerateJWT(string username, string email);
}

public class JWTHelper : IJWTHelper
{
    private readonly string _jwtKey;
    private readonly string _jwtIssuer;

    public JWTHelper(string key, string issuer)
    {
        _jwtKey = key;
        _jwtIssuer = issuer;
    }

    public string GenerateJWT(string username, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Claim is used to add identity to JWT token
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(_jwtIssuer,
            _jwtIssuer,
            claims,
            expires: DateTime.Now.AddMonths(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}