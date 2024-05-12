using WebApplication1.Models;

namespace WebApplication1.Generators
{
    public interface ICoffeeResponseGenerator
    {
        CoffeeResponse BrewCoffee(string message, string time);
    }
}
