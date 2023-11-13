using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using DataAccess;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));

builder.Services.AddTransient<IAppDbContext, AppDbContext>();
builder.Services.AddTransient<IPostRepository, EFCorePostRepository>();
builder.Services.AddTransient<IPostService, PostService>();


builder.Services.AddControllers();


WebApplication app = builder.Build();


app.MapControllers();




app.Run();
