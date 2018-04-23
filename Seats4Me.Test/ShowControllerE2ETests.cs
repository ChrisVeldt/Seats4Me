using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Seats4Me.Test.Utils;
using Xunit;

namespace Seats4Me.Test
{
    public class ShowControllerE2ETests : IClassFixture<ApiTestClient>
    {
        private readonly ApiTestClient _client;

        public ShowControllerE2ETests(ApiTestClient client)
        {
            _client = client;
        }

        [Fact]
        public async void GetShowLedZepAsync()
        {
            var result = await _client.Seats4MeClient.GetAsync("api/show/4");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var resultBody = await result.Content.ReadAsStringAsync();
            Assert.Contains("Led Zep", resultBody);
        }

        [Fact]
        public async void GetShowNoResultAsync()
        {
            var result = await _client.Seats4MeClient.GetAsync("api/show/0");

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
