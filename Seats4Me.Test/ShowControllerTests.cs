using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Controllers;
using Xunit;

namespace Seats4Me.Test
{
    public class ShowControllerTests
    {
        private readonly Mock<IShowService> _mockService = new Mock<IShowService>();

        [Fact]
        public async void GetScheduleForThisWeekAsyncTest()
        {
            var controller = new ShowController(_mockService.Object);

            var result = await controller.GetShowAsync(2);

            _mockService.Verify(s => s.GetShowAsync(It.Is<int>(i => i == 2)));
        }

    }
}
