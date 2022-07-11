namespace ApplicationCore.Models;

public class Community
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public List<Post>? Posts { get; set; }

    public List<User>? Users { get; set; }

    public int CreatorUserId { get; set; }
    public User CreatorUser { get; set; } = null!;
}