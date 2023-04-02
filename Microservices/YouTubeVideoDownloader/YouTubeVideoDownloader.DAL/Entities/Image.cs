using Gurrex.Common.DAL.Entities;

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


        public Guid VideoId { get; set; }
        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;
    }
}
