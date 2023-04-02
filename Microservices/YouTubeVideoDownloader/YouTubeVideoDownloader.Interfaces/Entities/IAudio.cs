using Gurrex.Common.Interfaces.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Аудио
    /// </summary>
    public interface IAudio : IEntity
    {
        /// <summary>
        /// Битрейт аудио
        /// </summary>
        public string Bitrate { get; set; }

        /// <summary>
        /// Формат аудио
        /// </summary>
        public string FormatAudio { get; set; }

    }
}
