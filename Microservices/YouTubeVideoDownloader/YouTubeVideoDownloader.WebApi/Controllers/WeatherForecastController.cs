using Gurrex.Common.Validations;
using Microsoft.AspNetCore.Mvc;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IChannelRerositoryAsync<Channel> _channelRerositoryAsync;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IChannelRerositoryAsync<Channel> channelRerositoryAsync)
        {
            _logger = logger;
            _channelRerositoryAsync = channelRerositoryAsync;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Channel channel = new Channel();
            channel.Id = Guid.NewGuid();
            channel.Name = "Alina Gindertail";

            _channelRerositoryAsync.AddEntityAsync(channel);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}