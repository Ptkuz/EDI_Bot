using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный сущности <see cref="Audio"/>
    /// </summary>
    public class AudioRepositoryAsync : DbRepositoryAsync<Audio>, IAudioRepositoryAsync<Audio>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных "YouTubeVideoDownloader"</param>
        /// <param name="logger">Логирование</param>
        public AudioRepositoryAsync(DownloaderContext downloaderContext, ILogger<AudioRepositoryAsync> logger) 
            : base(downloaderContext, logger)
        {

        }
    }
}
