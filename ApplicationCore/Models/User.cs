namespace ApplicationCore.Models;

public class User
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Bio { get; set; }

    public IEnumerable<Post>? Posts { get; set; }

    public IEnumerable<Community>? Communities { get; set; }

    public IEnumerable<Community>? CreatedCommunities { get; set; }

    public IEnumerable<Vote>? Votes { get; set; }

    public IEnumerable<Session>? Sessions { get; set; }
}