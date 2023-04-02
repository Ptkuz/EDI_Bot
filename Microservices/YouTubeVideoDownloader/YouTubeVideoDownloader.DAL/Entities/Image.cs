using Gurrex.Common.DAL.Entities;
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


        public Guid VideoId { get; set; }
        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;
    }
}
