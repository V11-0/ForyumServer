using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class CommentCreationDTO {
    public string Text { get; set; } = null!;

    public int PostId { get; set; }
    public int CreatorUserId { get; set; }
    public int? ParentCommentId { get; set; }

    public Comment toComment() {
        return new Comment() {
            Text = Text,
            PostId = PostId,
            CreatorUserId = CreatorUserId,
            ParentCommentId = ParentCommentId
        };
    }
}

public class CommentDTO {
    public string Text { get; set; } = null!;
    public int CreatorUserId { get; set; }
    public string CreatorUsername { get; set; } = null!;
    public List<CommentDTO>? SubComments { get; set; }

    public static CommentDTO fromComment(Comment c) {
        return new CommentDTO() {
            Text = c.Text,
            CreatorUserId = c.CreatorUserId,
            CreatorUsername = c.CreatorUser.Username,
            SubComments = c.SubComments?.Select(sc => fromComment(sc)).ToList()
        };
    }
}