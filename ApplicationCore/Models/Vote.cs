namespace ApplicationCore.Models;

public class Vote
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public VoteType VoteType { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}
