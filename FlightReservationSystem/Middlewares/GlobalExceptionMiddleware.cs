using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlightReservationSystem.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // Extract inner exception details
            var innerMessage = ex.InnerException?.Message;
            var innerStack = ex.InnerException?.StackTrace;

            object response;

            if (_env.IsDevelopment())
            {
                response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                    InnerMessage = innerMessage,
                    StackTrace = ex.StackTrace,
                    InnerStackTrace = innerStack
                };
            }
            else
            {
                response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error. Please try again later."
                };
            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
