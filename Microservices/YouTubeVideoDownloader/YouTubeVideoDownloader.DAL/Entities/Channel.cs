using Gurrex.Common.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Сущность канала
    /// </summary>
    public class Channel : Entity, IChannel
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
