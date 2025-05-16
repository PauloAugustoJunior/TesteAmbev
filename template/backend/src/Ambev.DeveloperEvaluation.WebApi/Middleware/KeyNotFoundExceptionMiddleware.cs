using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public class KeyNotFoundExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<KeyNotFoundExceptionMiddleware> _logger;

        public KeyNotFoundExceptionMiddleware(RequestDelegate next, ILogger<KeyNotFoundExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource not found");
                await HandleExceptionAsync(
                    context,
                    ex.GetType().Name,
                    "Resource not found",
                    ex.Message,
                    HttpStatusCode.NotFound
                );
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string type, string error, string detail, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new
            {
                type,
                error,
                detail
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }
    }
}
