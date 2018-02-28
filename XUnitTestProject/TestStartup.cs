
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2;
using WebApplication2.Controllers;

namespace XUnitTestProject
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration) { }

        //public override void AddAdminService(IServiceCollection services)
        //{
        //    services.AddTransient<IHiService, AdminService2>();
        //}
    }
}