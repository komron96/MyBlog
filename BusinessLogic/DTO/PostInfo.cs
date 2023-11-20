using System.Data;
using DataAccess;

namespace BusinessLogic;
public readonly record struct PostDto
(
        long Id,
        string? Title,
        string Content,
        short Likes,
        DateTime CreatedAt,
        Visibility Visibility
);

public record struct CommentDTO(
        long Id,
        string Text,
        DateTime CommentedAt,
        long PostId,
        long UserId
);
