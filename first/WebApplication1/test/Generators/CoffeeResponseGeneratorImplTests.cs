using WebApplication1.Generators.Impl;
using Xunit;

namespace WebApplication1.test.Generators
{
    public class CoffeeResponseGeneratorImplTests
    {
        [Fact]
        public void BrewCoffee_ReturnsCoffeeResponse_WithCorrectProperties()
        {
            // Arrange
            var generator = new CoffeeResponseGeneratorImpl();
            var expectedMessage = "Test coffee message";
            var expectedTime = "2021-01-01T12:00:00Z";

            // Act
            var response = generator.BrewCoffee(expectedMessage, expectedTime);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(expectedMessage, response.Message);
            Assert.Equal(expectedTime, response.Prepared);
        }
    }
}
