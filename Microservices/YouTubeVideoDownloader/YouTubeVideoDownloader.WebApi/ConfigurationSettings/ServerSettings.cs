using YouTubeVideoDownloader.Interfaces.Models.Services;

namespace YouTubeVideoDownloader.WebApi.ConfigurationSettings
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public class ServerSettings : IServerSettings
    {
        /// <summary>
        /// Путь до хранилища видео
        /// </summary>
        public string PathToVideoStorage { get; set; } = null!;

        /// <summary>
        /// Путь до хранилища аудио
        /// </summary>
        public string PathToAudioStorage { get; set;} = null!;
    }
}
