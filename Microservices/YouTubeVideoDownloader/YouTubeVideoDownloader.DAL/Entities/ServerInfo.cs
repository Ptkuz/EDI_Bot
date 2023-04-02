using Gurrex.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column("Ref", Order = 4)]
        public string Ref { get; set; } = null!;

        /// <summary>
        /// Размер файла
        /// </summary>
        [Column("Size", Order = 5)]
        public int Size { get; set; }

        /// <summary>
        /// Внешний ключ Video
        /// </summary>
        public Guid VideoId { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;

        /// <summary>
        /// Внешний ключ Audio
        /// </summary>
        public Guid AudioId { get; set; }   

        /// <summary>
        /// Аудио
        /// </summary>
        public Audio Audio { get; set; } = null!;
    }
}
