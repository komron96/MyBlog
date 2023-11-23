using Microsoft.AspNetCore.Authentication;
namespace WebApi;

public sealed class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string ApiKeyScheme = "ApiKeyScheme";
    public readonly string ApiKey = "Pass";
}
