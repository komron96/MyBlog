using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess;

public static class ServiceExtension
{
    private static string DefaultConnectionKeyName => "DefaultConnection";
    public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));
        // services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString(DefaultConnectionKeyName)));
        services.AddScoped<IPostRepository, EFCorePostRepository>();
        services.AddScoped<IUserRepository, EFCoreUserRepository>();
    }
}