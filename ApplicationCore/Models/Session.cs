namespace ApplicationCore.Models;

public class Session {

    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Jti { get; set; } = null!;

    public string Token { get; set; } = null!;

    public string? UserAgent { get; set; }

    public User User { get; set; } = null!;
    public int UserId { get; set; }
}