using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace TimeInAngle.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new { Message = "An unexpected error occurred." }.ToString() ?? string.Empty);

                // Log the exception
                var logger = context.RequestServices.GetRequiredService<ILogger<ExceptionMiddleware>>();
                logger.LogError(ex, "An unhandled exception occurred.");
            }
        }
    }
}