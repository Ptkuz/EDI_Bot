using Gurrex.Common.Localization;
using Gurrex.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using VideoLibrary;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;

namespace YouTubeVideoDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeDownloadController : ControllerBase
    {

        private readonly ILogger<YouTubeDownloadController> _logger;
        private readonly IChannelRerositoryAsync<Channel> _channelRerositoryAsync;
        private readonly IDataInformationAsync<YouTubeVideoInfoResponse> _dataInformationsAsync;

        public YouTubeDownloadController(ILogger<YouTubeDownloadController> logger, IChannelRerositoryAsync<Channel> channelRerositoryAsync, IDataInformationAsync<YouTubeVideoInfoResponse> dataInformationsAsync)
        {
            _logger = logger;
            _channelRerositoryAsync = channelRerositoryAsync;
            _dataInformationsAsync = dataInformationsAsync;

        }

        private string GetResourcesPath(string type)
        {
            return $"{StaticHelpers.GetAssemblyName().Name}.Resources.Controllers.YouTubeDownloadController";
        }

        [HttpGet("GetVideoInfoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<YouTubeVideoInfoResponse>> GetVideoInfoAsync([FromQuery] VideoInfoRequest videoInfoRequest)
        {
            try
            {
                YouTubeVideoInfoResponse youtubeVideoInfo = await _dataInformationsAsync.GetYouTubeVideoInfoAsync(videoInfoRequest.Url);
                string localizationString = LocalizationString.GetString(GetResourcesPath(nameof(YouTubeDownloadController)), StaticHelpers.GetAssembly(), "GetVideoInfoAsyncSuccess");
                string resultString = LocalizationString.GetResultString(localizationString, videoInfoRequest.Id, videoInfoRequest.Url);
                _logger.LogInformation(resultString);
                return Ok(youtubeVideoInfo);
            }
            catch (Exception ex)
            {
                string localizationString = LocalizationString.GetString(GetResourcesPath(nameof(YouTubeDownloadController)), StaticHelpers.GetAssembly(), "GetVideoInfoAsyncException");
                string resultStringLog = LocalizationString.GetResultString(localizationString, ex);
                string resultString = LocalizationString.GetResultString(localizationString, ex.Message);
                _logger.LogError(resultStringLog);
                return BadRequest(resultString);
            }
        }

        [HttpPost("DownloadVideoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task DownloadVideoAsync([FromBody] SpecificVideoInfoRequest specificVideoInfoRequest)
        {
            throw new Exception();
        }

        //private void Method()
        //{
        //    //Channel channel = new Channel();
        //    //channel.Id = Guid.NewGuid();
        //    //channel.Name = "Alina Gindertail";

        //    //_logger.LogInformation("Работает!!!");

        //    //await _channelRerositoryAsync.AddEntityAsync(channel);



        //    //var youTube = YouTube.Default;
        //    //var video = await youTube.GetVideoAsync("https://www.youtube.com/watch?v=X7RDKkTGDUw&ab_channel=AlinaGingertail");
        //    //Console.WriteLine($"Info - {video.Info} \n " +
        //    //    $"AudioFormat - {video.AudioFormat} \n " +
        //    //    $"Format - {video.Format} \n " +
        //    //    $"FPS - {video.Fps} \n " +
        //    //    $"Extention - {video.FileExtension} \n " +
        //    //    $"Length - {video.ContentLength} \n" +
        //    //    $"AdaptiveKind - {video.AdaptiveKind} \n" +
        //    //    $"AudioBitrate - {video.AudioBitrate} \n" +
        //    //    $"FullName - {video.FullName} \n" +
        //    //    $"FotmatCode - {video.FormatCode} \n" +
        //    //    $"IsAdaptive - {video.IsAdaptive} \n" +
        //    //    $"IsEncrypted - {video.IsEncrypted} \n" +
        //    //    $"Resolution - {video.Resolution} \n" +
        //    //    $"Title - {video.Title} \n" +
        //    //    $"uri - {video.Uri} \n" +
        //    //    $"WebSite - {video.WebSite}");

        //    //var stream = await video.StreamAsync();

        //    //using (stream)
        //    //{
        //    //    using (Stream file = System.IO.File.Create("alina.mp4"))
        //    //    {
        //    //        byte[] buffer = new byte[8 * 1024];
        //    //        int len;
        //    //        while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
        //    //        {
        //    //            file.Write(buffer, 0, len);
        //    //        }
        //    //    }
        //    //}
        //}
    }
}