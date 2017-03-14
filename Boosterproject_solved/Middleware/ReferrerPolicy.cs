using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Boosterproject
{
    public class ReferrerPolicyMiddleware
    {
        private readonly RequestDelegate _next;

        public ReferrerPolicyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {   
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");

            await _next.Invoke(context);
        }
    }

    public static class ReferrerPolicyMiddlewareExtensions
    {
        public static IApplicationBuilder UseReferrerPolicysMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReferrerPolicyMiddleware>();
        }
    }
}