using ApplicationCore.Models;
using ForyumAPI.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories.Base;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface ICommunityRepository : IRepository<Community>
{
    Task<IEnumerable<CommunityBasicDTO>> GetRecommended();
    Task<CommunityBasicDTO?> GetCommunity(int id, int userId);
    Task JoinCommunity(string token, int communityId);
    Task<IEnumerable<PostFeedDTO>> GetPosts(int communityId, PostOrdenation orderBy, int userId);
}

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;

    public CommunityRepository(AppDbContext context, IUserRepository userRepository, IPostRepository postRepository) {
        _context = context;
        _userRepository = userRepository;
        _postRepository = postRepository;
    }

    public async Task<CommunityBasicDTO?> GetCommunity(int id, int userId)
    {
        var community = await _context.Communities
            .Where(c => c.Id == id)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count(), c.CreatorUserId, c.CreatorUser.Username, null))
            .SingleOrDefaultAsync();

        if (community == null) {
            return null;
        }

        community.posts = await GetPosts(id, PostOrdenation.New, userId);
        return community;
    }

    public async Task<Community?> GetById(int id)
    {
        return await _context.Communities.Where(c => c.Id == id).Include(c => c.Posts).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<PostFeedDTO>> GetPosts(int communityId, PostOrdenation orderBy, int userId)
    {
        string sqlFilter = "WHERE CommunityId = @communityId";
        var parameters = new { communityId, userId };

        return await _postRepository.GetWithFilter(sqlFilter, parameters);
    }

    public async Task<IEnumerable<CommunityBasicDTO>> GetRecommended()
    {
        Random rand = new Random();
        int toSkip = rand.Next(1, _context.Communities.Count());

        return await _context.Communities.Skip(toSkip)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count(), null, null, null))
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