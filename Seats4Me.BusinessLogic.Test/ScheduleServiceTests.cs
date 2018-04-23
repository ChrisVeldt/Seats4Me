using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Seats4Me.DataAccess.Interfaces;
using Xunit;
using Seats4Me.BusinessLogic.Services;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Extensions;
using Seats4Me.Common.Utils;

namespace Seats4Me.BusinessLogic.Test
{
    public class ScheduleServiceTests
    {
        private readonly Mock<IScheduleRepository> _mockRepository = new Mock<IScheduleRepository>();

        public ScheduleServiceTests()
        {
        }

        [Fact]
        public async void GetScheduleAsync()
        {
            var service = new ScheduleService(_mockRepository.Object);
            var from = new DateTime(2018, 4, 16);
            var until = new DateTime(2018, 4, 22);

            var result = await service.GetScheduleAsync("week", new DateTime(2018, 4, 19));

            _mockRepository.Verify(r => r.GetScheduleAsync(It.Is<DateTime>(fd => fd == from), It.Is<DateTime>(ud => ud == until)), Times.Once);
        }

    }
}
