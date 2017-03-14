using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class HSTSHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HSTSHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {                        
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");          
            await _next.Invoke(context);
        }
    }

    public static class HSTSHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder HSTSHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HSTSHeaderMiddleware>();
        }
    }
}