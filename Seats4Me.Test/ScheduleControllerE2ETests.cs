using Seats4Me.Test.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Seats4Me.Test
{
    public class ScheduleControllerE2ETests :IClassFixture<ApiTestClient>
    {
        private readonly ApiTestClient _client;

        public ScheduleControllerE2ETests(ApiTestClient client)
        {
            _client = client;
        }

        [Fact]
        public async Task GetScheduleAllAsync()
        {
            var result = await _client.Seats4MeClient.GetAsync("/api/schedule?period=week&date=2018-04-24");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var resultBody = await result.Content.ReadAsStringAsync();
            Assert.Contains("Led Zep", resultBody);
            Assert.Contains("period=week&date=2018-04-16", resultBody);
            Assert.Contains("period=week&date=2018-04-30", resultBody);
        }

        [Fact]
        public async Task GetScheduleNoResultAsync()
        {
            var result = await _client.Seats4MeClient.GetAsync("/api/schedule?period=week&date=2019-04-24");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var resultBody = await result.Content.ReadAsStringAsync();
            Assert.Contains("period=week&date=2019-04-15", resultBody);
            Assert.Contains("period=week&date=2019-04-29", resultBody);
        }

    }
}
