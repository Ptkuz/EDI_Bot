using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Видео поток
    /// </summary>
    public class Video : Entity, IVideo
    {

        /// <summary>
        /// Формат
        /// </summary>
        [Column("FormatVideo", Order = 4)]
        public string FormatVideo { get; set; } = null!;

        /// <summary>
        /// Разрешение
        /// </summary>
        [Column("Resolution", Order = 5)]
        public string Resolution { get; set; } = null!;


        /// <summary>
        /// Количество кадров в секунду (FPS)
        /// </summary>
        [Column("FrameRate", Order = 6)]
        public string FrameRate { get; set; } = null!;

        /// <summary>
        /// Формат аудио
        /// </summary>
        [Column("FormatAudio", Order = 7)]
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Битрейт аудио
        /// </summary>
        [Column("Bitrate", Order = 8)]
        public string Bitrate { get; set; } = null!;


        /// <summary>
        /// YouTube поток
        /// </summary>
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Информация о видео на сервере
        /// </summary>
        public ServerInfo ServerInfo { get; set; } = null!;

    }
}
