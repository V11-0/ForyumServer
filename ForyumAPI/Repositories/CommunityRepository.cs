using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories.Base;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface ICommunityRepository : IRepository<Community>
{
    Task<IEnumerable<CommunityBasicDTO>> GetRecommended();
    Task JoinCommunity(string token, int communityId);
}

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;

    public CommunityRepository(AppDbContext context, IUserRepository userRepository) {
        _context = context;
        _userRepository = userRepository;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Community?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CommunityBasicDTO>> GetRecommended()
    {
        Random rand = new Random();
        int toSkip = rand.Next(1, _context.Communities.Count());

        return await _context.Communities.Skip(toSkip)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count()))
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