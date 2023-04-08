using Gurrex.Common.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Entities
{

    /// <summary>
    /// Канал
    /// </summary>
    public interface IChannel : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

    }
}
