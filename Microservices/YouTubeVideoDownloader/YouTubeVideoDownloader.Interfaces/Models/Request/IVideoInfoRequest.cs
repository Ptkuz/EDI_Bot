using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Request
{
    /// <summary>
    /// Запрос на получение информации о видео
    /// </summary>
    public interface IVideoInfoRequest : IBaseModel
    {
        /// <summary>
        /// Сслыка на видео
        /// </summary>
        string Url { get; set; }
    }
}
