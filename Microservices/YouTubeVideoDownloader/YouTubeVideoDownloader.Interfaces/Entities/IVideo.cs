using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    public interface IVideo : IEntity
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Продолжительность
        /// </summary>
        int Duration { get; set; }

        /// <summary>
        /// Формат видеодорожки 
        /// </summary>
        string VideoFormat { get; set; }

        /// <summary>
        /// Формат аудиодорожки
        /// </summary>
        string AudioFormat { get; set; }

        /// <summary>
        /// Ссылка на FTP сервере
        /// </summary>
        string FTPRef { get; set; }

        /// <summary>
        /// Размер конечного файла
        /// </summary>
        int Size { get; set; }
    }
}
