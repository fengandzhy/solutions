## Technical Description and Key Steps

### Overview

The coffee brewing process involves accessing a third-party API to retrieve the temperature of the current city, which determines the brewing logic. To manage this efficiently without making extensive changes to the existing synchronous system, a timer-based solution has been implemented.

### Temperature Check Optimization

Given that temperature values tend to remain relatively stable over short periods, it is unnecessary to fetch the temperature with every coffee brewing request. Instead, we employ a strategy to update the temperature every two hours, thus minimizing the overhead associated with frequent API calls.

### Implementation of the Timer

The temperature is updated using a timer, set to trigger every two hours, starting immediately upon initialization. Here is how the timer is set up in the code:

```C#
_timer = new Timer(
    callback: UpdateTemperature,
    state: null,
    dueTime: TimeSpan.Zero,
    period: TimeSpan.FromHours(2));
```

This timer ensures that the temperature value is refreshed every two hours, and this updated value is used in all coffee brewing processes until the next update.

### Object-Oriented Design Principle

Adhering to the principle of "open for extension, closed for modification," a new class `CoffeeResponseWithTemperatureGeneratorImpl` has been introduced. This class integrates the previous coffee brewing logic with the new functionality to access the third-party API. what we need to do is just update the `program.cs` file, in this way, we don't need to change any other code to enhance the feature of accessing third-party services.

```C#
builder.Services.AddSingleton<ICoffeeResponseGenerator, CoffeeResponseWithTemptureGeneratorImpl>();
```

### Third-Party API Integration

A dedicated service, `WeatherServiceImpl`, has been created to handle interactions with the third-party API. Currently, it retrieves the temperature for Hamilton, with the location hardcoded into the service. This approach simplifies the current implementation but can be adapted to accept different locations dynamically in the future, enhancing the flexibility of the application.

```C#
public class WeatherServiceImpl : IWeatherService
{
    public int GetCurrentTemperature()
    {
        // Implementation details
    }
}
```

