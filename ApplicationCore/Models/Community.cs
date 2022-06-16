namespace ApplicationCore.Models;

public class Community
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public IEnumerable<Post>? Posts { get; set; }

    public IEnumerable<User>? Users { get; set; }

    public int CreatorUserId { get; set; }
    public User CreatorUser { get; set; } = null!;
}