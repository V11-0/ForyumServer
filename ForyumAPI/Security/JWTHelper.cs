using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using Microsoft.IdentityModel.Tokens;

namespace ForyumAPI.Security;

public class GeneratedJWT {
    public string Token { get; set; } = null!;
    public string Jti { get; set; } = null!;

    public GeneratedJWT(string token, string jti) {
        Token = token;
        Jti = jti;
    }
}

public interface IJWTHelper
{
    GeneratedJWT GenerateJWT(string username, string email);
    string GetJti(string token);
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

    public GeneratedJWT GenerateJWT(string username, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jti = Guid.NewGuid().ToString();

        // Claim is used to add identity to JWT token
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, jti)
        };

        var token = new JwtSecurityToken(_jwtIssuer,
            _jwtIssuer,
            claims,
            expires: DateTime.Now.AddMonths(1),
            signingCredentials: credentials
        );

        return new GeneratedJWT(new JwtSecurityTokenHandler().WriteToken(token), jti);
    }

    public string GetJti(string token)
    {
        SecurityToken validatedToken;
        TokenValidationParameters validationParameters = new TokenValidationParameters();

        validationParameters.ValidateLifetime = true;
        validationParameters.ValidAudience = _jwtIssuer;
        validationParameters.ValidIssuer = _jwtIssuer;
        validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));

        ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);
        var jti = principal.Claims.Where(c => c.Type == JwtRegisteredClaimNames.Jti).First();

        return jti.Value;
    }
}