using DataAccess;

namespace BusinessLogic;

public record struct CommentDto(
        long Id,
        string Text,
        string CreatedAt,
        Post Post,
        long PostId,
        User User,
        long UserId
);
