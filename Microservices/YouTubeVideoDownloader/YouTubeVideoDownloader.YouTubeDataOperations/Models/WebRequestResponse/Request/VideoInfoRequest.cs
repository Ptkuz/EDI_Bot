using Gurrex.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request
{
    /// <summary>
    /// Запрос на получение информации о видео
    /// </summary>
    public class VideoInfoRequest : BaseModel
    {

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string Url { get; set; } = null!;
    }
}
