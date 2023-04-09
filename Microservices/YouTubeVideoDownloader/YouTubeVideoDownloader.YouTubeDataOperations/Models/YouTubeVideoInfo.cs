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
        /// Заголовок видео
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Название канала
        /// </summary>
        public string ChannelName { get; set; } = null!;

        /// <summary>
        /// Формат аудио дорожки
        /// </summary>
        public string AudioFormat { get; set; } = null!;

        /// <summary>
        /// Формат видео дорожки
        /// </summary>
        public string VideoFormat { get; set; } = null!;

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
