using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class HPKPHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public HPKPHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {   
            context.Response.Headers.Add("Public-Key-Pins", "pin-sha256=\"Y9mvm0exBk1JoQ57f9Vm28jKo5lFm/woKcVxrYxu80o=\"; pin-sha256=\"CzdPous1hY3sIkO55pUH7vklXyIHVZAl/UnprSQvpEI=\"; max-age=2592000; includeSubDomains; report-uri=\"https://boosterconf.report-uri.io/r/default/hpkp/enforce\"");

            await _next.Invoke(context);
        }
    }

    public static class HPKPHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseHPKPHeadersMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HPKPHeadersMiddleware>();
        }
    }
}