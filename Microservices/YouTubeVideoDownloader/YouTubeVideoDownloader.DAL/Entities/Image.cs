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
        [Column("ImageBytes", Order = 4)]
        public byte[] ImageBytes { get; set; } = null!;

        /// <summary>
        /// Расширение картинки
        /// </summary>
        [Column("Extention", Order = 5)]
        public string Extention { get; set; } = null!;


        public Guid YouTubeInfoId { get; set; }

        /// <summary>
        /// Информация о потоке
        /// </summary>
        public YouTubeInfo YouTubeInfo { get; set; } = null!;
    }
}
