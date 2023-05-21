using Gurrex.Common.Interfaces.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    public interface IDataBaseServiceAsync<A, V, C, I, S, Y, M, L> 
        where A : class, IAudio, new() 
        where V : class, IVideo, new()
        where C : class, IChannel, new()
        where I : class, IImage, new()
        where S : class, IServerInfo, new()
        where Y : class, IYouTubeInfo, new()
        where M : class, IBaseModel, new()
        where L : class, new()
    {
        Task<bool> AfterGetYouTubeInfoAsync(ILogger<L> logger, M infoStream, IYouTubeInfoRepositoryAsync<Y> youTubeInfoRepositoryAsync, IChannelRerositoryAsync<C> channelRerositoryAsync, IImageRepositoryAsync<I> imageRepositoryAsync, CancellationToken cancel);
        Task<bool> AfterDownloadVideoAsync(ILogger<L> logger, M InfoStream, IVideoRepositoryAsync<V> videoRepositoryAsync, IServerInfoRepositoryAsync<S> serverInfoRepositoryAsync, CancellationToken cancel);
        Task<bool> AfterDownloadAudio(ILogger<L> logger, M InfoStrem, IAudioRepositoryAsync<A> audioRepositoryAsync, IServerInfoRepositoryAsync<S> serverInfoRepositoryAsync, CancellationToken cancel);
    }
}
