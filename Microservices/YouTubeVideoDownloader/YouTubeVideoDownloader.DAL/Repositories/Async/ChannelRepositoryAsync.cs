using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="Channel"/>
    /// </summary>
    public class ChannelRepositoryAsync : DbRepositoryAsync<Channel>, IChannelRerositoryAsync<Channel>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных "YouTubeVideoDownloader"</param>
        /// <param name="logger">Логирование"</param>
        public ChannelRepositoryAsync(DownloaderContext downloaderContext, ILogger<ChannelRepositoryAsync> logger) 
            : base(downloaderContext, logger)
        {

        }
    }
}
