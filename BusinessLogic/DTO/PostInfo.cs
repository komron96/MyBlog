namespace BusinessLogic;
public readonly record struct PostInfo
(
    long Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    short Likes,
    string Visibility
);

