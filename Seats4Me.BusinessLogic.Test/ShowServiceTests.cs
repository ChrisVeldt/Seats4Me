using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Seats4Me.BusinessLogic.Services;
using Seats4Me.DataAccess.Interfaces;
using Xunit;

namespace Seats4Me.BusinessLogic.Test
{
    public class ShowServiceTests
    {
        private readonly Mock<IShowRepository> _mockRepository = new Mock<IShowRepository>();

        [Fact]
        public async void GetShowAsync()
        {
            var service = new ShowService(_mockRepository.Object);

            var result = await service.GetShowAsync(2);

            _mockRepository.Verify(r => r.GetShowAsync(It.Is<int>(i => i == 2)));
        }
    }
}
