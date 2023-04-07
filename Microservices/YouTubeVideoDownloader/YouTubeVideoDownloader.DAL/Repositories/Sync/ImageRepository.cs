using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="Image"/>
    /// </summary>
    public class ImageRepository : DbRepository<Image>, IImageRepository<Image>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="downloaderContext">Контекст базы данных</param>
        public ImageRepository(DownloaderContext downloaderContext) : base(downloaderContext)
        {

        }
    }
}
