using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="YouTubeInfo"/>
    /// </summary>
    public class YouTubeInfoRepositoryAsync : DbRepositoryAsync<YouTubeInfo>, IYouTubeInfoRepositoryAsync<YouTubeInfo>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        public YouTubeInfoRepositoryAsync(DownloaderContext downloaderContext, ILogger<YouTubeInfoRepositoryAsync> logger)
            : base(downloaderContext, logger)
        {

        }
    }
}
