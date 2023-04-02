using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    public class VideoRepositoryAsync : DbRepositoryAsync<Video>, IVideoRepositoryAsync
    {
        public VideoRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
