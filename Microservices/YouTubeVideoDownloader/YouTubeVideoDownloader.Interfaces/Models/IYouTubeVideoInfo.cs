using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Models
{
    /// <summary>
    /// Информация о видео
    /// </summary>
    public interface IYouTubeVideoInfo
    {
        /// <summary>
        /// Заголовок видео
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Название канала
        /// </summary>
        string ChannelName { get; set; }

        /// <summary>
        /// Формат аудио дорожки
        /// </summary>
        string AudioFormat { get; set; }

        /// <summary>
        /// Формат видео дорожки
        /// </summary>
        string VideoFormat { get; set; }

        /// <summary>
        /// Количество кадров в секунду
        /// </summary>
        public int FrameRate { get; set; }

        /// <summary>
        /// Размер видео
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Битрейт аудио
        /// </summary>
        public int Bitrate { get; set; }

        /// <summary>
        /// Разрешение
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; }
    }
}
