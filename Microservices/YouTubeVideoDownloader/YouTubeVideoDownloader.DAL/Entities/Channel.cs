using Gurrex.Common.DAL.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Сущность канала
    /// </summary>
    public class Channel : Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция видео
        /// </summary>
        public virtual IQueryable<Video> Videos { get; set; } = null!;
    }
}
