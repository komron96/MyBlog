using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
namespace WebApi;
public sealed class ApiKeyAuthentificationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
{
    private readonly ApiKeyAuthenticationOptions _apiKeyOptions;
    // private readonly ILogger<ApiKeyAuthentificationHandler> _logger;

    public ApiKeyAuthentificationHandler(
        IOptionsMonitor<ApiKeyAuthenticationOptions> optionsMonitor,
        ILoggerFactory loggerFactory,
        UrlEncoder urlEncoder,
        ISystemClock clock)
        : base(optionsMonitor, loggerFactory, urlEncoder, clock)
    {
        _apiKeyOptions = optionsMonitor.CurrentValue;
        // _logger = loggerFactory.CreateLogger<ApiKeyAuthentificationHandler>();
    }
    
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //Валидация в заголовке ApiKey, если нету то говорим что его нет
        if (!Request.Headers.ContainsKey(Constants.ApiKeyName))
            return AuthenticateResult.Fail($"{Constants.ApiKeyName} not provided in request headers!");

        //Если есть в заговолках есть ключ то проверяем его корректность
        string? providedApiKey = Request.Headers[Constants.ApiKeyName];
        if (string.IsNullOrEmpty(providedApiKey) || !providedApiKey.Equals(_apiKeyOptions.ApiKey))
            return AuthenticateResult.Fail($"{Constants.ApiKeyName} not valid!");

        //В случае успеха
        return AuthenticateResult.Success(new(GetUserClaims(), Scheme.Name));
    }


    private ClaimsPrincipal GetUserClaims()
    {
        Claim[] claims = new[] {new Claim("AuthentificatedAt", DateTime.Now.ToString())};
        ClaimsIdentity claimsIdentity = new(claims, Scheme.Name);
        return new(claimsIdentity);
    }
}