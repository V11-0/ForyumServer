namespace ApplicationCore.Models;

public class Comment
{
    public int Id { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public string Text { get; set; } = null!;

    public Post Post { get; set; } = null!;
    public int PostId { get; set; }

    public int CreatorUserId { get; set; }
    public User CreatorUser { get; set; } = null!;

    public List<Comment>? SubComments { get; set; }

    public Comment? ParentComment { get; set; }
    public int? ParentCommentId { get; set; }
}