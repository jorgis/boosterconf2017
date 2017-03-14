using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class AntiXssHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public AntiXssHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {   
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");

            await _next.Invoke(context);
        }
    }

    public static class AntiXssHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseAntiXssHeadersMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AntiXssHeadersMiddleware>();
        }
    }
}