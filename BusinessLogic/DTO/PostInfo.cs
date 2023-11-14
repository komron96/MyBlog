namespace BusinessLogic;


readonly record struct OrderInfo
(
    long Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    short Likes,
    string? Comments,
    string Visibility
);
