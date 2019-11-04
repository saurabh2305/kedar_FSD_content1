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

namespace ConfiguraionDemo
{
    public class Startup
    {
        private static Dictionary<string, string> configData = new Dictionary<string, string>();
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup()
        {
            // own configuration object is created to give environment variables first priority
            configData.Add("Projector", "Epson");
            configData.Add("Mobile", "Samsung");
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddInMemoryCollection(configData)
                .AddJsonFile("appSettings.json", optional: true)
                .AddJsonFile("mysettings.json", optional: true)
                .AddXmlFile("mysettings.xml", optional: true)
                .AddEnvironmentVariables("ASPNETCORE_");
            //AddEnvironmentVariables("ASPNETCORE_"); ENVIRONMENT VARIABLE RELATED TO ASPNET CORE
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfiguration>(Configuration); // register AppConfiguration custom class as service

            var arch = Configuration.GetValue<string>("PROCESSOR_ARCHITECTURE");
            services.Configure<ProjectDetails>(Configuration.GetSection("ProjectDetails"));
            var data = Configuration.GetSection("abc");
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
