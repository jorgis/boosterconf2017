using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class XContentTypeOptionMiddleware
    {
        private readonly RequestDelegate _next;

        public XContentTypeOptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {                  
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            await _next.Invoke(context);
        }
    }

    public static class XContentTypeOptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseXContentTypeOptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<XContentTypeOptionMiddleware>();
        }
    }
}