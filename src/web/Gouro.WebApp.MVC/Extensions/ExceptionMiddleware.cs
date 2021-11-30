using Microsoft.AspNetCore.Http;
using Polly.CircuitBreaker;
using Refit;
using System.Net;
using System.Threading.Tasks;

namespace Gouro.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpRequestException e)
            {
                HandleRequestExceptionAsync(httpContext, e.StatusCode);
            }
            catch (ValidationApiException e)
            {
                HandleRequestExceptionAsync(httpContext, e.StatusCode);
            }
            catch (ApiException e)
            {
                HandleRequestExceptionAsync(httpContext, e.StatusCode);
            }
            catch (BrokenCircuitException)
            {
                HandleCircuitBreakerExceptionAsync(httpContext);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext context, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)statusCode;
        }

        private static void HandleCircuitBreakerExceptionAsync(HttpContext context)
        {
            context.Response.Redirect("/sistema-indisponivel");
        }
    }
}
