using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using System.Collections.Specialized;
using System.Web;
using VideoLibrary;
using YouTubeVideoDownloader.YouTubeDataOperations.Exceptions;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Base
{
    /// <summary>
    /// Получение данных о видео
    /// </summary>
    public class DataInformation : IResources
    {

        /// <summary>
        /// Имя вызывающего типа
        /// </summary>
        public string? TypeName { get; set; }


        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath
        {
            get
            {
                return $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Services.Base.DataInformation";
            }
        }


        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public DataInformation()
        {

        }

        /// <summary>
        /// Получить Enumerable доступных битрейтов видео
        /// </summary>
        /// <param name="videos">Enumerable <see cref="YouTubeVideo"/></param>
        /// <returns>Enumerable доступных битрейтов видео</returns>
        protected IEnumerable<int> GetEnumerableAudioBitrates(IEnumerable<YouTubeVideo> videos)
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
        protected IEnumerable<int> GetEnumerableResolutions(IEnumerable<YouTubeVideo> videos)
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
        protected IEnumerable<AudioFormat> GetEnumerableAudioFormat(IEnumerable<YouTubeVideo> videos)
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
        protected IEnumerable<VideoFormat> GetEnumerableVideoFormat(IEnumerable<YouTubeVideo> videos)
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
        protected IEnumerable<int> GetEnumerableFps(IEnumerable<YouTubeVideo> videos)
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
        protected YouTubeVideo GetYouTubeVideo(IEnumerable<YouTubeVideo> videos)
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
        /// <returns>Объект <see cref="YouTubeVideo"/> с информацией о видео</returns>
        protected InfoStreams GetYouTubeVideo(IEnumerable<YouTubeVideo> videos, SpecificVideoInfoRequest specificVideoInfoRequest)
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
                }

                return new InfoStreams(audio, video);
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
        protected MainInfo GetMainInfo(YouTubeVideo video)
        {
            MainInfo mainInfo = new MainInfo(video.Info.Title, video.Info.Author, video.Info.LengthSeconds);
            return mainInfo;
        }

        /// <summary>
        /// Получить значение по ключу в ссылке
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <param name="key">Ключ</param>
        /// <exception cref="NoContainsKeyException">Исключение, если такого ключа в ссылке нет</exception>
        /// <returns>Значение по ключу в ссылке</returns>
        protected string? GetUrlValueByKey(string url, string key)
        {
            try
            {
                Uri uri = new Uri(url);
                NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);

                query.CheckObjectForNull(nameof(query));

                if (query.AllKeys.Contains(key))
                    return query[key];
                else
                {
                    string resource = ManagerResources.GetString(new Resource(ResourcesPath, "ExceptionNoContainsKeyV", StaticHelpers.GetAssemblyInfo().Assembly));
                    string resultString = ManagerResources.GetResultString(resource, url);
                    throw new NoContainsKeyException(resultString, key);
                }
            }
            catch (NoContainsKeyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
