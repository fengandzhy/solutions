using System.Net;
using WebApplication1.Exceptions;

namespace WebApplication1.Middlewave
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "text/plain";

            switch (ex)
            {
                case CoffeeDepletedException:
                    context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable; // 503
                    return context.Response.WriteAsync(ex.Message);

                case AprilFoolsException:
                    context.Response.StatusCode = 418; // I'm a teapot
                    return context.Response.WriteAsync(ex.Message);

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
                    return context.Response.WriteAsync("An unexpected error occurred.");
            }            
        }
    }
}
