using System;
using System.Threading.Tasks;
using WeatherConsole;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Run().Wait();
        }

        private static async Task Run()
        {
            var city = "New York, NY";
            var client = new OpenWeatherMapClient();
            Console.WriteLine($"Fetching weather for {city}");
            var weather = await client.GetCurrentWeatherByCity(city);
            if (weather == null)
            {
                Console.WriteLine("Failed to fetch weather information.");
                return;
            }
            Console.WriteLine($"\nTemp: {weather.Main?.Temperature}");
            Console.WriteLine($"Low: {weather.Main?.MinTemperature}");
            Console.WriteLine($"High: {weather.Main?.MaxTemperature}");
            Console.WriteLine($"Humidity: {weather.Main?.Humidity}%");
            Console.WriteLine($"Condition: {weather.FirstCondition?.Description}");
        }
    }
}
