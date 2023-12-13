using System.Net;
using UniversityManagement.API.Exceptions;
using System.Text.Json;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }   

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                 await next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            switch (ex)
            {
                case NotFoundException _:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case BadRequestException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case DivideByZeroException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case UnauthorizedAccessException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case Exceptions.NotImplementedException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case Exceptions.KeyNotFoundException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
            }
            var errorResponse = new ErrorResponse
            {
                statusCode = statusCode,
                Message = ex.Message,
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());

        }
    }

    // Extenstion method for this middleware

    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder ConfigureExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<ExceptionMiddleware>();
    }
}