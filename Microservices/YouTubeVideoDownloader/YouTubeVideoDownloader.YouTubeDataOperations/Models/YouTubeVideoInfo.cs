using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models
{
    /// <summary>
    /// Информация о YouTube ролике, полученном по ссылке
    /// </summary>
    public class YouTubeVideoInfo : IYouTubeVideoInfo
    {
        /// <summary>
        /// Главная информация о видео
        /// </summary>
        public IMainInfo MainInfo { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио битрейтов
        /// </summary>
        public IEnumerable<int> AudioBitrates { get; set; } = null!;

        /// <summary>
        /// Пееречисление доступных
        /// </summary>
        public IEnumerable<int> Resolutions { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио форматов
        /// </summary>
        public IEnumerable<AudioFormat> AudioFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление видео форматов
        /// </summary>
        public IEnumerable<VideoFormat> VideoFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных Fps
        /// </summary>
        public IEnumerable<int> Fps { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="mainInfo">Главная информация о видео</param>
        /// <param name="audioBitrates">Перечисление аудио битрейтов</param>
        /// <param name="resolutions">Перечисление разрешений</param>
        /// <param name="audioFormats">Перечисление аудио форматов</param>
        /// <param name="videoFormats">Перечислене видео форматов</param>
        public YouTubeVideoInfo(IMainInfo mainInfo, IEnumerable<int> audioBitrates, IEnumerable<int> resolutions, IEnumerable<AudioFormat> audioFormats, IEnumerable<VideoFormat> videoFormats) 
        {
            MainInfo = mainInfo;
            AudioBitrates = audioBitrates;
            Resolutions = resolutions;
            AudioFormats = audioFormats;
            VideoFormats = videoFormats;
        }
    }
}
