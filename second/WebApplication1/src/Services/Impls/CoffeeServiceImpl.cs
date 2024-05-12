using WebApplication1.Exceptions;
using WebApplication1.Generators;
using WebApplication1.Models;
using WebApplication1.src.Utils;

namespace WebApplication1.Services.Impls
{
    public class CoffeeServiceImpl : ICoffeeService
    {
        private readonly ICoffeeResponseGenerator _coffeeResponseGenerator;
        private readonly ILogger<CoffeeServiceImpl> _logger;
        private readonly ISystemTime _systemTime;
        private static readonly object LockObject = new object();
        private int _requestCount = 0;

        public CoffeeServiceImpl(ICoffeeResponseGenerator coffeeResponseGenerator, ILogger<CoffeeServiceImpl> logger, ISystemTime systemTime)
        {
            _coffeeResponseGenerator = coffeeResponseGenerator;
            _logger = logger;
            _systemTime = systemTime;
        }

        public CoffeeResponse BrewCoffee()
        {
            _logger.LogInformation("Starting to brew coffee");
            var now = _systemTime.UtcNow;
            if (now.Month == 4 && now.Day == 1)
            {
                throw new AprilFoolsException("No coffee on April Fools!");
            }

            int currentCount;
            lock (LockObject)
            {
                _requestCount++;
                currentCount = _requestCount;
            }

            if (currentCount % 5 == 0)
            {
                throw new CoffeeDepletedException("Coffee supply depleted");
            }

            string currentTime = now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return _coffeeResponseGenerator.BrewCoffee("Your piping hot coffee is ready", currentTime);
        }
    }
}
