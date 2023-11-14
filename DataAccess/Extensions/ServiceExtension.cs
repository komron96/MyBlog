using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class ServiceExtension
{
    public static void ConfigureDataAccess(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));
        services.AddScoped<IPostRepository, EFCorePostRepository>();
    }
}