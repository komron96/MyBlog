namespace DataAccess;

public sealed class Post
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public required string Content { get; set; }
    public short Likes { get; set; }
    public DateTime CreatedAt { get; set; }
    public Visibility Visibility { get; set; }

    //UserConfig
    public long UserId { get; set; }
    public required User User { get; set; }

    public ICollection<Comment> ?Comments { get; set; }
}