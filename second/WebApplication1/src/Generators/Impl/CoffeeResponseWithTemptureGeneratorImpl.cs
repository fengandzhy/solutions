using WebApplication1.Generators;
using WebApplication1.Models;
using WebApplication1.src.Services;

namespace WebApplication1.src.Generators.Impl
{
    public class CoffeeResponseWithTemptureGeneratorImpl : ICoffeeResponseGenerator
    {
        private readonly IWeatherService _weatherService;
        private double _tempeturate = 0;
        private Timer _timer;

        public CoffeeResponseWithTemptureGeneratorImpl(IWeatherService weatherService)
        {
            _weatherService = weatherService;

            _timer = new Timer(
                callback: UpdateTemperature,
                state: null,
                dueTime: TimeSpan.Zero,   
                period: TimeSpan.FromHours(2)); 
        }

        public void UpdateTemperature(object state)
        {               
            string city = "Hamilton";
            _tempeturate = _weatherService.GetTempeturate(city);           
        }

        public CoffeeResponse BrewCoffee(string message, string time)
        {
            if (_tempeturate > 30)
            {
                return new CoffeeResponse("Your refreshing iced coffee is ready", time);
            }     

            return new CoffeeResponse(message, time);
        }
    }
}
