using Gurrex.Common.DAL.Entities;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class DataBaseServiceAsync : IDataBaseServiceAsync<Audio, Video, Channel, Image, ServerInfo, YouTubeInfo, InfoStreams, Entity>
    {
        public async Task<bool> AfterDownloadAudio(ILogger<Entity> logger, InfoStreams InfoStrem, IAudioRepositoryAsync<Audio> audioRepositoryAsync, IServerInfoRepositoryAsync<ServerInfo> serverInfoRepositoryAsync, CancellationToken cancel)
        {
            Audio audio = new Audio(InfoStrem.Id, InfoStrem.AudioStream.AudioFormat.ToString(), $"{InfoStrem.AudioStream.AudioBitrate} kbps");
            ServerInfo serverInfo = new ServerInfo(logger, InfoStrem.Id, InfoStrem.AudioStream.Uri);
            await audioRepositoryAsync.AddEntityAsync(audio, cancel);
            await serverInfoRepositoryAsync.AddEntityAsync();

            throw new NotImplementedException();
        }

        public Task<bool> AfterDownloadVideoAsync(ILogger logger, InfoStreams InfoStream, IVideoRepositoryAsync<Video> videoRepositoryAsync, IServerInfoRepositoryAsync<ServerInfo> serverInfoRepositoryAsync, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AfterGetYouTubeInfoAsync(ILogger logger, InfoStreams infoStream, IYouTubeInfoRepositoryAsync<YouTubeInfo> youTubeInfoRepositoryAsync, IChannelRerositoryAsync<Channel> channelRerositoryAsync, IImageRepositoryAsync<Image> imageRepositoryAsync, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
    }
}
