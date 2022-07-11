namespace ApplicationCore.Models;

public class Post
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Title { get; set; } = null!;

    public string? Text { get; set; }

    public List<PostMedia>? Medias { get; set; }

    public int CreatorUserId { get; set; }
    public User CreatorUser { get; set; } = null!;

    public int CommunityId { get; set; }
    public Community Community { get; set; } = null!;

    public List<Vote>? Votes { get; set; }
}