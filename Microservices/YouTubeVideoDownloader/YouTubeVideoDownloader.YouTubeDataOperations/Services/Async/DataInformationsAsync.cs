using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Base;
using Gurrex.Common.Conversion;
using Gurrex.Common.Helpers;
using YouTubeVideoDownloader.YouTubeDataOperations.Helpers;
using System;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;
using YouTubeVideoDownloader.Interfaces.Models.Services;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    /// <summary>
    /// Информация о видео и аудио асинхронно
    /// </summary>
    public class DataInformationsAsync : DataInformation, IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams>
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get => $"{AssemblyName?.Name}.Resources.Services.Async.DataInformationsAsync";
        }

        /// <summary>
        /// Асинхронно получить информациб о видео по ссылке
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async Task<YouTubeVideoInfoResponse> GetYouTubeVideoInfoAsync(string url)
        {
            IEnumerable<YouTubeVideo> videos = await GetEnumerableYouTubeVideo(url);

            YouTubeVideo youTubeVideo = GetYouTubeVideo(videos);
            MainInfo mainInfo = GetMainInfo(youTubeVideo);

            IEnumerable<string> audioBitrates = GetEnumerableAudioBitrates(videos).ConvertToString(" kbps");
            IEnumerable<string> resolutions = GetEnumerableResolutions(videos).ConvertToString("p");
            IEnumerable<string> audioFormats = GetEnumerableAudioFormat(videos).ConvertToString();
            IEnumerable<string> videoFormats = GetEnumerableVideoFormat(videos).ConvertToString();
            IEnumerable<string> fps = GetEnumerableFps(videos).ConvertToString(" FPS");
            byte[] image = await GetVideoImageAsync(url).ConfigureAwait(false);

            YouTubeVideoInfoResponse youTubeVideoInfo = new YouTubeVideoInfoResponse(mainInfo, audioBitrates, resolutions, audioFormats, videoFormats, fps, image);

            return youTubeVideoInfo;
        }

        /// <summary>
        /// Получить объект <see cref="YouTubeVideo"/>
        /// </summary>
        /// <param name="specificVideoInfoRequest">Запрашиваемые свойства видео</param>
        /// <param name="serverSettings">Настройки приложения</param>
        /// <returns>Объект <see cref="YouTubeVideo"/></returns>
        public async Task<InfoStreams> GetSpecisicVideoInfoAsync(SpecificVideoInfoRequest specificVideoInfoRequest, IServerSettings serverSettings) 
        {
            IEnumerable<YouTubeVideo> videos = await GetEnumerableYouTubeVideo(specificVideoInfoRequest.Url);
            InfoStreams infoStreams = GetYouTubeVideo(videos, specificVideoInfoRequest, serverSettings);
            return infoStreams;

        }

        private async Task<IEnumerable<YouTubeVideo>> GetEnumerableYouTubeVideo(string url) 
        {
            YouTube youTube = YouTube.Default;
            IEnumerable<YouTubeVideo> videos = await youTube
                .GetAllVideosAsync(url)
                .ConfigureAwait(false);
            return videos;
        }

        /// <summary>
        /// Асинхронно получить картинку видео по Url
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Поток <see cref="Stream"/> с картинкой</returns>
        private async Task<byte[]> GetVideoImageAsync(string url)
        {
            string? id = GetUrlValueByKey(url, "v");
            id.CheckObjectForNull(nameof(id));

            string resource = ManagerResources.GetString(new Resource (ResourcesPath, "VideoImageUrl", Assembly));
            string resultString = ManagerResources.GetResultString(resource, id, "maxresdefault.jpg");

            Uri uri = new Uri(resultString);

            using (HttpClient httpClient = new HttpClient())
            {
                byte[] image = await httpClient.GetByteArrayAsync(uri);
                return image;
            }
        }
    }
}
