using Microsoft.AspNetCore.Mvc;

namespace hackathon_2022_ms_hurry_up_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextSummaryController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;

        public TextSummaryController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Summarize")]
        public IEnumerable<string> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
