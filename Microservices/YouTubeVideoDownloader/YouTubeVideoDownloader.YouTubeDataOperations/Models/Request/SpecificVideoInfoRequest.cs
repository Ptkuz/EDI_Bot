using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Request
{
    /// <summary>
    /// Информация о конкретном видео
    /// </summary>
    public class SpecificVideoInfoRequest : BaseModel
    {
        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// Главная информация о видео
        /// </summary>
        public MainInfo MainInfo { get; set; } = null!;

        /// <summary>
        /// Аудио битрейт
        /// </summary>
        public int AudioBitrate { get; set; }

        /// <summary>
        /// Разрешение
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        /// Аудио формат
        /// </summary>
        public AudioFormat AudioFormat { get; set; }

        /// <summary>
        /// Видео формат
        /// </summary>
        public VideoFormat VideoFormat { get; set; }

        /// <summary>
        /// Fps
        /// </summary>
        public int Fps { get; set; }
    }
}
