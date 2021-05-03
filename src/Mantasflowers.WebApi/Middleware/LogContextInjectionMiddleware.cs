using System.Threading.Tasks;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Mantasflowers.WebApi.Middleware
{
    public class LogContextInjectionMiddleware
    {
        private readonly RequestDelegate _next;

        public LogContextInjectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string userUid = null;
            string userRole = null;

            try
            {
                userUid = context.User.GetUid();
                userRole = context.User.GetRole();
            }
            catch {}

            using (LogContext.PushProperty("userUid", userUid))
            using (LogContext.PushProperty("userRole", userRole))
            {
                await _next(context);
            }
        }
    }
}