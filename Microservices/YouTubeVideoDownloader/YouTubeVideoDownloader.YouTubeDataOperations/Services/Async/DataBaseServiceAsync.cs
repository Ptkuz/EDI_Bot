using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.Interfaces.Services.Base;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;
using Image = YouTubeVideoDownloader.DAL.Entities.Image;
using LibraryImage = SixLabors.ImageSharp.Image;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class DataBaseServiceAsync : IDataBaseServiceAsync<Audio, Video, Channel, Image, ServerInfo, YouTubeInfo, InfoStreams, VideoInfoRequest, YouTubeVideoInfoResponse, MainInfo>
    {
        /// <summary>
        /// Логирование
        /// </summary>
        public ILogger Logger { get; set; }
        public IAudioRepositoryAsync<Audio> AudioRepositoryAsync { get; set; }
        public IVideoRepositoryAsync<Video> VideoRepositoryAsync { get; set; }
        public IChannelRerositoryAsync<Channel> ChannelRepositoryAsync { get; set; }
        public IImageRepositoryAsync<Image> ImageRepositoryAsync { get; set; }
        public IServerInfoRepositoryAsync<ServerInfo> ServerInfoRepositoryAsync { get; set; }
        public IYouTubeInfoRepositoryAsync<YouTubeInfo> YouTubeInfoRepositoryAsync { get; set; }
        public InfoStreams InfoStream { get; set; }

        public async Task<bool> AfterDownloadAudioAsync(CancellationToken cancel)
        {
            string audioFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(audioFileFullName);

            Audio audio = new Audio(InfoStream.Id, InfoStream.AudioStream.AudioFormat.ToString(), $"{InfoStream.AudioStream.AudioBitrate} kbps");
            ServerInfo serverInfo = new ServerInfo(audioFileFullName, length);

            await AudioRepositoryAsync.AddEntityAsync(audio, cancel);
            await ServerInfoRepositoryAsync.AddEntityAsync(serverInfo, cancel);
            return true;
        }

        public async Task<bool> AfterDownloadVideoAsync(CancellationToken cancel)
        {
            string videoFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(videoFileFullName);

            Video video = new Video(InfoStream.Id, $"{InfoStream.VideoStream.Format}", $"{InfoStream.VideoStream.Resolution}", $"{InfoStream.VideoStream.Fps}", $"{InfoStream.AudioStream.AudioFormat}", $"{InfoStream.AudioStream.AudioBitrate}");
            ServerInfo serverInfo = new ServerInfo(videoFileFullName, length);

            await VideoRepositoryAsync.AddEntityAsync(video, cancel);
            await ServerInfoRepositoryAsync.AddEntityAsync(serverInfo, cancel);
            return true;
        }

        public async Task<bool> AfterGetYouTubeInfoAsync(YouTubeVideoInfoResponse youTubeVideoInfoResponse, VideoInfoRequest videoInfoRequest, CancellationToken cancel)
        {

            Image image = new Image();
            Channel channel = new Channel(youTubeVideoInfoResponse.MainInfo.Author);
            YouTubeInfo youTubeInfo = new YouTubeInfo(youTubeVideoInfoResponse.MainInfo.Title, videoInfoRequest.Url, youTubeVideoInfoResponse.MainInfo.Duration, channel, image);
            using (LibraryImage imageLibrary = LibraryImage.Load(youTubeVideoInfoResponse.Image)) 
            {
                image = new Image(youTubeVideoInfoResponse.Image, ".jpg", $"{imageLibrary.Width} X {imageLibrary.Height}", youTubeInfo);
            }

            await ChannelRepositoryAsync.AddEntityAsync(channel, cancel);
            await YouTubeInfoRepositoryAsync.AddEntityAsync(youTubeInfo, cancel);
            await ImageRepositoryAsync.AddEntityAsync(image, cancel);
            youTubeInfo.Image = image;
            await YouTubeInfoRepositoryAsync.UpdateEntityAsync(youTubeInfo, cancel);
            return true;
        }
    }
}
