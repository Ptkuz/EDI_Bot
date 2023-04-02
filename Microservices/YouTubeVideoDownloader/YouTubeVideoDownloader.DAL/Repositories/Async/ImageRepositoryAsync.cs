using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    internal class ImageRepositoryAsync : DbRepositoryAsync<Image>, IImageRepositoryAsync<Image>
    {
        public ImageRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
