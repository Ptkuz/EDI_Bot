using Gurrex.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Информация о файле на сервере
    /// </summary>
    public class ServerInfo : Entity, IServerInfo
    {
        /// <summary>
        /// Ссылка на файл
        /// </summary>
        public string Ref { get; set; } = null!;

        /// <summary>
        /// Размер файла
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;

        /// <summary>
        /// Аудио
        /// </summary>
        public Audio Audio { get; set; } = null!;
    }
}
