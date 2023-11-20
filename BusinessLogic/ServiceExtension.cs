using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDataAccess(configuration);

        services.AddTransient<IPostService, PostService>();
        services.AddTransient<IUserService, UserService>();
    }
} 