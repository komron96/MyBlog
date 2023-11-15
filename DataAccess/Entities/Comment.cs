namespace DataAccess;

public class Comment
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime CommentedAt { get; set; }


    //Post config
    public required Post Post { get; set; }
    public long PostId { get; set; }

    //User config
    public long UserId { get; set; }
    public User User { get; set; }

}