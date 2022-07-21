using ApplicationCore.Models;
using Dapper;
using ForyumAPI.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories.Base;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface ICommunityRepository : IRepository<Community>
{
    Task<IEnumerable<CommunityBasicDTO>> GetRecommended();
    Task<CommunityBasicDTO?> GetBasicCommunityInfo(int id);
    Task JoinCommunity(string token, int communityId);
    Task<IEnumerable<PostFeedDTO>> GetPosts(int communityId, PostOrdenation orderBy, string token);
}

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;

    public CommunityRepository(AppDbContext context, IUserRepository userRepository) {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<CommunityBasicDTO?> GetBasicCommunityInfo(int id)
    {
        return await _context.Communities
            .Where(c => c.Id == id)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count(), c.CreatorUserId, c.CreatorUser.Username))
            .SingleOrDefaultAsync();
    }

    public async Task<Community?> GetById(int id)
    {
        return await _context.Communities.Where(c => c.Id == id).Include(c => c.Posts).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<PostFeedDTO>> GetPosts(int communityId, PostOrdenation orderBy, string token)
    {
        var user = await _userRepository.GetUserByToken(token);
        var userId = user.Id;

        var connection = _context.Database.GetDbConnection();

        var command = new CommandDefinition(
            @"SELECT p.Id, p.DateCreated, p.CommunityId, p.Title, p.`Text`,
                p.CreatorUserId, u.Username 'creatorUsername',
                SUM(CASE WHEN v.VoteType = 0 THEN 1 ELSE 0 END) 'upvoteCount',
                SUM(CASE WHEN v.VoteType = 1 THEN 1 ELSE 0 END) 'downvoteCount',
                (SELECT VoteType FROM Votes v WHERE PostId = p.Id AND UserId = @userId) 'userVote'
            FROM Posts p

            JOIN Communities c ON c.Id = p.CommunityId
            JOIN Users u ON u.Id = p.CreatorUserId
            LEFT JOIN Votes v ON v.PostId = p.Id

            WHERE CommunityId = @communityId

            GROUP BY p.Id
            ORDER BY p.DateCreated DESC
            LIMIT 100",
            new { communityId, userId }
        );

        return await connection.QueryAsync<PostFeedDTO>(command);
    }

    public async Task<IEnumerable<CommunityBasicDTO>> GetRecommended()
    {
        Random rand = new Random();
        int toSkip = rand.Next(1, _context.Communities.Count());

        return await _context.Communities.Skip(toSkip)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count(), null, null))
            .Take(10)
            .ToListAsync();
    }

    public Task<Community> Insert(Community obj)
    {
        throw new NotImplementedException();
    }

    public async Task JoinCommunity(string token, int communityId)
    {
        var user = await _userRepository.GetUserByToken(token);
        var community = await _context.Communities.FindAsync(communityId);

        if (user.Communities == null) {
            user.Communities = new List<Community>();
        }

        if (community != null) {
            user.Communities.Add(community);
            await _context.SaveChangesAsync();
        } else throw new ApplicationException("Community not found");
    }

    public Task Update(Community obj)
    {
        throw new NotImplementedException();
    }
}