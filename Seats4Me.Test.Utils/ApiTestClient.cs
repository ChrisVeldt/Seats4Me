using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Seats4Me.Test.Utils
{
    public class ApiTestClient : IDisposable
    {
        public HttpClient Seats4MeClient { get; private set; }

        public ApiTestClient()
        {
            var webHostBuilder = new WebHostBuilder().UseEnvironment("Debug").UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, true);
                });

            var server = new TestServer(webHostBuilder);
            Seats4MeClient = server.CreateClient();

        }

        public void Dispose()
        {
            Seats4MeClient.Dispose();
        }

    }
}
