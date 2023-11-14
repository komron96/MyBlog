using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();
        services.ConfigureDataAccess();
    }
}