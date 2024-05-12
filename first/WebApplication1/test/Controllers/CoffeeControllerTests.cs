using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.test.Controllers
{
    public class CoffeeControllerTests
    {
        [Fact]
        public void BrewCoffee_ReturnsOkResult_WithCoffeeData()
        {
            // Arrange
            var mockService = new Mock<ICoffeeService>();
            var coffeeData = new CoffeeResponse ( "Freshly brewed coffee","Hot");
            mockService.Setup(service => service.BrewCoffee()).Returns(coffeeData);

            var controller = new CoffeeController(mockService.Object);

            // Act
            var result = controller.BrewCoffee();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<CoffeeResponse>(okResult.Value);
            Assert.Equal("Freshly brewed coffee", returnValue.Message);
            Assert.Equal("Hot", returnValue.Prepared);
        }
    }
}
