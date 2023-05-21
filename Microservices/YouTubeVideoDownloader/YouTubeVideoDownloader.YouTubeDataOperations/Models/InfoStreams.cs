using System.Diagnostics;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models
{
    /// <summary>
    /// Информация о потоках аудио и видео
    /// </summary>
    public class InfoStreams : BaseModel
    {

        private string audioFileName = null!;
        private string audioFileExtention = null!;

        private string? videoFileName;
        private string? videoFileExtention;

        /// <summary>
        /// Аудио поток
        /// </summary>
        public YouTubeVideo AudioStream { get; set; } = null!;

        /// <summary>
        /// Название аудио файла
        /// </summary>
        public string AudioFileName 
        {
            get => audioFileName;
            private set => audioFileName = value;
        }

        /// <summary>
        /// Расширение аудио файла
        /// </summary>
        public string AudioFileExtention 
        {
            get => audioFileExtention; 
            private set => audioFileExtention = value;
        }

        /// <summary>
        /// Путь до аудио файла
        /// </summary>
        public string AudioFileFullName {get;set; } = null!;

        /// <summary>
        /// Видеопоток
        /// </summary>
        public YouTubeVideo? VideoStream { get; set; }


        /// <summary>
        /// Название видео файла
        /// </summary>
        public string? VideoFileName 
        {
            get => videoFileName;
            private set 
            {
                if (VideoStream is not null && !String.IsNullOrWhiteSpace(value)) 
                {
                    videoFileName = value;
                }
            } 
        }

        /// <summary>
        /// Расширение видео файла
        /// </summary>
        public string? VideoFileExtention 
        {
            get => videoFileExtention;
            private set 
            {
                if (VideoStream is not null && !String.IsNullOrWhiteSpace(value))
                {
                    videoFileExtention = value;
                }
            } 
        }

        /// <summary>
        /// Путь до видео файла
        /// </summary>
        public string? VideoFileFullName { get; private set; }

        /// <summary>
        /// Конечное полное имя файла
        /// </summary>
        public string FinalFileFullName { get; private set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public InfoStreams() 
        {
            
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="audioStream">Аудио поток</param>
        /// <param name="videoStream">Видео поток</param>
        /// <param name="serverSettings">Настройки приложения</param>
        public InfoStreams(YouTubeVideo? videoStream,  YouTubeVideo audioStream, IServerSettings serverSettings)
            : this(audioStream, serverSettings)
        {
            VideoStream = videoStream;
            VideoFileName = $"video_{Id}";
            VideoFileExtention = videoStream?.FileExtension;
            VideoFileFullName = SetPathVideoFileName(serverSettings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="audioStream"></param>
        /// <param name="serverSettings"></param>
        public InfoStreams(YouTubeVideo audioStream, IServerSettings serverSettings)
        {
            AudioStream = audioStream;
            AudioFileName = $"audio_{Id}";
            AudioFileExtention = $".{audioStream.AudioFormat}";
            AudioFileFullName = SetPathAudioFileName(serverSettings);
            FinalFileFullName = SetPathFinalAudioFileFullName(serverSettings);
        }

        /// <summary>
        /// Установить название для видео файла
        /// </summary>
        /// <returns>Название видео файла</returns>
        private string? SetPathVideoFileName(IServerSettings serverSettings)
        {
            if (!String.IsNullOrWhiteSpace(VideoFileName))
            {
                string path = Path.Combine(serverSettings.PathToVideoStorage, VideoFileName);
                return $"{path}{VideoFileExtention}";
            }
            return null;
        }

        /// <summary>
        /// Установить название для аудио файла
        /// </summary>
        /// <returns>Название аудио файла</returns>
        private string SetPathAudioFileName(IServerSettings serverSettings)
        {
            if (String.IsNullOrWhiteSpace(VideoFileName))
            {
                string path = Path.Combine(serverSettings.PathToAudioStorage, AudioFileName);
                return $"{path}{AudioFileExtention}";
            }
            else
            {
                string path = Path.Combine(serverSettings.PathToVideoStorage, AudioFileName);
                return $"{path}{AudioFileExtention}";
            }
        }

        private string SetPathFinalAudioFileFullName(IServerSettings serverSettings) 
        {
            if (VideoStream is null)
            {
                string path = Path.Combine(serverSettings.PathToAudioStorage, AudioStream.Title);
                return $"{path}{AudioFileExtention}";
            }
            else
            {
                string path = Path.Combine(serverSettings.PathToVideoStorage, VideoStream.Title);
                return $"{path}{VideoFileExtention}";
            }
        }
    }
}
