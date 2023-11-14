namespace DataAccess;

public sealed class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public DateTime RegDate { get; set; }
}
