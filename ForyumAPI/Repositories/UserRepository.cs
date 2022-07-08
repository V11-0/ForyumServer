using ApplicationCore.Models;
using ApplicationCore.Utils;
using ForyumAPI.Repositories.Base;
using Infrastructure;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface IUserRepository : IRepository<User> {

    Task<bool> CheckForUsername(string username);
    Task<bool> CheckForEmail(string email);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly ISecurityUtils _securityUtils;

    public UserRepository(AppDbContext context, ISecurityUtils securityUtils) {
        _context = context;
        _securityUtils = securityUtils;
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

        if (user != null) {
            _context.Users.Remove(user);
        }
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> Insert(User obj)
    {
        obj = _securityUtils.HashPassword(obj);

        await _context.Users.AddAsync(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task Update(User obj)
    {
        var dbUser = await GetById(obj.Id);

        if (dbUser != null) {
            dbUser.Bio = obj.Bio;
            dbUser.Country = obj.Country;
            dbUser.Email = obj.Email;

            await _context.SaveChangesAsync();
        } else {
            throw new ApplicationException("User to be updated does not exist");
        }
    }
}