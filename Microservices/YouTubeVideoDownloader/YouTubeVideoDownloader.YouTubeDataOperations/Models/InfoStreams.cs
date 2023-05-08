using VideoLibrary;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models
{
    /// <summary>
    /// Информация о потоках аудио и видео
    /// </summary>
    public class InfoStreams : BaseModel
    {

        /// <summary>
        /// Аудио поток
        /// </summary>
        public YouTubeVideo AudioStream { get; set; } = null!;

        /// <summary>
        /// Видеопоток
        /// </summary>
        public YouTubeVideo? VideoStream { get; set; }

        /// <summary>
        /// Название аудио файла
        /// </summary>
        public string AudioFileName { get; private set; } = null!;

        /// <summary>
        /// Название видео файла
        /// </summary>
        public string? VideoFileName { get; private set; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="audioStream">Аудио поток</param>
        /// <param name="videoStream">Видео поток</param>
        public InfoStreams(YouTubeVideo audioStream, YouTubeVideo? videoStream)
        {
            AudioStream = audioStream;
            VideoStream = videoStream;

            AudioFileName = SetAudioFileName();
            VideoFileName = SetVideoFileName();
        }

        /// <summary>
        /// Установить название для видео файла
        /// </summary>
        /// <returns>Название видео файла</returns>
        private string? SetVideoFileName()
        {
            if (VideoStream is not null)
            {
                return $"{Id}{VideoStream.FileExtension}";
            }
            return null;
        }

        /// <summary>
        /// Установить название для аудио файла
        /// </summary>
        /// <returns>Название аудио файла</returns>
        private string SetAudioFileName()
            => $"{Id}.{AudioStream.AudioFormat}";

    }
}
