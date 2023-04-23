using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using Gurrex.Helpers;
using System.Net.Http.Headers;
using System.Reflection;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    /// <summary>
    /// Информация о видео и аудио асинхронно
    /// </summary>
    public class DataInformationsAsync : DataInformation, IDataInformationAsync<YouTubeVideoInfoResponse>
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get
            {
                if (TypeName is not nameof(DataInformationsAsync)) 
                {
                    return base.ResourcesPath;
                }

                return $"{AssemblyName}.Resources.Services.Async.DataInformationsAsync";
            }
        }

        /// <summary>
        /// Асинхронно получить информациб о видео по ссылке
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async Task<YouTubeVideoInfoResponse> GetYouTubeVideoInfoAsync(string url)
        {
            YouTube youTube = YouTube.Default;

            IEnumerable<YouTubeVideo> videos = await youTube
                .GetAllVideosAsync(url)
                .ConfigureAwait(false);

            YouTubeVideo youTubeVideo = GetYouTubeVideo(videos);
            MainInfo mainInfo = GetMainInfo(youTubeVideo);

            IEnumerable<int> audioBitrates = GetEnumerableAudioBitrates(videos);
            IEnumerable<int> resolutions = GetEnumerableResolutions(videos);
            IEnumerable<AudioFormat> audioFormats = GetEnumerableAudioFormat(videos);
            IEnumerable<VideoFormat> videoFormats = GetEnumerableVideoFormat(videos);
            IEnumerable<int> fps = GetEnumerableFps(videos);
            Stream stream = await GetVideoImageAsync(url);

            YouTubeVideoInfoResponse youTubeVideoInfo = new YouTubeVideoInfoResponse(mainInfo, audioBitrates, resolutions, audioFormats, videoFormats, fps);

            return youTubeVideoInfo;
        }

        /// <summary>
        /// Асинхронно получить картинку видео по Url
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Поток <see cref="Stream"/> с картинкой</returns>
        private async Task<Stream> GetVideoImageAsync(string url)
        {
            string? id = GetUrlValueByKey(url, "v");
            id.CheckObjectForNull(nameof(id));

            string localizationString = LocalizationString.GetString(new Resource(ResourcesPath, "VideoImageUrl", Assembly));
            string resultString = LocalizationString.GetResultString(localizationString, id, "maxresdefault.jpg");

            Uri uri = new Uri(resultString);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                using (Stream stream = new MemoryStream()) 
                {
                    await response.Content.CopyToAsync(stream);
                    return stream;
                }
            }
        }
    }
}
