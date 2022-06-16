namespace ApplicationCore.Models;

public class Session {

    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Token { get; set; } = null!;

    public string? DeviceName { get; set; }

    public string? DeviceOS { get; set; }

    public User User { get; set; } = null!;
    public int UserId{ get; set; }
}