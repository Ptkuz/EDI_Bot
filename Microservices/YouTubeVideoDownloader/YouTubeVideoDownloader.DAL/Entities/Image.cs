using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Превью видео
    /// </summary>
    public class Image : Entity, IImage
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
        /// Информация о потоке
        /// </summary>
        public Info Info { get; set; } = null!;
    }
}
