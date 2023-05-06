using Gurrex.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Request
{
    /// <summary>
    /// Запрос на получение информации о видео
    /// </summary>
    public class VideoInfoRequest : BaseModel
    {

        /// <summary>
        /// Тип, из которого брать ресурсы
        /// </summary>
        public override string? TypeName { get; set; } = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get =>
                 TypeName is not nameof(VideoInfoRequest) ?
                    base.ResourcesPath :
                    $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Request.VideoInfoRequest";
        }

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string Url { get; set; } = null!;
    }
}
