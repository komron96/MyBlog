namespace DataAccess;

public sealed class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public DateTime RegDate { get; set; }

    public ICollection<User> Followers { get; set; }
    public ICollection<User> Following { get; set; } 
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }
}