using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTubeVideoDownloader.Interfaces.Models
{
    /// <summary>
    /// Информация о видео
    /// </summary>
    public interface IYouTubeVideoInfo
    {
        /// <summary>
        /// Главная информация о видео
        /// </summary>
        IMainInfo MainInfo { get; set; }

        /// <summary>
        /// Перечисление доступных аудио битрейтов 
        /// </summary>
        IEnumerable<int> AudioBitrates { get; set; }

        /// <summary>
        /// Перечисление доступных разрешений
        /// </summary>
        IEnumerable<int> Resolutions {  get; set; }

        /// <summary>
        /// Перечисление доступных аудио форматов
        /// </summary>
        IEnumerable<AudioFormat> AudioFormats { get; set; }

        /// <summary>
        /// Перечисление доступных видео форматов
        /// </summary>
        IEnumerable<VideoFormat> VideoFormats { get; set; }

        /// <summary>
        /// Перечисление доступных Fps
        /// </summary>
        IEnumerable<int> Fps { get; set; }

    }
}
