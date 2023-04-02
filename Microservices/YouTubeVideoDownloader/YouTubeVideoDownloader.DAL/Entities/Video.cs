using Gurrex.Common.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Сущность видео
    /// </summary>
    public class Video : Entity, IVideo
    {
        /// <summary>
        /// Разрешение видео
        /// </summary>
        public string Resolution { get; set; } = null!;

        /// <summary>
        /// Формат видео
        /// </summary>
        public string FormatVideo { get; set; } = null!;

        /// <summary>
        /// Количество кадров в секунду (FPS)
        /// </summary>
        public string FrameRate { get; set; } = null!;

        /// <summary>
        /// Битрейт аудио
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

        public Guid VideoId { get; set; }

        /// <summary>
        /// Информация о видео на сервере
        /// </summary>
        public ServerInfo ServerInfo { get; set; } = null!;

    }
}
