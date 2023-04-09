using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization;
using Gurrex.Common.Validations;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Web;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Exceptions;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    /// <summary>
    /// Информация о видео и аудио
    /// </summary>
    public class DataInformationsAsync : IDataInformationAsync<YouTubeVideo>, IAssemblyInfo
    {
        /// <summary>
        /// Экземпляр сборки
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public string ResourcesPath { get; set; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public DataInformationsAsync() 
        {
            Assembly = Assembly.GetExecutingAssembly();
            ResourcesPath = $"{Assembly.FullName}.Resources.Services.Async.DataInformationsAsync";
        }

        /// <summary>
        /// Асинхронно получить Enumerable объектов <see cref="YouTubeVideo"/>, полученных по ссылке
        /// </summary>
        /// <param name="url">Сслыка на видео</param>
        /// <returns>Enumerable объектов <see cref="YouTubeVideo"/>, полученных по ссылке</returns>
        private async Task<IEnumerable<YouTubeVideo>> GetEnumerableVideosByUrlAsync(string url)
        {
            YouTube youTube = YouTube.Default;

            IEnumerable<YouTubeVideo> videos = await youTube
                .GetAllVideosAsync(url)
                .ConfigureAwait(false);

            return videos;
        }

        /// <summary>
        /// Асинхронно получить Enumerable доступных битрейтов видео
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

        private IEnumerable<int> GetEnumerableResolutions(IEnumerable<YouTubeVideo> videos) 
        {
            IEnumerable<int> resolutions = videos
                .Where (x => x.Resolution != -1)
                .Select(x => x.Resolution)
                .Distinct()
                .OrderByDescending(x => x);
            return resolutions;
        }

        private IEnumerable<AudioFormat> GetEnumerableAudioFormat(IEnumerable<YouTubeVideo> videos) 
        {
            IEnumerable<AudioFormat> audioFormats = videos
                .Where(x => x.AudioFormat != AudioFormat.Unknown)
                .Select (x => x.AudioFormat)
                .Distinct()
                .OrderByDescending(x => x);
            return audioFormats;
        }

        private IEnumerable<VideoFormat> GetEnumerableVideoFormat(IEnumerable<YouTubeVideo> videos) 
        {
            IEnumerable<VideoFormat> videoFormats = videos
                .Where(x => x.Format != VideoFormat.Unknown)
                .Select(x => x.Format)
                .Distinct()
                .OrderByDescending(x => x);
            return videoFormats;
        }

        private IEnumerable<int> GetEnumerableFps(IEnumerable<YouTubeVideo> videos) 
        {
            IEnumerable<int> enumerableFps = videos
                .Where(x => x.Fps != -1)
                .Select(x => x.Fps)
                .Distinct()
                .OrderByDescending(x => x);
            return enumerableFps;
        }

        private IMainInfo GetMainInfo(YouTubeVideo video) 
        {
            IMainInfo mainInfo = new MainInfo(video.Info.Title, video.Info.Author, video.Info.LengthSeconds);
            return mainInfo;
        }

        private string? GetUrlValueByKey(string url, string key) 
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
                    string localizationString = LocalizationString.GetString(ResourcesPath, Assembly, "ExceptionNoContainsKeyV");
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
    }
}
