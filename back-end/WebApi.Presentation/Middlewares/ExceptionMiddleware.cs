using System.Net;
using BLL.Exceptions;

namespace WebApi.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "text/plain";

            _logger.LogWarning("Error occured: {ErrorMessage}", exception.Message);

            switch (exception)
            {
                case AuthorizationException:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    var message = string.IsNullOrEmpty(exception.Message)
                        ? "Access denied"
                        : exception.Message;
                    await context.Response.WriteAsync(message);
                    break;
                }
                case NotFoundException:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    var message = string.IsNullOrEmpty(exception.Message)
                        ? "Not found"
                        : exception.Message;
                    await context.Response.WriteAsync(message);
                    break;
                }
                case ForbiddenException:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    var message = string.IsNullOrEmpty(exception.Message)
                        ? "Forbidden"
                        : exception.Message;
                    await context.Response.WriteAsync(message);
                    break;
                }
                case WrongActionException:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var message = string.IsNullOrEmpty(exception.Message)
                        ? "Wrong Action"
                        : exception.Message;
                    await context.Response.WriteAsync(message);
                    break;
                }
                default:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var message = string.IsNullOrEmpty(exception.Message)
                        ? "Internal server error"
                        : exception.Message;
                    await context.Response.WriteAsync(message);
                    break;
                }
            }
        }
    }
}
