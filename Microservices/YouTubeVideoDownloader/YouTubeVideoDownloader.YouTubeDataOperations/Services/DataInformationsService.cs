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

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    /// <summary>
    /// Информация о видео и аудио асинхронно
    /// </summary>
    public class DataInformationsService : DataInformation, IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams>
    {

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
            string? id = DataInformationHelpers.GetUrlValueByKey(url, "v");
            id.CheckObjectForNull(nameof(id));

            string resource = ManagerResources.GetString(new Resource("DataInformationService.VideoImageUrl", StaticHelpers.GetAssemblyInfo().Assembly));
            string resultString = ManagerResources.GetResultString(resource, id, "maxresdefault.jpg");

            Uri uri = new Uri(resultString);

            using (HttpClient httpClient = new HttpClient())
            {
                byte[] image;
                try
                {
                    image = await httpClient.GetByteArrayAsync(uri);
                    return image;
                }
                catch (HttpRequestException)
                {
                    resultString = ManagerResources.GetResultString(resource, id, "default.jpg");
                    uri = new Uri(resultString);
                    image = await httpClient.GetByteArrayAsync(uri);
                    return image;
                }
            }
        }

        /// <summary>
        /// Получить Enumerable доступных битрейтов видео
        /// </summary>
        /// <param name="videos">Enumerable <see cref="YouTubeVideo"/></param>
        /// <returns>Enumerable доступных битрейтов видео</returns>
        private IEnumerable<int> GetEnumerableAudioBitrates(IEnumerable<YouTubeVideo> videos)
        {
            IEnumerable<int> bitrates = videos
                .Where(x => x.AudioBitrate != -1)
                .Select(x => x.AudioBitrate)
                .Distinct()
                .OrderByDescending(x => x);
            return bitrates;
        }

        /// <summary>
        /// Получить Enumerable разрешений видео
        /// </summary>
        /// <param name="videos">Enumerable видео, полученных по ссылке</param>
        /// <returns>Enumerable разрешений видео</returns>
        private IEnumerable<int> GetEnumerableResolutions(IEnumerable<YouTubeVideo> videos)
        {
            IEnumerable<int> resolutions = videos
                .Where(x => x.Resolution != -1)
                .Select(x => x.Resolution)
                .Distinct()
                .OrderByDescending(x => x);
            return resolutions;
        }

        /// <summary>
        /// Получить Enumerable аудио форматов <see cref="AudioFormat"/> видео
        /// </summary>
        /// <param name="videos">Enumerable видео, полученных по ссылке</param>
        /// <returns>Enumerable аудио форматов <see cref="AudioFormat"/> видео</returns>
        private IEnumerable<AudioFormat> GetEnumerableAudioFormat(IEnumerable<YouTubeVideo> videos)
        {
            IEnumerable<AudioFormat> audioFormats = videos
                .Where(x => x.AudioFormat != AudioFormat.Unknown)
                .Select(x => x.AudioFormat)
                .Distinct()
                .OrderByDescending(x => x);
            return audioFormats;
        }

        /// <summary>
        /// Получить Enumerable видео форматов <see cref="VideoFormat"/> видео
        /// </summary>
        /// <param name="videos">Enumerable видео, полученных по ссылке</param>
        /// <returns>Enumerable видео форматов <see cref="VideoFormat"/> видео</returns>
        private IEnumerable<VideoFormat> GetEnumerableVideoFormat(IEnumerable<YouTubeVideo> videos)
        {
            IEnumerable<VideoFormat> videoFormats = videos
                .Where(x => x.Format != VideoFormat.Unknown)
                .Select(x => x.Format)
                .Distinct()
                .OrderByDescending(x => x);
            return videoFormats;
        }

        /// <summary>
        /// Получить Enumerable FPS видео
        /// </summary>
        /// <param name="videos">Enumerable видео, полученных по ссылке</param>
        /// <returns></returns>
        private IEnumerable<int> GetEnumerableFps(IEnumerable<YouTubeVideo> videos)
        {
            IEnumerable<int> enumerableFps = videos
                .Where(x => x.Fps != -1)
                .Select(x => x.Fps)
                .Distinct()
                .OrderByDescending(x => x);
            return enumerableFps;
        }

        /// <summary>
        /// Получить первое видео из перечисления объектов <see cref="YouTubeVideo"/>
        /// </summary>
        /// <param name="videos">Перечисление объектов <see cref="YouTubeVideo"/></param>
        /// <returns>Объект <see cref="YouTubeVideo"/> с информацией о видео</returns>
        private YouTubeVideo GetYouTubeVideo(IEnumerable<YouTubeVideo> videos)
        {
            YouTubeVideo? video = videos.FirstOrDefault();
            video.CheckObjectForNull(nameof(video));
            return video;
        }

        /// <summary>
        /// Получить видео на основе свойств объекта <see cref="SpecificVideoInfoRequest"/>
        /// </summary>
        /// <param name="videos">Перечисление объектов <see cref="YouTubeVideo"/></param>
        /// <param name="specificVideoInfoRequest">Объект <see cref="SpecificVideoInfoRequest"/> со свойствами запрашиваемого видео</param>
        /// <param name="serverSettings">Настройки приложения</param>
        /// <returns>Объект <see cref="YouTubeVideo"/> с информацией о видео</returns>
        private InfoStreams GetYouTubeVideo(IEnumerable<YouTubeVideo> videos, SpecificVideoInfoRequest specificVideoInfoRequest, IServerSettings serverSettings)
        {
            try
            {
                YouTubeVideo? video = default;
                YouTubeVideo? audio = default;

                int resolution = default;
                VideoFormat videoFormat = default;
                int fps = default;
                AudioFormat audioFormat = specificVideoInfoRequest.ConvertToAudioFormat(specificVideoInfoRequest.AudioFormat);
                int audioBitrate = specificVideoInfoRequest.ConvertToInt(specificVideoInfoRequest.AudioBitrate, " kbps");

                audio = videos
                    .FirstOrDefault(x =>
                    x.AudioBitrate == audioBitrate && x.AudioFormat == audioFormat);

                audio.CheckObjectForNull(nameof(audio));

                if (!String.IsNullOrWhiteSpace(specificVideoInfoRequest.Resolution) &&
                    !String.IsNullOrWhiteSpace(specificVideoInfoRequest.VideoFormat) &&
                    !String.IsNullOrWhiteSpace(specificVideoInfoRequest.Fps))
                {
                    resolution = specificVideoInfoRequest.ConvertToInt(specificVideoInfoRequest.Resolution, "p");
                    videoFormat = specificVideoInfoRequest.ConvertToVideoFormat(specificVideoInfoRequest.VideoFormat);
                    fps = specificVideoInfoRequest.ConvertToInt(specificVideoInfoRequest.Fps, " FPS");

                    video = videos
                        .FirstOrDefault(x =>
                        x.Format == videoFormat && x.Fps == fps &&
                        x.Resolution == resolution);

                    video.CheckObjectForNull(nameof(video));
                    return new InfoStreams(specificVideoInfoRequest.Url, video, audio, serverSettings);
                }

                return new InfoStreams(specificVideoInfoRequest.Url, audio, serverSettings);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получить главную информация о видео
        /// </summary>
        /// <param name="video">Видео <see cref="YouTubeVideo"/></param>
        /// <returns>Объект <see cref="MainInfo"/></returns>
        private MainInfo GetMainInfo(YouTubeVideo video)
        {
            MainInfo mainInfo = new MainInfo(video.Info.Title, video.Info.Author, video.Info.LengthSeconds);
            return mainInfo;
        }
    }
}
