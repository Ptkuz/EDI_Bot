using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Response
{
    public interface IYouTubeVideoInfoResponse<T> where T : class
    {
        /// <summary>
        /// Главная информация о видео
        /// </summary>
        public T MainInfo { get; set; }

        /// <summary>
        /// Перечисление доступных аудио битрейтов
        /// </summary>
        public IEnumerable<string> AudioBitrates { get; set; }

        /// <summary>
        /// Пееречисление доступных
        /// </summary>
        public IEnumerable<string> Resolutions { get; set; }

        /// <summary>
        /// Перечисление доступных аудио форматов
        /// </summary>
        public IEnumerable<string> AudioFormats { get; set; }

        /// <summary>
        /// Перечисление видео форматов
        /// </summary>
        public IEnumerable<string> VideoFormats { get; set; }

        /// <summary>
        /// Перечисление доступных Fps
        /// </summary>
        public IEnumerable<string> Fps { get; set; }

        /// <summary>
        /// Картинка в формате Base64
        /// </summary>
        public byte[] Image { get; set; }
    }
}
