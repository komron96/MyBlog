using System.Net;
using BusinessLogic;
namespace WebApi;


public sealed class NotFoundPageMiddleware
{
    private readonly RequestDelegate _next;
    public NotFoundPageMiddleware(RequestDelegate next)
    {
        _next = next;
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


    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex, CancellationToken token)
    {
        var errorResponse = ex switch
        {
            ResourceNotFoundException => new {StatusCode = HttpStatusCode.NotFound, isSuccesfull = false, Message = "Not found page" }
        };
                //здесь определяется какой вид ответа должен быть с каким кодом
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)errorResponse.StatusCode;

        //Возвращает результат в виде json
        return httpContext.Response.WriteAsJsonAsync(errorResponse, token);
    }
}