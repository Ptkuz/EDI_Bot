using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Ассинхронный репозиторий работы с <see cref="Image"/>
    /// </summary>
    public class ImageRepositoryAsync : DbRepositoryAsync<Image>, IImageRepositoryAsync<Image>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        public ImageRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
