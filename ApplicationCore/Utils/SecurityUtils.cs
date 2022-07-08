using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ApplicationCore.Utils;

public interface ISecurityUtils {

    User HashPassword(User user);

    User HashPassword(User user, byte[] salt);
}

public class SecurityUtils : ISecurityUtils
{
    public User HashPassword(User user)
    {
        byte[] salt = new byte[128 / 8];

        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        return HashPassword(user, salt);
    }

    public User HashPassword(User user, byte[] salt)
    {
        var password = user.Password;

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        user.Password = hashed;
        user.PasswordSalt = Convert.ToBase64String(salt);

        return user;
    }
}