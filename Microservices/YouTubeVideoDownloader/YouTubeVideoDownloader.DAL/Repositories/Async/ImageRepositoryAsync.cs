using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    internal class ImageRepositoryAsync : DbRepositoryAsync<Image>, IVideoRepositoryAsync<Image>
    {
        public ImageRepositoryAsync(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
