using ApplicationCore.Models;
using ForyumAPI.Repositories.Base;
using Infrastructure;

namespace ForyumAPI.Repositories;

public interface IUserRepository : IRepository<User> {
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) {
        _context = context;
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

    public async Task Insert(User obj)
    {
        await _context.Users.AddAsync(obj);
        await _context.SaveChangesAsync();
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