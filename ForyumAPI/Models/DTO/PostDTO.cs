using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class PostCreationDTO
{
    public int communityId { get; set; }
    public int creatorUserId { get; set; }
    public string title { get; set; } = null!;
    public string? text { get; set; }

    internal static Post toPost(PostCreationDTO dto)
    {
        return new Post() {
            CommunityId = dto.communityId,
            CreatorUserId = dto.creatorUserId,
            Title = dto.title,
            Text = dto.text
        };
    }
}