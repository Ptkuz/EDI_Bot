using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Response
{
    /// <summary>
    /// Общая главная информация о видео
    /// </summary>
    public interface IMainInfoResponse
    {
        /// <summary>
        /// Название
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Продолжительность в секундах
        /// </summary>
        int? Duration { get; set; }
    }
}
