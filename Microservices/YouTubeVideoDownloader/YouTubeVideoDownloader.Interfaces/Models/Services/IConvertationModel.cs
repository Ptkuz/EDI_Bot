using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Models.Services
{
    /// <summary>
    /// Модель для сервиса конвертации
    /// </summary>
    public interface IConvertationModel
    {
        /// <summary>
        /// Путь до файлов
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// Имя аудио файла
        /// </summary>
        public string AudioFileName { get; set; }

        /// <summary>
        /// Имя видео файла
        /// </summary>
        public string VideoFileName { get; set; }

        /// <summary>
        /// Количество FPS выходного видео
        /// </summary>
        public string Fps { get; set; }

        /// <summary>
        /// Имя выходного файла
        /// </summary>
        public string FinalFileName { get; set; }

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtention { get; set; }
    }
}
