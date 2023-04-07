using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

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
        public ChannelRepositoryAsync(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
