using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Канал на YouTube
    /// </summary>
    public class Channel : Entity, IChannel
    {
        /// <summary>
        /// Название канала
        /// </summary>
        [Column("Name", Order = 4)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция YouTube потоков
        /// </summary>
        public IQueryable<YouTubeInfo> YouTubeInfos { get; set; } = null!;
    }
}
