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

    public List<Post>? Posts { get; set; }
    public List<Community>? Communities { get; set; }
    public List<Community>? CreatedCommunities { get; set; }
    public List<Vote>? Votes { get; set; }
    public List<Session>? Sessions { get; set; }
    public List<Comment>? Comments { get; set; }
}