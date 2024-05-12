using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;
        
        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("brew-coffee")]
        public ActionResult<CoffeeResponse> BrewCoffee()
        {
            CoffeeResponse coffeeResponse = _coffeeService.BrewCoffee();
            return Ok(coffeeResponse);
        }
    }
}
