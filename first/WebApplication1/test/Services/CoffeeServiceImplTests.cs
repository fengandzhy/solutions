using Moq;
using WebApplication1.Exceptions;
using WebApplication1.Generators;
using WebApplication1.Models;
using WebApplication1.Services.Impls;
using Xunit;
using System;
using WebApplication1.src.Utils;

namespace WebApplication1.test.Services
{
    public class CoffeeServiceImplTests
    {
        private readonly Mock<ICoffeeResponseGenerator> _mockGenerator;
        private readonly Mock<ILogger<CoffeeServiceImpl>> _mockLogger;
        private readonly Mock<ISystemTime> _mockSystemTime;
        private readonly CoffeeServiceImpl _service;

        public CoffeeServiceImplTests()
        {
            _mockGenerator = new Mock<ICoffeeResponseGenerator>();
            _mockLogger = new Mock<ILogger<CoffeeServiceImpl>>();
            _mockSystemTime = new Mock<ISystemTime>();
            _service = new CoffeeServiceImpl(_mockGenerator.Object, _mockLogger.Object, _mockSystemTime.Object);
        }

        [Fact]
        public void BrewCoffee_ThrowsAprilFoolsException_OnAprilFoolsDay()
        {
            
            _mockSystemTime.Setup(t => t.UtcNow).Returns(new DateTime(2022, 4, 1));
            
            Assert.Throws<AprilFoolsException>(() => _service.BrewCoffee());
        }

        [Fact]
        public void BrewCoffee_ThrowsCoffeeDepletedException_WhenRequestCountIsMultipleOfFive()
        {
            // Arrange
            for (int i = 0; i < 4; i++) // Increment count to 4
            {
                _service.BrewCoffee();
            }

            // Act & Assert
            Assert.Throws<CoffeeDepletedException>(() => _service.BrewCoffee());
        }

        [Fact]
        public void BrewCoffee_ReturnsCoffeeResponse_OnNormalConditions()
        {
            // Arrange
            var expectedResponse = new CoffeeResponse("Your piping hot coffee is ready", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            _mockGenerator.Setup(g => g.BrewCoffee(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResponse);

            // Act
            var result = _service.BrewCoffee();

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
