using Gurrex.Common.DAL.Repositories;
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
        public YouTubeInfoRepository(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
