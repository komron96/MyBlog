using DataAccess;
namespace BusinessLogic;

public interface IUserService
{
    ValueTask<User> CreateUserAsync(User user, CancellationToken token);
    ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token);
}

public sealed class UserService : IUserService
{
    private readonly IUserRepository _iUserRepository;

    public UserService(IUserRepository iUserRepository)
    {
        _iUserRepository = iUserRepository;
    }

    public async ValueTask<User> CreateUserAsync(User user, CancellationToken token)
    {
        return await _iUserRepository.CreateUserAsync(user, token);
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token)
    {
        return await _iUserRepository.GetAllUsers(token);
    }
}