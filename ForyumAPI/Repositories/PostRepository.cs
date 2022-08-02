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
    Task<IEnumerable<PostFeedDTO>> GetWithFilter(string sqlFilter, object? parameters = null, PostOrdenation orderBy = PostOrdenation.New);
}

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    internal const String _basicPostQuery = @"
        SELECT p.Id, p.DateCreated, p.CommunityId, c.Name 'communityName', p.Title, p.`Text`,
            p.CreatorUserId, u.Username 'creatorUsername',
            SUM(CASE WHEN v.VoteType = 0 THEN 1 ELSE 0 END) 'upvoteCount',
            SUM(CASE WHEN v.VoteType = 1 THEN 1 ELSE 0 END) 'downvoteCount',
            (SELECT VoteType FROM Votes v WHERE PostId = p.Id AND UserId = @userId) 'userVote'
        FROM Posts p

        JOIN Communities c ON c.Id = p.CommunityId
        JOIN Users u ON u.Id = p.CreatorUserId
        LEFT JOIN Votes v ON v.PostId = p.Id

        {0}

        GROUP BY p.Id
        ORDER BY {1} DESC
        LIMIT 100";

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
        string filter = "WHERE CommunityId IN (SELECT CommunitiesId FROM CommunityUser WHERE UsersId = @userId)";
        return await GetWithFilter(filter, new { userId }, orderBy);
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

    public async Task<IEnumerable<PostFeedDTO>> GetWithFilter(string sqlFilter, object? parameters = null, PostOrdenation orderBy = PostOrdenation.New)
    {
        // Number to be used with ORDER BY in sql query
        var orderBycolumnNum = 2;

        if (orderBy == PostOrdenation.MostVoted) {
            orderBycolumnNum = 9;
        }

        var connection = _context.Database.GetDbConnection();

        var command = new CommandDefinition(
            String.Format(_basicPostQuery, sqlFilter, orderBycolumnNum),
            parameters
        );

        return await connection.QueryAsync<PostFeedDTO>(command);
    }
}