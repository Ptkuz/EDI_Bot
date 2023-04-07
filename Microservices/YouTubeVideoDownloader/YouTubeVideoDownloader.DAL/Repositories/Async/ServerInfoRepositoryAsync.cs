using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="ServerInfo"/>
    /// </summary>
    public class ServerInfoRepositoryAsync : DbRepositoryAsync<ServerInfo>, IServerInfoRepositoryAsync<ServerInfo>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        public ServerInfoRepositoryAsync(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
