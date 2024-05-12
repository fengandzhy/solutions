using Newtonsoft.Json;

namespace WebApplication1.src.Services.Impls
{
    public class WeatherServiceImpl : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "043da4db2934200089bf0b2e2a614bf0";

        public WeatherServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public double GetTempeturate(string city)
        {
            string url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);
            return weatherData.Main.Temp;
        }

        private class WeatherData
        {
            public Main Main { get; set; }
        }

        private class Main
        {
            public double Temp { get; set; }
        }
    }
}
