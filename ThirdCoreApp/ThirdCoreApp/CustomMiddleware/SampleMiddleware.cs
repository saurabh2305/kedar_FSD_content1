using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdCoreApp.CustomMiddleware
{
    public class SampleMiddleware
    {
        private RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<br/>Form sample Middleware - Request");
            await _next.Invoke(context);
            await context.Response.WriteAsync("<br/>Form sample Middleware - Response");
        }
    }
    // Extension Method on IApplicationBuilder type
    public static class MiddlewareExtensions
    {
        public static void UseSample(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SampleMiddleware>();
        }
    }
}
