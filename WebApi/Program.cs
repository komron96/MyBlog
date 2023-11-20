using BusinessLogic;
using WebApi;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(Constants.ConnectionStringsSectionName));

// builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddAuthentication
    (ApiKeyAuthenticationOptions.ApiKeyScheme)
        .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthentificationHandler>(ApiKeyAuthenticationOptions.ApiKeyScheme,
            options => { });



builder.Services.AddControllers();

WebApplication app = builder.Build();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

