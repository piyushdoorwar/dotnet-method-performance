using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeasuringMethodPerformance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet("simple")]
        public IEnumerable<WeatherForecast> GetSimple()
        {
            Stopwatch sw = new();
            sw.Start();
            LongRunningOperation();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            sw.Stop();
            Console.WriteLine($"Elapsed time {sw.ElapsedMilliseconds}ms. ");
            return data.ToArray();
            
        }

        [HttpGet("fody"), Time]
        public IEnumerable<WeatherForecast> GetWithFody()
        {
            LongRunningOperation();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            return data.ToArray();
        }

        private static void LongRunningOperation()
        {
            // Simulate a random delay between 1-3 seconds
            Random random = new();
            int delay = random.Next(1000, 3001);
            Thread.Sleep(delay);
        }
    }
}
