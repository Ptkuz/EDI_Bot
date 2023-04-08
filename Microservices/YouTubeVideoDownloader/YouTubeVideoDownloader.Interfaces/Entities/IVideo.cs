namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Видео
    /// </summary>
    public interface IVideo : IAudio
    {
        /// <summary>
        /// Разрешение
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// Формат видео
        /// </summary>
        public string FormatVideo { get; set; }

        /// <summary>
        /// Количество кадров в секунду (FPS)
        /// </summary>
        public string FrameRate { get; set; }
    }
}
