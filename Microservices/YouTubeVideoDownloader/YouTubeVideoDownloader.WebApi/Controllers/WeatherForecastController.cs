using Gurrex.Common.Validations;
using Microsoft.AspNetCore.Mvc;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using VideoLibrary;
using System.IO;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Interfaces;
using YouTubeVideoDownloader.YouTubeDataOperations.Services;

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
        private readonly IDataInformations _dataInformations;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IChannelRerositoryAsync<Channel> channelRerositoryAsync, IDataInformations dataInformations)
        {
            _logger = logger;
            _channelRerositoryAsync = channelRerositoryAsync;
            _dataInformations = dataInformations;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            _dataInformations.GetInformationByUrl("https://www.youtube.com/watch?v=X7RDKkTGDUw&ab_channel=AlinaGingertail");

            Channel channel = new Channel();
            channel.Id = Guid.NewGuid();
            channel.Name = "Alina Gindertail";

            _logger.LogInformation("Работает!!!");

            await _channelRerositoryAsync.AddEntityAsync(channel);



            var youTube = YouTube.Default;
            var video = await youTube.GetVideoAsync("https://www.youtube.com/watch?v=X7RDKkTGDUw&ab_channel=AlinaGingertail");
            Console.WriteLine($"Info - {video.Info} \n " +
                $"AudioFormat - {video.AudioFormat} \n " +
                $"Format - {video.Format} \n " +
                $"FPS - {video.Fps} \n " +
                $"Extention - {video.FileExtension} \n " +
                $"Length - {video.ContentLength} \n" +
                $"AdaptiveKind - {video.AdaptiveKind} \n" +
                $"AudioBitrate - {video.AudioBitrate} \n" +
                $"FullName - {video.FullName} \n" +
                $"FotmatCode - {video.FormatCode} \n" +
                $"IsAdaptive - {video.IsAdaptive} \n" +
                $"IsEncrypted - {video.IsEncrypted} \n" +
                $"Resolution - {video.Resolution} \n" +
                $"Title - {video.Title} \n" +
                $"uri - {video.Uri} \n" +
                $"WebSite - {video.WebSite}");

            var stream = await video.StreamAsync();

            using (stream) 
            {
                using (Stream file = System.IO.File.Create("alina.mp4")) 
                {
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                    }
                }
            }

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