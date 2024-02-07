using BusinessLogic;
using WebApi;

//Builer - конфигурация приложения
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(Constants.ConnectionStringsSectionName));
builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddAuthentication
    (ApiKeyAuthenticationOptions.ApiKeyScheme)
        .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthentificationHandler>(ApiKeyAuthenticationOptions.ApiKeyScheme,
            options => { });


builder.Services.AddControllers();



//Запуск приложения
WebApplication app = builder.Build();

//Мидлвейр для обработки исключений
app.UseMiddleware<ExceptionHandlingMiddleware>();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


