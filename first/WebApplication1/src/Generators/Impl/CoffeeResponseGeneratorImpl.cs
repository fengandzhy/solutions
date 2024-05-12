using WebApplication1.Models;

namespace WebApplication1.Generators.Impl
{
    public class CoffeeResponseGeneratorImpl : ICoffeeResponseGenerator
    {
        public CoffeeResponse BrewCoffee(string message, string time)
        {
            return new CoffeeResponse(message, time);
        }
    }
}
