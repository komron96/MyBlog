namespace DataAccess;

public interface IUserRepository
{
    public ValueTask<User> CreateUserAsync(User user, CancellationToken token);
    public ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token);
}