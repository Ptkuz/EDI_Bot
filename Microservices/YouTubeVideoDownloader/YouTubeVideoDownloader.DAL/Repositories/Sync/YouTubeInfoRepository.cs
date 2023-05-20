using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="YouTubeInfo"/>
    /// </summary>
    public class YouTubeInfoRepository : DbRepository<YouTubeInfo>, IYouTubeInfoRepository<YouTubeInfo>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        public YouTubeInfoRepository(DownloaderContext downloaderContext, ILogger<YouTubeInfoRepository> logger)
            : base(downloaderContext, logger)
        {

        }
    }
}
