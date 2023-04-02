using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Ассинхронный репозиторий работы с <see cref="Video"/>
    /// </summary>
    public class VideoRepositoryAsync : DbRepositoryAsync<Video>, IVideoRepositoryAsync<Video>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        public VideoRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
