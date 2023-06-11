using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="Channel"/>
    /// </summary>
    public class ChannelRepository : DbRepository<Channel>, IChannelRerository<Channel>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        public ChannelRepository(DownloaderContext downloaderContext, ILogger<ChannelRepository> logger)
            : base(downloaderContext, logger)
        {

        }
    }
}
