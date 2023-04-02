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
    /// Аудио поток
    /// </summary>
    public class Audio : Entity, IAudio
    {

        /// <summary>
        /// Формат
        /// </summary>
        [Column("FormatAudio", Order = 4)]
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Битрейт
        /// </summary>
        [Column("Bitrate", Order = 5)]
        public string Bitrate { get; set; } = null!;

        /// <summary>
        /// YouTube поток
        /// </summary>
        [ForeignKey("YouTubeInfoId")]
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Информация о аудио на сервере
        /// </summary>
        [ForeignKey("ServerInfoId")]
        public ServerInfo ServerInfo { get; set; } = null!;

    }
}
