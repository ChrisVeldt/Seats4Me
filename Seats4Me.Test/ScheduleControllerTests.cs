using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Utils;
using Seats4Me.Controllers;

namespace Seats4Me.Test
{
    public class ScheduleControllerTests
    {
        private readonly Mock<IScheduleService> _mockService = new Mock<IScheduleService>();
        private readonly Mock<IUrlHelper> _mockUrlHelper = new Mock<IUrlHelper>();

        [Fact]
        public async void GetScheduleForThisWeekTestAsync()
        {
            var controller = new ScheduleController(_mockService.Object, _mockUrlHelper.Object);

            var result = await controller.GetScheduleAsync("week", new DateTime(2018, 4, 19));

            _mockService.Verify(s => s.GetScheduleAsync(It.Is<string>(fd => fd == "week"), It.Is<DateTime>(fd => fd == new DateTime(2018, 4, 19))));
        }

        [Fact]
        public async void GetScheduleForAllTestAsync()
        {
            var controller = new ScheduleController(_mockService.Object, _mockUrlHelper.Object);

            var result = await controller.GetScheduleAsync("all", new DateTime(2018, 1, 1));

            _mockService.Verify(s => s.GetScheduleAsync(It.Is<string>(fd => fd == "all"), It.Is<DateTime>(fd => fd == new DateTime(2018, 1, 1))));
        }
    }
}
