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

public class PostFeedDTO {
    public int id { get; set; }
    public DateTimeOffset dateCreated { get; set; }
    public int communityId { get; set; }
    public string communityName { get; set; } = null!;
    public string title { get; set; } = null!;
    public string? text { get; set; }
    public int creatorUserId { get; set; }
    public string creatorUsername { get; set; } = null!;
}