using Gurrex.Common.Helpers;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Mime;
using System.Reflection;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Async;
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

        /// <summary>
        /// Сервис информации о видео
        /// </summary>
        private readonly IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams> _dataInformationsAsync = null!;

        private readonly IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync> _downloadStreamAsync = null!;

        private readonly IConvertationServiceAsync _convertationServiceAsync = null!;

        private readonly ISenderInfoHubAsync<SenderInfoHubAsync> _senderInfoHubAsync = null!;

        private readonly IHubContext<SenderInfoHubAsync> _hubContext;

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
        public override string? TypeName { get; set; } = nameof(YouTubeDownloadController);


        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get =>
                TypeName is not nameof(YouTubeDownloadController) ?
                   base.ResourcesPath :
                   $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Controllers.YouTubeDownloadController";
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Сервис логирования</param>
        /// <param name="dataInformationsAsync">Сервис информации о видео</param>
        public YouTubeDownloadController(
            ILogger<YouTubeDownloadController> logger,
            IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams> dataInformationsAsync,
            IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync> downloadStreamAsync,
            ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync,
            IHubContext<SenderInfoHubAsync> hubContext,
            IConvertationServiceAsync convertationServiceAsync
            )
        {
            _logger = logger;
            _dataInformationsAsync = dataInformationsAsync;
            _downloadStreamAsync = downloadStreamAsync;
            _senderInfoHubAsync = senderInfoHubAsync;
            _hubContext = hubContext;
            _convertationServiceAsync = convertationServiceAsync;
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

        /// <summary>
        /// Скачать видео на основе запроса <see cref="SpecificVideoInfoRequest"/>
        /// </summary>
        /// <param name="specificVideoInfoRequest">Запрос</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("DownloadVideoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task DownloadVideoAsync([FromBody] SpecificVideoInfoRequest specificVideoInfoRequest)
        {
            CancellationTokenSource = new CancellationTokenSource();

            InfoStreams infoStreams = await _dataInformationsAsync.GetSpecisicVideoInfoAsync(specificVideoInfoRequest);
            //bool result = await _downloadStreamAsync.DownloadAsync(infoStreams, _senderInfoHubAsync, _hubContext, CancellationTokenSource.Token);
            IConvertationModel convertationModel =
                new ConvertationModel(@"F:\MyProjects\VideoData\", infoStreams.AudioFileName, infoStreams.VideoFileName, infoStreams.VideoStream.Fps.ToString(), infoStreams.VideoStream.Title, infoStreams.VideoStream.FileExtension);
            await _convertationServiceAsync.MergeAudioVideoData(convertationModel, Assembly.GetName().Name, CancellationTokenSource.Token);


        }
    }
}