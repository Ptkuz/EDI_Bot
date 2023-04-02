using Gurrex.Common.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Канал
    /// </summary>
    public class Channel : Entity, IChannel
    {
        /// <summary>
        /// Название канала
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция потоков
        /// </summary>
        public IQueryable<Info> Infos { get; set; } = null!;
    }
}
