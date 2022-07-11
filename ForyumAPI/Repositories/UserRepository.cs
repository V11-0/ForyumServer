using ApplicationCore.Models;
using ApplicationCore.Security;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories.Base;
using ForyumAPI.Security;
using Infrastructure;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface IUserRepository : IRepository<User>
{

    Task<bool> CheckForUsername(string username);
    Task<bool> CheckForEmail(string email);
    Task<Session?> Login(UserLoginDTO userLogin, string userAgent);
    Task<User> GetUserByToken(string token);
    Task Logout(string token);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IPasswordHelper _passwordHelper;
    private readonly IJWTHelper _jwtHelper;

    public UserRepository(AppDbContext context, IPasswordHelper passwordHelper, IJWTHelper jwtHelper)
    {
        _context = context;
        _passwordHelper = passwordHelper;
        _jwtHelper = jwtHelper;
    }

    public async Task<bool> CheckForEmail(string email)
    {
        var users = await _context.Users.Where(u => u.Email == email).ToListAsync();
        return users.Any();
    }

    public async Task<bool> CheckForUsername(string username)
    {
        var users = await _context.Users.Where(u => u.Username == username).ToListAsync();
        return users.Any();
    }

    public async Task Delete(int id)
    {
        var user = await GetById(id);

        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByToken(string token)
    {
        string jti = _jwtHelper.GetJti(token);
        return await _context.Sessions.Where(s => s.Jti == jti).Select(s => s.User).SingleAsync();
    }

    public async Task<User> Insert(User obj)
    {
        obj = _passwordHelper.HashPassword(obj);

        await _context.Users.AddAsync(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<Session?> Login(UserLoginDTO userLogin, string userAgent)
    {
        var passwordSalt = await _context.Users
            .Where(u => u.Username == userLogin.Username)
            .Select(u => u.PasswordSalt)
            .SingleOrDefaultAsync();

        if (passwordSalt == null) {
            return null;
        }

        userLogin.Password = _passwordHelper
            .HashPassword(userLogin.Password, Convert.FromBase64String(passwordSalt));

        var user = await _context.Users
            .Where(u => u.Username == userLogin.Username && u.Password == userLogin.Password)
            .SingleOrDefaultAsync();

        if (user == null) {
            return null;
        }

        GeneratedJWT jwt = _jwtHelper.GenerateJWT(user.Username, user.Email);

        Session session = new Session() {
            Token = jwt.Token,
            Jti = jwt.Jti,
            UserAgent = userAgent,
            UserId = user.Id
        };

        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();

        return session;
    }

    public async Task Logout(string token)
    {
        string jti = _jwtHelper.GetJti(token);
        Session session = await _context.Sessions.Where(s => s.Jti == jti).SingleAsync();

        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User obj)
    {
        var dbUser = await GetById(obj.Id);

        if (dbUser != null)
        {
            dbUser.Bio = obj.Bio;
            dbUser.Country = obj.Country;
            dbUser.Email = obj.Email;

            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ApplicationException("User to be updated does not exist");
        }
    }
}