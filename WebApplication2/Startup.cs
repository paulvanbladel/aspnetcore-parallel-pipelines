using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication2.Controllers;
using Microsoft.AspNetCore.Http;
// using WebApiContrib.Core;

namespace WebApplication2
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public virtual void AddAdminService(IServiceCollection services)
        {
            services.AddTransient<IHiService, AdminService>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseBranchWithServices("/admin",
                s =>
                {
                    //s.AddTransient<IHiService, AdminService>();
                    AddAdminService(s);
                    s.AddMvc()
                    .ConfigureApplicationPartManager(manager =>
                    {
                       manager.FeatureProviders.Clear();
                       manager.FeatureProviders.Add(new TypedControllerFeatureProvider<DashboardController>());
                    })
                    ;
                },
                a =>
                {
                    a.Use(async (c, next) =>
                    {
                        if (c.Request.Path.ToString().Contains("foo"))
                        {
                            await c.Response.WriteAsync("bar!");
                        }
                        else
                        {
                            await next();
                        }
                    });

                    a.UseMvc();
                });

            //app.UseBranchWithServices("/api",
            //    s =>
            //    {
            //        s.AddTransient<IHiService, ResourceService>();
            //        s.AddMvc().ConfigureApplicationPartManager(manager =>
            //        {
            //            manager.FeatureProviders.Clear();
            //            manager.FeatureProviders.Add(new TypedControllerFeatureProvider<MyApiController>());
            //        });
            //    },
            //    a =>
            //    {
            //        a.UseMvc();
            //    });

            app.Run(async c =>
            {
                await c.Response.WriteAsync("Nothing here!");
            });
        }
    }
}
