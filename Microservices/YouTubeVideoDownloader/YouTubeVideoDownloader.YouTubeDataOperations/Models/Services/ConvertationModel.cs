using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Services
{
    /// <summary>
    /// Модель для сервиса конвертации
    /// </summary>
    public class ConvertationModel : BaseModel, IConvertationModel
    {
        /// <summary>
        /// Путь до файлов
        /// </summary>
        public string FilesPath { get; set; } = null!;
        
        /// <summary>
        /// Название аудио
        /// </summary>
        public string AudioFileName { get; set; } = null!;

        /// <summary>
        /// Расширение аудио файла
        /// </summary>
        public string AudioFileExtention { get; set; } = null!;

        /// <summary>
        /// Название видео файла
        /// </summary>
        public string VideoFileName { get; set; } = null!;

        /// <summary>
        /// Расширение видео файла
        /// </summary>
        public string VideoFileExnetion { get; set; } = null!;

        /// <summary>
        /// FPS
        /// </summary>
        public int Fps { get; set; }

        /// <summary>
        /// Конечное название файла
        /// </summary>
        public string FinalFileName { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="filesPath">Путь до файлов</param>
        /// <param name="audioFileName">Имя аудио файла</param>
        /// <param name="audioFileExtention">Расширение видео файла</param>
        /// <param name="videoFileName">Имя видео файла</param>
        /// <param name="videoFileExtention">Расширение видео файла</param>
        /// <param name="fps">FPS</param>
        /// <param name="finalFileName">Имя конечного файла</param>
        /// <param name="finalFileExtention">Расширение конечного файла</param>
        public ConvertationModel(string filesPath, string audioFileName, string audioFileExtention, string videoFileName, string videoFileExtention, int fps, string finalFileName) 
            : base()
        {
            FilesPath = filesPath;
            AudioFileName = audioFileName;
            AudioFileExtention = audioFileExtention;
            VideoFileName = videoFileName;
            VideoFileExnetion = videoFileExtention;
            Fps = fps;
            FinalFileName = finalFileName;
        }
    }
}
