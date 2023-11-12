using BusinessLogic;
using Microsoft.EntityFrameworkCore;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));

builder.Services.AddTransient<IPostService, PostService>();

builder.Services.AddControllers();


WebApplication app = builder.Build();


app.MapControllers();




app.Run();
