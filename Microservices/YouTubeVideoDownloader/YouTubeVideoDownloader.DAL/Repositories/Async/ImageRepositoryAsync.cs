using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    internal class ImageRepositoryAsync : DbRepositoryAsync<Image>, IImageRepositoryAsync
    {
        public ImageRepositoryAsync(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
