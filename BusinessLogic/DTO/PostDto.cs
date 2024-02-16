namespace BusinessLogic;
public readonly record struct PostDto
(
        long Id,
        string? Title,
        string Content,
        short Likes,
        string CreatedAt,
        long UserId);
