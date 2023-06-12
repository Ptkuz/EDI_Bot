using Gurrex.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<Audio, Channel, Image, ServerInfo, Video, YouTubeInfo>, IDisposable
    {

        private bool disposed;
        private readonly DownloaderContext _downloaderContext;

        public IDownloaderRepository<Audio> AudioRepository { get; }

        public IDownloaderRepository<Channel> ChannelRerository { get; }

        public IDownloaderRepository<Image> ImageRepository { get; }

        public IDownloaderRepository<ServerInfo> ServerInfoRepository { get; }

        public IDownloaderRepository<Video> VideoRepository { get; }

        public IDownloaderRepository<YouTubeInfo> YouTubeInfoRepository { get; }

        public UnitOfWork(DownloaderContext downloaderContext,
            IDownloaderRepository<Audio> audioRepository,
            IDownloaderRepository<Channel> channelRerository,
            IDownloaderRepository<Image> imageRepository,
            IDownloaderRepository<ServerInfo> serverInfoRepository,
            IDownloaderRepository<Video> videoRepository,
            IDownloaderRepository<YouTubeInfo> youTubeInfoRepository
            )
        {
            _downloaderContext = downloaderContext;
            AudioRepository = audioRepository;
            ChannelRerository = channelRerository;
            ImageRepository = imageRepository;
            ServerInfoRepository = serverInfoRepository;
            VideoRepository = videoRepository;
            YouTubeInfoRepository = youTubeInfoRepository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _downloaderContext.Database.BeginTransactionAsync();
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _downloaderContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
