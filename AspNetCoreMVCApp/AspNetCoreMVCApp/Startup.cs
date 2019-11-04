using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCApp.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMVCApp
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();

            //services.AddDistributedMemoryCache();
            //Actual distributed sql server cache
            services.AddDistributedSqlServerCache(config =>
            {
                config.TableName = "CacheTable22";
                config.SchemaName = "dbo";
                config.ConnectionString = Configuration.GetConnectionString("sqlConnection");
            });
            // Redis cache
            //services.AddStackExchangeRedisCache(config =>
            //{
            //    config.InstanceName = Configuration.GetValue<string>("Redis:InstanceName");
            //    config.Configuration = Configuration.GetValue<string>("Redis:Configuration");
            //});
            services.AddSession(config=>
            {
                config.Cookie.Name = "MySessionCookie";
                config.Cookie.HttpOnly = true;
                config.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                config.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });
            services.AddSingleton<DataService>();

            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("x-samplekey"))
                {
                    // form validation header checking done here
                    context.Items["IsVerified"] = true;
                    context.Items["Description"] = "Request is verified for forgery checking";
                }
                else
                {
                    context.Items["IsVerified"] = false;
                }
                    await next.Invoke();
            });
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();     // middleware for session
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
