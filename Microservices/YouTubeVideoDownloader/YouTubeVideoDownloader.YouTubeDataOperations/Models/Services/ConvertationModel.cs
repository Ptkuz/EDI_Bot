using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Services;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Services
{
    /// <summary>
    /// Модель для сервиса конвертации
    /// </summary>
    public class ConvertationModel : IConvertationModel
    {
        /// <summary>
        /// Путь до файлов
        /// </summary>
        public string DataPath { get; set; } = null!;

        /// <summary>
        /// Имя аудио файла
        /// </summary>
        public string AudioFileName { get; set; } = null!;

        /// <summary>
        /// Имя видео файла
        /// </summary>
        public string VideoFileName { get; set; } = null!;

        /// <summary>
        /// Количество FPS выходного видео
        /// </summary>
        public string Fps { get; set; } = null!;

        /// <summary>
        /// Имя выходного файла
        /// </summary>
        public string FinalFileName { get; set; } = null!;

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtention { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dataPath">Путь до файлов</param>
        /// <param name="audioFileName">Имя аудио файла</param>
        /// <param name="videoFileName">Имя видео файла</param>
        /// <param name="fps">Количество FPS выходного видео</param>
        /// <param name="finalFileName">Имя выходного файла</param>
        /// <param name="fileExtention">Расширение файла</param>
        public ConvertationModel(string dataPath, string audioFileName, string videoFileName, string fps, string finalFileName, string fileExtention) 
        {
            DataPath = dataPath;
            AudioFileName = audioFileName;
            VideoFileName = videoFileName;
            Fps = fps;
            FinalFileName = finalFileName;
            FileExtention = fileExtention;
        }
    }
}
