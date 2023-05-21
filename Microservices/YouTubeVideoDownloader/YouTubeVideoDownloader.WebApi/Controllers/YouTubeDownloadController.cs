using Gurrex.Common.Helpers;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.WebApi.ConfigurationSettings;
using YouTubeVideoDownloader.WebApi.Controllers.Base;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;

namespace YouTubeVideoDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeDownloadController : MainController
    {
        private CancellationTokenSource CancellationTokenSource;

        /// <summary>
        /// Сврвис логирования
        /// </summary>
        private readonly ILogger<YouTubeDownloadController> _logger = null!;

        private readonly IServerSettings _serverSettings;

        /// <summary>
        /// Сервис информации о видео
        /// </summary>
        private readonly IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams> _dataInformationsAsync = null!;

        private readonly IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync, ProcessEventArgs> _downloadStreamAsync = null!;

        private readonly IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs> _convertationServiceAsync = null!;

        private readonly IAudioRepositoryAsync<Audio> _audioRepositoryAsync = null!;
        private readonly IChannelRerositoryAsync<Channel> _channelRerositoryAsync = null!;
        private readonly IImageRepositoryAsync<Image> _imageRepositoryAsync = null!;
        private readonly IServerInfoRepositoryAsync<ServerInfo> _serverInfoRepositoryAsync = null!;
        private readonly IVideoRepositoryAsync<Video> _videoRepositoryAsync = null!;
        private readonly IYouTubeInfoRepositoryAsync<YouTubeInfo> _youTubeInfoRepositoryAsync = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Controllers.YouTubeDownloadController";
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Сервис логирования</param>
        /// <param name="dataInformationsAsync">Сервис информации о видео</param>
        public YouTubeDownloadController(
            ILogger<YouTubeDownloadController> logger,
            IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams> dataInformationsAsync,
            IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync, ProcessEventArgs> downloadStreamAsync,
            ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync,
            IHubContext<SenderInfoHubAsync> hubContext,
            IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs> convertationServiceAsync,
            IOptions<ServerSettings> serverSettings,
            IAudioRepositoryAsync<Audio> audioRepositoryAsync,
            IChannelRerositoryAsync<Channel> channelRerositoryAsync,
            IImageRepositoryAsync<Image> imageRepositoryAsync,
            IServerInfoRepositoryAsync<ServerInfo> serverInfoRepositoryAsync,
            IVideoRepositoryAsync<Video> videoRepositoryAsync,
            IYouTubeInfoRepositoryAsync<YouTubeInfo> youTubeInfoRepositoryAsync
            )
        {
            _logger = logger;
            _dataInformationsAsync = dataInformationsAsync;
            _downloadStreamAsync = downloadStreamAsync;
            _convertationServiceAsync = convertationServiceAsync;
            _serverSettings = serverSettings.Value;

            _downloadStreamAsync.HubContext = hubContext;
            _downloadStreamAsync.SenderInfoHubAsync = senderInfoHubAsync;

            _convertationServiceAsync.HubContext = hubContext;
            _convertationServiceAsync.SenderInfoHubAsync = senderInfoHubAsync;

            _audioRepositoryAsync = audioRepositoryAsync;
            _channelRerositoryAsync = channelRerositoryAsync;
            _imageRepositoryAsync = imageRepositoryAsync;
            _serverInfoRepositoryAsync = serverInfoRepositoryAsync;
            _videoRepositoryAsync = videoRepositoryAsync;
            _youTubeInfoRepositoryAsync = youTubeInfoRepositoryAsync;
        }

        /// <summary>
        /// Получить информацию о видео из запроса
        /// </summary>
        /// <param name="videoInfoRequest">Запрос</param>
        /// <returns>Информация о видео, полученная из запроса</returns>
        [HttpGet("GetVideoInfoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<YouTubeVideoInfoResponse>> GetVideoInfoAsync([FromQuery] VideoInfoRequest videoInfoRequest)
        {
            try
            {
                YouTubeVideoInfoResponse youtubeVideoInfo = await _dataInformationsAsync.GetYouTubeVideoInfoAsync(videoInfoRequest.Url);
                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "GetVideoInfoAsyncSuccess", AssemblyInfo.Assembly));
                string resultString = ManagerResources.GetResultString(resource, videoInfoRequest.Id, videoInfoRequest.Url);
                _logger.LogInformation(resultString);
                return Ok(youtubeVideoInfo);
            }
            catch (Exception ex)
            {
                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "GetVideoInfoAsyncException", AssemblyInfo.Assembly));
                string resultStringLog = ManagerResources.GetResultString(resource, ex);
                string resultString = ManagerResources.GetResultString(resource, ex.Message);
                _logger.LogError(resultStringLog);
                return BadRequest(resultString);
            }
        }

        /// <summary>
        /// Скачать видео на основе запроса <see cref="SpecificVideoInfoRequest"/>
        /// </summary>
        /// <param name="specificVideoInfoRequest">Запрос</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("DownloadVideoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<InfoStreams>> DownloadVideoAsync([FromBody] SpecificVideoInfoRequest specificVideoInfoRequest)
        {
            try
            {
                CancellationTokenSource = new CancellationTokenSource();
                InfoStreams infoStreams = await _dataInformationsAsync.GetSpecisicVideoInfoAsync(specificVideoInfoRequest, _serverSettings);
                bool result = await _downloadStreamAsync.DownloadAsync(infoStreams, infoStreams => !String.IsNullOrWhiteSpace(infoStreams.VideoFileName), CancellationTokenSource.Token);

                if (result && !String.IsNullOrWhiteSpace(specificVideoInfoRequest.Resolution) && infoStreams.VideoStream is not null)
                {
                    IConvertationModel convertationModel =
                        new ConvertationModel(
                            _serverSettings.PathToVideoStorage, 
                            infoStreams.AudioFileName, 
                            infoStreams.AudioFileExtention, 
                            infoStreams.VideoFileName, 
                            infoStreams.VideoFileExtention, 
                            infoStreams.VideoStream.Fps, 
                            infoStreams.FinalFileFullName);

                    await _convertationServiceAsync.MergeAudioVideoDataAsync(convertationModel, AssemblyInfo.AssemblyName.Name, CancellationTokenSource.Token);
                }
                else if (result)
                {
                    IOHelpers.ReplaceFile(infoStreams.AudioFileFullName, infoStreams.FinalFileFullName);
                }

                return Ok(infoStreams);
            }
            catch (Exception ex)
            {
                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "DownloadVideoInfoAsyncException", AssemblyInfo.Assembly));
                string resultStringLog = ManagerResources.GetResultString(resource, specificVideoInfoRequest.Url, ex);
                return StatusCode(500, resultStringLog);
            }
        }
    }
}