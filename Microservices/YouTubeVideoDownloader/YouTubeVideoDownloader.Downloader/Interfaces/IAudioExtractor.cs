namespace YouTubeVideoDownloader.Downloader.Interfaces
{
    /// <summary>
    /// Аудио экстрактор
    /// </summary>
    public interface IAudioExtractor : IDisposable
    {
        /// <summary>
        /// Путь до видео
        /// </summary>
        string VideoPath { get; }

        /// <summary>
        /// Записать часть
        /// </summary>
        /// <param name="chunk">Часть</param>
        /// <param name="timeStamp">Время</param>
        void WriteChunk(byte[] chunk, uint timeStamp);
    }
}