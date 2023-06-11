using Gurrex.Common.DAL.Repositories;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="Video"/>
    /// </summary>
    public class VideoRepository : DbRepository<Video>, IVideoRepository<Video>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        public VideoRepository(DownloaderContext downloaderContext, ILogger<VideoRepository> logger)
            : base(downloaderContext, logger)
        {

        }
    }
}
