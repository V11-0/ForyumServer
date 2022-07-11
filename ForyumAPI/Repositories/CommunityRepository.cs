using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using Infrastructure;

namespace ForyumAPI.Repositories;

public interface ICommunityRepository
{
    IEnumerable<CommunityBasicDTO> GetRecommended();
}

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;

    public CommunityRepository(AppDbContext context) {
        _context = context;
    }

    public IEnumerable<CommunityBasicDTO> GetRecommended()
    {
        Random rand = new Random();
        int toSkip = rand.Next(1, _context.Communities.Count());

        return _context.Communities.Skip(toSkip)
            .Select(c => new CommunityBasicDTO(c.Id, c.Name, c.Description, c.Users.Count()))
            .Take(10)
            .ToList();
    }
}