using ApplicationCore.Models;
using Dapper;
using ForyumAPI.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories.Base;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<PostFeedDTO>> GetFeed(int userId, PostOrdenation orderBy);
}

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Post?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement orderBy
    public async Task<IEnumerable<PostFeedDTO>> GetFeed(int userId, PostOrdenation orderBy)
    {
        var connection = _context.Database.GetDbConnection();

        var command = new CommandDefinition(
            @"SELECT p.Id, p.DateCreated, p.CommunityId, c.Name 'communityName'
            , p.Title, p.`Text`, p.CreatorUserId, u.Username 'creatorUsername'
            FROM Posts p

            JOIN Communities c ON c.Id = p.CommunityId
            JOIN Users u ON u.Id = p.CreatorUserId

            WHERE CommunityId IN (SELECT CommunitiesId FROM CommunityUser WHERE UsersId = @userId)
            ORDER BY p.DateCreated DESC LIMIT 100",
            new { userId }
        );

        return await connection.QueryAsync<PostFeedDTO>(command);
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