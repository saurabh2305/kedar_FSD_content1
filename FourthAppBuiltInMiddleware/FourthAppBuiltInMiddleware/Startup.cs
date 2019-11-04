using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace FourthAppBuiltInMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = "Production";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseExceptionHandler(appbuilder=> {
                //    appbuilder.Run(async (httpContext) =>
                //      {
                //          httpContext.Response.Headers.Add("Content-Type", "text/html");
                //          await httpContext.Response.WriteAsync("<h2>Error Occured</h2>");
                //          await httpContext.Response.WriteAsync("<p>Internal Server Error</p>");

                //      });
                //});
            }
            app.UseHttpsRedirection();

            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("hello.html");
            //app.UseDefaultFiles(options);
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    RequestPath = "/files",
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "files"))
            //});
            // This is combination of static file enable,directory browsing and default file with one middleware
            app.UseFileServer(new FileServerOptions()
            {
                RequestPath = "/files",
                EnableDirectoryBrowsing = true,
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files")) 
            });
            //app.UseStaticFiles(); // wwwroot static files
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    RequestPath = "/docs",
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "files"))

            //});
            app.UseCookiePolicy(); //Asks permission to create cookies to  end user

            app.UseMvcWithDefaultRoute(); // this can be used for below app.UseMvc

            //app.UseMvc(routes =>
            //{
            //    //routes.MapRoute(
            //    //    name: "productRoute",
            //    //    template: "admin/products/{action=Index}/{id?}");
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
