using FluentValidation;
using System.Text.Json;

namespace Fitcore.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ett fel inträffade.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new { error = "Ett internt fel inträffade." };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (exception is ValidationException validationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var errors = validationException.Errors.Select(e => e.ErrorMessage);

                var validationResponse = new { error = "Valideringsfel", details = errors };
                return context.Response.WriteAsync(JsonSerializer.Serialize(validationResponse));
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}