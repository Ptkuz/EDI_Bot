using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities.Base;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Превью видео
    /// </summary>
    public class Image : Entity
    {
        /// <summary>
        /// Массив байтов картинки
        /// </summary>
        public byte[] ImageBytes { get; set; } = null!;

        /// <summary>
        /// Расширение картинки
        /// </summary>
        public string Extention { get; set; } = null!;

        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;
    }
}
