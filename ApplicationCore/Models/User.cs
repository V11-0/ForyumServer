namespace ApplicationCore.Models;

public class User
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public IEnumerable<Post> Posts { get; set; } = null!;

    public IEnumerable<Community> Communities { get; set; } = null!;

    public IEnumerable<Community> CreatedCommunities { get; set; } = null!;

    public IEnumerable<Vote> Votes { get; set; } = null!;
}