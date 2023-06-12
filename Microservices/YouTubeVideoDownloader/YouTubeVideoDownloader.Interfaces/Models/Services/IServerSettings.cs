using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Models.Services
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public interface IServerSettings
    {
        /// <summary>
        /// Путь до хранилища видео
        /// </summary>
        public string PathToVideoStorage { get; set; }

        /// <summary>
        /// Путь до хранилища аудио
        /// </summary>
        public string PathToAudioStorage { get; set; }
    }
}
