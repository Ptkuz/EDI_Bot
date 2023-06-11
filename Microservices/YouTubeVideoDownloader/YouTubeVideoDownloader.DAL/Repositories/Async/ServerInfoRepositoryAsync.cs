using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async;

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
        /// <param name="logger">Логирование</param>
        public ServerInfoRepositoryAsync(DownloaderContext downloaderContext, ILogger<ServerInfoRepositoryAsync> logger) 
            : base(downloaderContext, logger)
        {

        }
    }
}
