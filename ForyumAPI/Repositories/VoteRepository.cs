using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface IVoteRepository {
    Task Create(VoteDTO dto, int userId);
    Task Delete(int postId, int userId);
}

public class VoteRepository : IVoteRepository
{
    private readonly AppDbContext _context;

    public VoteRepository(AppDbContext context) {
        _context = context;
    }

    public async Task Create(VoteDTO dto, int userId)
    {
        var existingVote = await GetVote(dto.PostId, userId);

        if (existingVote != null) {
            existingVote.VoteType = dto.VoteType;
        } else {
            Vote vote = new Vote() {
                PostId = dto.PostId,
                UserId = userId,
                VoteType = dto.VoteType
            };

            await _context.AddAsync(vote);
        }

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int postId, int userId)
    {
        var vote = await GetVote(postId, userId);

        if (vote != null) {
            _context.Remove(vote);
            await _context.SaveChangesAsync();
        }
    }

    private async Task<Vote?> GetVote(int postId, int userId) {
        return await _context.Votes
            .Where(v => v.PostId == postId && v.UserId == userId)
            .SingleOrDefaultAsync();
    }
}