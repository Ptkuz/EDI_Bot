using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async;

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

        IAudioRepositoryAsync<A> AudioRepositoryAsync { get; }
        IChannelRerositoryAsync<C> ChannelRerositoryAsync { get; }
        IImageRepositoryAsync<I> ImageRepositoryAsync { get; }  
        IServerInfoRepositoryAsync<S> ServerInfoRepositoryAsync { get; }
        IVideoRepositoryAsync<V> VideoRepositoryAsync { get; }  
        IYouTubeInfoRepositoryAsync<Y> YouTubeInfoRepositoryAsync { get; }

    }
}
