namespace DataAccess;

public sealed class User
{
    public User()
    {
        Following = new List<User>();
        Followers = new List<User>();
    }
    
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public DateTime RegDate { get; set; }

    public ICollection<User> ?Followers { get; set; }
    public ICollection<User> ?Following { get; set; } 
    public ICollection<Post> ?Posts { get; set; }
    public ICollection<Comment> ?Comments { get; set; }
}
