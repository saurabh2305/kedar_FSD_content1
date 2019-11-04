using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SecondCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/about", (appContext) =>
            { 
              appContext.Use(async (httpContext, next) =>
              {
                  await httpContext.Response.WriteAsync("<br>About - Middleware 1 req");
                  await next.Invoke();
                  await httpContext.Response.WriteAsync("<br>About - Middleware 1 resp");
              });

                appContext.Use(async (httpContext, next) =>
                {
                    await httpContext.Response.WriteAsync("<br>About - Middleware 2 req");
                    await next.Invoke();
                    await httpContext.Response.WriteAsync("<br>About - Middleware 2 resp");
                });

                appContext.Run(async (httpContext) =>
                {
                    await httpContext.Response.WriteAsync("<br>About - Middleware 3 req");                   
                    await httpContext.Response.WriteAsync("<br>About - Middleware 3 resp");
                });

            });

            app.Map("/contact", (appContext) =>
            {
                appContext.Use(async (httpContext, next) =>
                {
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 1 req");
                    await next.Invoke();
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 1 resp");
                });

                appContext.Use(async (httpContext, next) =>
                {
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 2 req");
                    await next.Invoke();
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 2 resp");
                });

                appContext.Run(async (httpContext) =>
                {
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 3 req");                  
                    await httpContext.Response.WriteAsync("<br>Contact - Middleware 3 resp");
                });               
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<br/>Home Page request");
                await next.Invoke();
                await context.Response.WriteAsync("<br/>Home page Response ");
            });

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Type", "text/plain");
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<br/>From Middleware 1 Request");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("<br/>From Middleware 1 Response");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<br/>From Middleware 2 Request");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("<br/>From Middleware 2 Response");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<br/>From Middleware 3 Request");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("<br/>From Middleware 3 Response");
            //});

            app.MapWhen((context) => context.Request.Query["lang"] == "en", (appContext) =>
                {
                    appContext.Run(async (httpContext) =>
                    {
                        await httpContext.Response.WriteAsync("<h2> English Home Page</h2>");
                    });
                });
            app.MapWhen((context) => context.Request.Query["lang"] == "hi", (appContext) =>
            {
                appContext.Run(async (httpContext) =>
                {
                    await httpContext.Response.WriteAsync("<h2> Hindi Home Page</h2>");
                });
            });


            app.Run(async (context) => // terminator
            {
                await context.Response.WriteAsync("<br/>Hello World!");
            });
        }
    }
}
