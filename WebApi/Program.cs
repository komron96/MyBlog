using BusinessLogic;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapControllers();

app.Run();
