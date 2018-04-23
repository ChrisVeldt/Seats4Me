using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Seats4Me.Test.Utils;
using Seats4Me.ViewModel;
using Xunit;

namespace Seats4Me.Test
{
    public class TicketControllerE2ETests : IClassFixture<ApiTestClient>
    {
        private readonly ApiTestClient _client;

        public TicketControllerE2ETests(ApiTestClient client)
        {
            _client = client;
        }

        [Fact]
        public async void PostTicket()
        {
            var jsonContent = "{ticketId: 9," +
                              " CustomerName: \"Tjalle\"," +
                              " OrderDate: \"2018-02-23T20:00:00\"," +
                              " Seats: 2," +
                              " Paid: true," +
                              " ScheduleId: 1" +
                              "}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = await _client.Seats4MeClient.PostAsync("api/ticket", content);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var resultBody = await result.Content.ReadAsStringAsync();
            Assert.Contains("2", resultBody);

        }
    }
}
