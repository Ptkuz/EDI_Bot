using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="ServerInfo"/>
    /// </summary>
    public class ServerInfoRepository : DbRepository<ServerInfo>, IServerInfoRepository<ServerInfo>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        public ServerInfoRepository(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
