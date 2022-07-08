using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ApplicationCore.Security;

public interface IPasswordHelper {

    User HashPassword(User user);

    string HashPassword(string password, byte[] salt);
}

public class PasswordHelper : IPasswordHelper
{
    public User HashPassword(User user)
    {
        byte[] salt = new byte[128 / 8];

        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        user.Password = HashPassword(user.Password, salt);
        user.PasswordSalt = Convert.ToBase64String(salt);

        return user;
    }

    public string HashPassword(string password, byte[] salt)
    {
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hashed;
    }
}