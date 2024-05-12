using Moq;
using WebApplication1.src.Generators.Impl;
using WebApplication1.src.Services;
using Xunit;

namespace WebApplication1.test.Generators
{
    public class CoffeeResponseWithTemperatureGeneratorImplTests
    {
        private readonly Mock<IWeatherService> _mockWeatherService;
        private readonly CoffeeResponseWithTemptureGeneratorImpl _generator;

        public CoffeeResponseWithTemperatureGeneratorImplTests()
        {
            _mockWeatherService = new Mock<IWeatherService>();
            _generator = new CoffeeResponseWithTemptureGeneratorImpl(_mockWeatherService.Object);
        }

        [Fact]
        public void BrewCoffee_ReturnsIcedCoffee_WhenTemperatureAbove30()
        {
            
            _mockWeatherService.Setup(service => service.GetTempeturate(It.IsAny<string>())).Returns(31); 
            _generator.UpdateTemperature(null); 

            
            var result = _generator.BrewCoffee("Default hot coffee message", "10:00 AM");

            
            Assert.Equal("Your refreshing iced coffee is ready", result.Message);
        }

        [Fact]
        public void BrewCoffee_ReturnsHotCoffee_WhenTemperatureBelow30()
        {
            
            _mockWeatherService.Setup(service => service.GetTempeturate(It.IsAny<string>())).Returns(20); // Temperature below 30
            _generator.UpdateTemperature(null); // Manually trigger the update

           
            var result = _generator.BrewCoffee("Default hot coffee message", "10:00 AM");

            
            Assert.Equal("Default hot coffee message", result.Message);
        }
    }
}
