using System.ComponentModel.DataAnnotations;
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
        [Key]
        public Guid Id { get; set; }
    }
}
