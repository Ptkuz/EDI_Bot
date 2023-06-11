using Gurrex.Common.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Entities
{
    /// <summary>
    /// Картинка
    /// </summary>
    public interface IImage : IEntity
    {
        /// <summary>
        /// Массив байтов картинки
        /// </summary>
        public byte[] ImageBytes { get; set; }

        /// <summary>
        /// Расширение картинки
        /// </summary>
        public string Extention { get; set; }
    }
}
