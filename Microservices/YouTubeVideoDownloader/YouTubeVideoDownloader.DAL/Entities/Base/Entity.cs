using YouTubeVideoDownloader.Interfaces.Interfaces;

namespace YouTubeVideoDownloader.DAL.Entities.Base
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        public Guid Id { get; set; }
    }
}
