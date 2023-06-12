using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async;

namespace YouTubeVideoDownloader.DAL
{
    public class UnitOfWork : IUnitOfWork<Audio, Channel, Image, ServerInfo, Video, YouTubeInfo>, IDisposable
    {

        private bool disposed;
        private readonly DownloaderContext _downloaderContext;

        public IAudioRepositoryAsync<Audio> AudioRepositoryAsync { get; }

        public IChannelRerositoryAsync<Channel> ChannelRerositoryAsync { get; }

        public IImageRepositoryAsync<Image> ImageRepositoryAsync { get; }

        public IServerInfoRepositoryAsync<ServerInfo> ServerInfoRepositoryAsync { get; }

        public IVideoRepositoryAsync<Video> VideoRepositoryAsync { get; }

        public IYouTubeInfoRepositoryAsync<YouTubeInfo> YouTubeInfoRepositoryAsync { get; }

        public UnitOfWork(DownloaderContext downloaderContext,
            IAudioRepositoryAsync<Audio> audioRepositoryAsync,
            IChannelRerositoryAsync<Channel> channelRerositoryAsync,
            IImageRepositoryAsync<Image> imageRepositoryAsync,
            IServerInfoRepositoryAsync<ServerInfo> serverInfoRepositoryAsync,
            IVideoRepositoryAsync<Video> videoRepositoryAsync,
            IYouTubeInfoRepositoryAsync<YouTubeInfo> youTubeInfoRepositoryAsync
            ) 
        {
            _downloaderContext = downloaderContext;
            AudioRepositoryAsync = audioRepositoryAsync;
            ChannelRerositoryAsync = channelRerositoryAsync;
            ImageRepositoryAsync = imageRepositoryAsync;
            ServerInfoRepositoryAsync = serverInfoRepositoryAsync;
            VideoRepositoryAsync = videoRepositoryAsync;    
            YouTubeInfoRepositoryAsync = youTubeInfoRepositoryAsync;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _downloaderContext.Database.BeginTransactionAsync();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _downloaderContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
