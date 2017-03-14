using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class CspHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public CspHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
                        
            //context.Response.Headers.Add("Content-Security-Policy", "script-src 'self'");            
            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self'; report-uri https://boosterconf.report-uri.io/r/default/csp/enforce");            

            await _next.Invoke(context);
        }
    }

    public static class CspHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder CspHeadersMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CspHeadersMiddleware>();
        }
    }
}
