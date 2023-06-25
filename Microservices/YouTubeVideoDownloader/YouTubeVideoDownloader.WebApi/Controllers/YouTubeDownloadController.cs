using Gurrex.Common.Helpers;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services;
using YouTubeVideoDownloader.WebApi.ConfigurationSettings;
using YouTubeVideoDownloader.YouTubeDataOperations.Helpers;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;

namespace YouTubeVideoDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeDownloadController : ControllerBase
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
        private readonly IDataInformationService<GetVideoInfoResponse, DownloadVideoRequest, InfoStreams> _dataInformationsAsync = null!;

        private readonly IDownloadStreamService<InfoStreams> _downloadStreamAsync = null!;

        private readonly IConvertationService<SenderInfoHub, ProcessEventArgs> _convertationServiceAsync = null!;

        private readonly IDataBaseService<InfoStreams, GetVideoInfoRequest, GetVideoInfoResponse, MainInfo, DownloadVideoRequest> _dataBaseServiceAsync = null!;


        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Сервис логирования</param>
        /// <param name="dataInformationsAsync">Сервис информации о видео</param>
        public YouTubeDownloadController(
            ILogger<YouTubeDownloadController> logger,
            IDataInformationService<GetVideoInfoResponse, DownloadVideoRequest, InfoStreams> dataInformationsAsync,
            IDownloadStreamService<InfoStreams> downloadStreamAsync,
            IConvertationService<SenderInfoHub, ProcessEventArgs> convertationServiceAsync,
            IDataBaseService<InfoStreams, GetVideoInfoRequest, GetVideoInfoResponse, MainInfo, DownloadVideoRequest> dataBaseServiceAsync,
            IOptions<ServerSettings> serverSettings
            )
        {
            _logger = logger;
            _dataInformationsAsync = dataInformationsAsync;
            _downloadStreamAsync = downloadStreamAsync;
            _convertationServiceAsync = convertationServiceAsync;
            _dataBaseServiceAsync = dataBaseServiceAsync;

            _serverSettings = serverSettings.Value;

        }

        /// <summary>
        /// Получить информацию о видео из запроса
        /// </summary>
        /// <param name="videoInfoRequest">Запрос</param>
        /// <returns>Информация о видео, полученная из запроса</returns>
        [HttpGet("GetVideoInfo")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetVideoInfoResponse>> GetVideoInfo([FromQuery] GetVideoInfoRequest videoInfoRequest)
        {
            try
            {
                CancellationTokenSource = new CancellationTokenSource();
                GetVideoInfoResponse youtubeVideoInfo = await _dataInformationsAsync.GetYouTubeVideoInfoAsync(videoInfoRequest.Url);

                if (!await _dataBaseServiceAsync.CheckYouTubeInfoAsync(videoInfoRequest))
                {
                    await _dataBaseServiceAsync.AfterGetYouTubeInfoAsync(youtubeVideoInfo, videoInfoRequest, CancellationTokenSource.Token);
                }

                string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.GetVideoInfoAsyncSuccess", StaticHelpers.GetAssemblyInfo().Assembly));
                string resultString = ManagerResources.GetResultString(resource, videoInfoRequest.Id, videoInfoRequest.Url);
                _logger.LogInformation(resultString);
                return Ok(youtubeVideoInfo);
            }
            catch (Exception ex)
            {
                string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.GetVideoInfoAsyncException", StaticHelpers.GetAssemblyInfo().Assembly));
                string resultStringLog = ManagerResources.GetResultString(resource, ex);
                string resultString = ManagerResources.GetResultString(resource, ex.Message);
                _logger.LogError(resultStringLog);
                GetVideoInfoResponse youTubeVideoInfoResponse = new GetVideoInfoResponse(ex, resultStringLog);
                return BadRequest(youTubeVideoInfoResponse);
            }
        }

        /// <summary>
        /// Скачать видео на основе запроса <see cref="DownloadVideoRequest"/>
        /// </summary>
        /// <param name="specificVideoInfoRequest">Запрос</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("DownloadVideoAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<DownloadVideoResponse>> DownloadVideoAsync([FromBody] DownloadVideoRequest specificVideoInfoRequest)
        {
            try
            {
                DownloadVideoResponse downloadVideoResponse;
                if (await _dataBaseServiceAsync.CheckVideoAsync(specificVideoInfoRequest))
                {
                    string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.VideoExist", StaticHelpers.GetAssemblyInfo().Assembly));
                    string resultString = ManagerResources.GetResultString(resource, DataInformationHelpers.GetSimpleYouTubeUrl(specificVideoInfoRequest.Url));
                    downloadVideoResponse = new DownloadVideoResponse(resultString);
                    return Ok(downloadVideoResponse);
                }

                CancellationTokenSource = new CancellationTokenSource();
                InfoStreams infoStreams = await _dataInformationsAsync.GetSpecisicVideoInfoAsync(specificVideoInfoRequest, _serverSettings);
                bool result = await _downloadStreamAsync.DownloadAsync(infoStreams, infoStreams => !String.IsNullOrWhiteSpace(infoStreams.VideoFileName), CancellationTokenSource.Token);

                if (true && !String.IsNullOrWhiteSpace(specificVideoInfoRequest.Resolution) && infoStreams.VideoStream is not null)
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

                    await _convertationServiceAsync.MergeAudioVideoDataAsync(convertationModel, StaticHelpers.GetAssemblyInfo().AssemblyName.Name, CancellationTokenSource.Token);

                }

                if (result)
                {
                    _dataBaseServiceAsync.InfoStream = infoStreams;
                    if (infoStreams.VideoStream is not null)
                    {
                        await _dataBaseServiceAsync.AfterDownloadVideoAsync(CancellationTokenSource.Token);
                        string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.VideoDownload", StaticHelpers.GetAssemblyInfo().Assembly));
                        string resultString = ManagerResources.GetResultString(resource, DataInformationHelpers.GetSimpleYouTubeUrl(specificVideoInfoRequest.Url));
                        return Ok(new DownloadVideoResponse(resultString));
                    }
                    else
                    {
                        await _dataBaseServiceAsync.AfterDownloadAudioAsync(CancellationTokenSource.Token);
                        string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.AudioDownload", StaticHelpers.GetAssemblyInfo().Assembly));
                        string resultString = ManagerResources.GetResultString(resource, DataInformationHelpers.GetSimpleYouTubeUrl(specificVideoInfoRequest.Url));
                        return Ok(new DownloadVideoResponse(resultString));
                    }
                }
                else
                {
                    string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.DownloadFailed", StaticHelpers.GetAssemblyInfo().Assembly));
                    string resultString = ManagerResources.GetResultString(resource);
                    return StatusCode(500, new DownloadVideoResponse(resultString));
                }
            }
            catch (Exception ex)
            {
                string resource = ManagerResources.GetString(new Resource("YouTubeDownloadController.DownloadVideoInfoAsyncException", StaticHelpers.GetAssemblyInfo().Assembly));
                string resultString = ManagerResources.GetResultString(resource, specificVideoInfoRequest.Url, ex.Message);
                return StatusCode(500, new DownloadVideoResponse(ex, resultString));
            }
        }
    }
}