using System.Net;
using BusinessLogic;

namespace WebApi;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, httpContext.RequestAborted);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex, CancellationToken token = default)
    {
        _logger.LogError(ex, "Failed to execute the request.");

        var errorResponse = ex switch
        {
            PostNotFoundException _ => new { StatusCode = HttpStatusCode.NotFound, IsSuccessful = false, Message = "Post not found in Database !" },
            UserNotFoundException _ => new { StatusCode = HttpStatusCode.NotFound, IsSuccessful = false, Message = "User not found in Database ALO SISKI!" },
            NotAuthorized _ => new { StatusCode = HttpStatusCode.Unauthorized, IsSuccessful = false, Message = "User is not authorized." },
            BadRequestException _ => new { StatusCode = HttpStatusCode.BadRequest, IsSuccessful = false, Message = "Something gone wrong with request, check your sending information" },
            _ => new { StatusCode = HttpStatusCode.InternalServerError, IsSuccessful = false, Message = "Failed to execute the request, error: " + ex.Message }
        };


        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)errorResponse.StatusCode;
        return httpContext.Response.WriteAsJsonAsync(errorResponse, token);
    }
}