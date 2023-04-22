using Gurrex.Helpers;
using System.Diagnostics;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models.Response;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    /// <summary>
    /// Информация о видео и аудио асинхронно
    /// </summary>
    public class DataInformationsAsync : DataInformation, IDataInformationAsync<YouTubeVideo>
    {

        /// <summary>
        /// Асинхронно получить информациб о видео по ссылке
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async Task<IYouTubeVideoInfoResponse> GetYouTubeVideoInfoAsync(string url)
        {
            YouTube youTube = YouTube.Default;

            IEnumerable<YouTubeVideo> videos = await youTube
                .GetAllVideosAsync(url)
                .ConfigureAwait(false);

            YouTubeVideo youTubeVideo = GetYouTubeVideo(videos);
            IMainInfoResponse mainInfo = GetMainInfo(youTubeVideo);

            IEnumerable<int> audioBitrates = GetEnumerableAudioBitrates(videos);
            IEnumerable<int> resolutions = GetEnumerableResolutions(videos);
            IEnumerable<AudioFormat> audioFormats = GetEnumerableAudioFormat(videos);
            IEnumerable<VideoFormat> videoFormats = GetEnumerableVideoFormat(videos);
            IEnumerable<int> fps = GetEnumerableFps(videos);

            IYouTubeVideoInfoResponse youTubeVideoInfo = new YouTubeVideoInfoResponse(mainInfo, audioBitrates, resolutions, audioFormats, videoFormats, fps);

            return youTubeVideoInfo;
        }

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <returns>Путь до ресурсов</returns>
        public override string GetResourcesPath(string type)
        {
            if (type is not nameof(type)) 
            {
                return base.GetResourcesPath(type);
            }

            return $"{StaticHelpers.GetAssemblyName()}.Services.Async.DataInformationsAsync";
        }


    }
}
