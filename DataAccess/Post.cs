namespace DataAccess;

public sealed class Post
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public short Likes { get; set; }
    public string Comments { get; set; }
    public Visibility Visibility { get; set; }
}
