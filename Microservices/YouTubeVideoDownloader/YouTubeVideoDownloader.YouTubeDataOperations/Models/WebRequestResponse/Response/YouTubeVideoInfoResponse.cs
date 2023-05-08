using Gurrex.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response
{
    /// <summary>
    /// Информация о YouTube ролике, полученном по ссылке
    /// </summary>
    public class YouTubeVideoInfoResponse : BaseModel
    {

        /// <summary>
        /// Главная информация о видео
        /// </summary>
        public MainInfo MainInfo { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио битрейтов
        /// </summary>
        public IEnumerable<string> AudioBitrates { get; set; } = null!;

        /// <summary>
        /// Пееречисление доступных
        /// </summary>
        public IEnumerable<string> Resolutions { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио форматов
        /// </summary>
        public IEnumerable<string> AudioFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление видео форматов
        /// </summary>
        public IEnumerable<string> VideoFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных Fps
        /// </summary>
        public IEnumerable<string> Fps { get; set; } = null!;

        /// <summary>
        /// Картинка в формате Base64
        /// </summary>
        public byte[] Image { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="mainInfo">Главная информация о видео</param>
        /// <param name="audioBitrates">Перечисление аудио битрейтов</param>
        /// <param name="resolutions">Перечисление разрешений</param>
        /// <param name="audioFormats">Перечисление аудио форматов</param>
        /// <param name="videoFormats">Перечислене видео форматов</param>
        /// <param name="fps">Перечислене Fps</param>
        /// <param name="image">Массив байтов картинки</param>
        public YouTubeVideoInfoResponse(MainInfo mainInfo, IEnumerable<string> audioBitrates, IEnumerable<string> resolutions, IEnumerable<string> audioFormats, IEnumerable<string> videoFormats, IEnumerable<string> fps, byte[] image)
           : base()
        {
            MainInfo = mainInfo;
            AudioBitrates = audioBitrates;
            Resolutions = resolutions;
            AudioFormats = audioFormats;
            VideoFormats = videoFormats;
            Fps = fps;
            Image = image;
        }
    }
}
