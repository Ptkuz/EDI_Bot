using Gurrex.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.Interfaces.DAL
{
    public interface IUnitOfWork<A, C, I, S, V, Y>
        where A : class, IAudio, new()
        where C : class, IChannel, new()
        where I : class, IImage, new()
        where S : class, IServerInfo, new()
        where V : class, IVideo, new()
        where Y : class, IYouTubeInfo, new()
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        IDownloaderRepository<A> AudioRepository { get; }
        IDownloaderRepository<C> ChannelRerository { get; }
        IDownloaderRepository<I> ImageRepository { get; }
        IDownloaderRepository<S> ServerInfoRepository { get; }
        IDownloaderRepository<V> VideoRepository { get; }
        IDownloaderRepository<Y> YouTubeInfoRepository { get; }

    }
}
