using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class XFrameOptionMiddleware
    {
        private readonly RequestDelegate _next;

        public XFrameOptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
                        
            context.Response.Headers.Add("X-Frame-Options", "DENY");            

            await _next.Invoke(context);
        }
    }

    public static class XFrameOptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseXFrameOptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<XFrameOptionMiddleware>();
        }
    }
}