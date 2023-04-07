using Gurrex.Common.DAL.Repositories;
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
        public AudioRepositoryAsync(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
