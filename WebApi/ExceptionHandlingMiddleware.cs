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


    //Определение того последовательность работы у мидлвейра через invoke
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
            ResourceNotFoundException => new { StatusCode = HttpStatusCode.NotFound, IsSuccessful = false, Message = "We are sorry, the page you requested cannot be found." },
            NotFoundEntity notFoundEntity => new { StatusCode = HttpStatusCode.NotFound, IsSuccessful = false,  notFoundEntity.Message },
            NotAuthorized => new { StatusCode = HttpStatusCode.Unauthorized, IsSuccessful = false, Message = "User is not authorized." },
            BadRequestException => new { StatusCode = HttpStatusCode.BadRequest, IsSuccessful = false, Message = "Something gone wrong with request, check your sending information" },
            _ => new { StatusCode = HttpStatusCode.InternalServerError, IsSuccessful = false, Message = "Failed to execute the request, error: " + ex.Message }
        };

        //здесь определяется какой вид ответа должен быть с каким кодом
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)errorResponse.StatusCode;

        //Возвращает результат в виде json
        return httpContext.Response.WriteAsJsonAsync(errorResponse, token);
    }
}