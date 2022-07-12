using ApplicationCore.Models;
using ForyumAPI.Repositories.Base;
using Infrastructure;

namespace ForyumAPI.Repositories;

public interface IPostRepository : IRepository<Post> {

}

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context) {
        _context = context;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Post> Insert(Post obj)
    {
        _context.Posts.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public Task Update(Post obj)
    {
        throw new NotImplementedException();
    }
}