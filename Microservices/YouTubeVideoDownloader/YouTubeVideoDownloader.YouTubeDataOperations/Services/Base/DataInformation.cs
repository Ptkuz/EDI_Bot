using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization;
using Gurrex.Common.Validations;
using Gurrex.Helpers;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Exceptions;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Base
{
    /// <summary>
    /// Получение данных о видео
    /// </summary>
    public class DataInformation : IAssemblyInfo
    {

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
        /// Получить видео из перечисления объектов <see cref="YouTubeVideo"/>
        /// </summary>
        /// <param name="videos"></param>
        /// <returns></returns>
        protected YouTubeVideo GetYouTubeVideo(IEnumerable<YouTubeVideo> videos) 
        {
                YouTubeVideo? video = videos.FirstOrDefault();
                video.CheckObjectForNull(nameof(video));
                return video;
        }

        /// <summary>
        /// Получить главную информация о видео
        /// </summary>
        /// <param name="video">Видео <see cref="YouTubeVideo"/></param>
        /// <returns>Экземпляр, реализующий <see cref="IMainInfo"/></returns>
        protected IMainInfo GetMainInfo(YouTubeVideo video)
        {
            IMainInfo mainInfo = new MainInfo(video.Info.Title, video.Info.Author, video.Info.LengthSeconds);
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
                string gf = LocalizationString.GetString(GetResourcesPath(nameof(DataInformation)), StaticHelpers.GetAssembly(), "ExceptionNoContainsKeyV");
                string resufggfltString = LocalizationString.GetResultString(gf, url);

                Uri uri = new Uri(url);
                NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);

                query.CheckObjectForNull(nameof(query));

                if (query.AllKeys.Contains(key))
                    return query[key];
                else
                {
                    string localizationString = LocalizationString.GetString(GetResourcesPath(nameof(DataInformation)), StaticHelpers.GetAssembly(), "ExceptionNoContainsKeyV");
                    string resultString = LocalizationString.GetResultString(localizationString, url);
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

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <returns>Путь до ресурсов</returns>
        public virtual string GetResourcesPath(string type)
        {
            return $"{StaticHelpers.GetAssemblyName().Name}.Resources.Services.Base.DataInformation";
        }

    }
}
