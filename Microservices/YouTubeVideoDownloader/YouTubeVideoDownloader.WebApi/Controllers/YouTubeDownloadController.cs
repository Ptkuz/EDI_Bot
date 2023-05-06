using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using Gurrex.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Reflection;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Base;
using VideoLibrary;

namespace YouTubeVideoDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeDownloadController : ControllerBase
    {

        private readonly ILogger<YouTubeDownloadController> _logger;
        private readonly IChannelRerositoryAsync<Channel> _channelRerositoryAsync;
        private readonly IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest> _dataInformationsAsync;

        /// <summary>
        /// Сборка
        /// </summary>
        public virtual Assembly Assembly
        {
            get
            {
                Assembly? assembly = Assembly.GetAssembly(typeof(YouTubeDownloadController));
                assembly.CheckObjectForNull(nameof(assembly));
                return assembly;
            }
        }

        /// <summary>
        /// Имя сборки
        /// </summary>
        public virtual string AssemblyName
        {
            get
            {
                AssemblyName assemblyName = Assembly.GetName();
                string? name = assemblyName.Name;
                name.CheckObjectForNull(nameof(name));
                return name;
            }
        }

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath
        {
            get
            {
                return $"{AssemblyName}.Resources.Controllers.YouTubeDownloadController";
            }
        }

        public YouTubeDownloadController(ILogger<YouTubeDownloadController> logger, IChannelRerositoryAsync<Channel> channelRerositoryAsync, IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest> dataInformationsAsync)
        {
            _logger = logger;
            _channelRerositoryAsync = channelRerositoryAsync;
            _dataInformationsAsync = dataInformationsAsync;

        }

        [HttpGet("GetVideoInfoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<YouTubeVideoInfoResponse>> GetVideoInfoAsync([FromQuery] VideoInfoRequest videoInfoRequest)
        {
            try
            {
                YouTubeVideoInfoResponse youtubeVideoInfo = await _dataInformationsAsync.GetYouTubeVideoInfoAsync(videoInfoRequest.Url);
                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "GetVideoInfoAsyncSuccess", Assembly));
                string resultString = ManagerResources.GetResultString(resource, videoInfoRequest.Id, videoInfoRequest.Url);
                _logger.LogInformation(resultString);
                return Ok(youtubeVideoInfo);
            }
            catch (Exception ex)
            {
                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "GetVideoInfoAsyncException", Assembly));
                string resultStringLog = ManagerResources.GetResultString(resource, ex);
                string resultString = ManagerResources.GetResultString(resource, ex.Message);
                _logger.LogError(resultStringLog);
                return BadRequest(resultString);
            }
        }

        [HttpPost("DownloadVideoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task DownloadVideoAsync([FromBody] SpecificVideoInfoRequest specificVideoInfoRequest)
        {
            YouTubeVideo youTubeVideo = await _dataInformationsAsync.GetSpecisicVideoInfoAsync(specificVideoInfoRequest);
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