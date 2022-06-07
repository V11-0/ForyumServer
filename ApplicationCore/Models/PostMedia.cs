namespace ApplicationCore.Models;

public class PostMedia
{
    public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public MediaType Type { get; set; }
    public string Url { get; set; } = null!;

    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}