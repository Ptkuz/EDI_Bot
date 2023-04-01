using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities.Base;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Сущность видео
    /// </summary>
    public class Video : Entity
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Канал
        /// </summary>
        public Channel Channel { get; set; } = null!;

        /// <summary>
        /// Картинка
        /// </summary>
        public Image Image { get; set; } = null!;

        /// <summary>
        /// Ссылка
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Формат видеодорожки 
        /// </summary>
        public string VideoFormat { get; set; } = null!;

        /// <summary>
        /// Формат аудиодорожки
        /// </summary>
        public string AudioFormat { get; set; } = null!;    

        /// <summary>
        /// Ссылка на FTP сервере
        /// </summary>
        public string FTPRef { get; set; } = null!;

        /// <summary>
        /// Размер конечного файла
        /// </summary>
        public int Size { get; set; }
    }
}
