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
    /// Аудио
    /// </summary>
    public class Audio : Entity, IAudio
    {
        /// <summary>
        /// Битрейт
        /// </summary>
        public string Bitrate { get; set; } = null!;

        /// <summary>
        /// Формат аудио
        /// </summary>
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Поток
        /// </summary>
        public Info Info { get; set; } = null!;

        public Guid AudioId { get; set; }

        /// <summary>
        /// Информация о аудио на сервере
        /// </summary>
        public ServerInfo ServerInfo { get; set; } = null!;

    }
}
