using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Services
{
    /// <summary>
    /// Модель для сервиса конвертации
    /// </summary>
    public interface IConvertationModel : IBaseModel
    {

        /// <summary>
        /// Путь до видео файла
        /// </summary>
        public string FilesPath { get; set; }


        /// <summary>
        /// Имя аудио файла
        /// </summary>
        public string AudioFileName { get; set; }

        /// <summary>
        /// Расширение аудио файла
        /// </summary>
        public string AudioFileExtention { get; set; }

        /// <summary>
        /// Имя видео файла
        /// </summary>
        public string VideoFileName { get; set; }

        /// <summary>
        /// Расширение видео файла
        /// </summary>
        public string VideoFileExnetion { get; set; }

        /// <summary>
        /// Количество FPS выходного видео
        /// </summary>
        public int Fps { get; set; }

        /// <summary>
        /// Имя выходного файла
        /// </summary>
        public string FinalFileName { get; set; }

    }
}
