namespace DataAccess;

public class Comment
{
    public long Id { get; set; }
    public required string Text { get; set; }
    public DateTime CreatedAt { get; set; }


    //Post config
    public required Post Post { get; set; }
    public long PostId { get; set; }

    //User config
    public required User User { get; set; }
    public long UserId { get; set; }
}