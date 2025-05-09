using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace SuperMarket.Infrastructure.MiddleWares
{
    public class GlobalValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalValidationExceptionMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                });

                var response = new
                {
                    Message = "Validation Failed",
                    Errors = errors
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }

        }
    }
}
