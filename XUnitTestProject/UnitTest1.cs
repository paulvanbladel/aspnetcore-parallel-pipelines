using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication2;
using WebApplication2.Controllers;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTest1()
        {
            _server = new TestServer(
                new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }
        [Fact]
        public async Task ThisWorksGreat()
        {
            var response = await _client.GetAsync("/admin/admindata");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("I'm Admin Data Controller. " + "Hi from Admin Service", responseString);
        }

        [Fact]
        public void WeHaveAProblemWhenResolvingServices()
        {
            var result = _server.Host.Services.GetService(typeof(IHiService));
            Assert.NotNull(result);
        }
    }
}
