using Gurrex.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Helpers;
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

        public IUnitOfWork<Audio, Channel, Image, ServerInfo, Video, YouTubeInfo> UnitOfWork { get; set; }

        public InfoStreams InfoStream { get; set; }

        public DataBaseServiceAsync(IUnitOfWork<Audio, Channel, Image, ServerInfo, Video, YouTubeInfo> unitOfWork) 
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> AfterDownloadAudioAsync(CancellationToken cancel)
        {
            string audioFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(audioFileFullName);

            Audio audio = new Audio(InfoStream.Id, InfoStream.AudioStream.AudioFormat.ToString(), $"{InfoStream.AudioStream.AudioBitrate} kbps");
            ServerInfo serverInfo = new ServerInfo(audioFileFullName, length);

            await UnitOfWork.AudioRepository.AddEntityAsync(audio, cancel);
            await UnitOfWork.ServerInfoRepository.AddEntityAsync(serverInfo, cancel);
            return true;
        }

        public async Task<bool> AfterDownloadVideoAsync(CancellationToken cancel)
        {
            string videoFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(videoFileFullName);

            Video video = new Video(InfoStream.Id, $"{InfoStream.VideoStream.Format}", $"{InfoStream.VideoStream.Resolution}", $"{InfoStream.VideoStream.Fps}", $"{InfoStream.AudioStream.AudioFormat}", $"{InfoStream.AudioStream.AudioBitrate}");
            ServerInfo serverInfo = new ServerInfo(videoFileFullName, length);

            await UnitOfWork.VideoRepository.AddEntityAsync(video, cancel);
            await UnitOfWork.ServerInfoRepository.AddEntityAsync(serverInfo, cancel);
            return true;
        }

        public async Task<bool> CheckYouTubeInfoAsync(VideoInfoRequest videoInfoRequest) 
        {
            YouTubeInfo? youTubeInfo = await UnitOfWork.YouTubeInfoRepository
                .SingleOrDefaultEntityAsync(x => x.Url == DataInformationHelpers.GetSimpleYouTubeUrl(videoInfoRequest.Url));
             return youTubeInfo is null ? false : true;
        }

        public async Task<bool> AfterGetYouTubeInfoAsync(YouTubeVideoInfoResponse youTubeVideoInfoResponse, VideoInfoRequest videoInfoRequest, CancellationToken cancel)
        {

            Image image = new Image();
            Channel channel = new Channel(youTubeVideoInfoResponse.MainInfo.Author);
            YouTubeInfo youTubeInfo = new YouTubeInfo(youTubeVideoInfoResponse.MainInfo.Title, DataInformationHelpers.GetSimpleYouTubeUrl(videoInfoRequest.Url), youTubeVideoInfoResponse.MainInfo.Duration, channel, image);

            using (LibraryImage imageLibrary = LibraryImage.Load(youTubeVideoInfoResponse.Image))
            {
                image = new Image(youTubeVideoInfoResponse.Image, ".jpg", $"{imageLibrary.Width} X {imageLibrary.Height}", youTubeInfo);
            }

            using (var transaction = await UnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await UnitOfWork.ChannelRerository.AddEntityAsync(channel, cancel);
                    await UnitOfWork.YouTubeInfoRepository.AddEntityAsync(youTubeInfo, cancel);
                    await UnitOfWork.ImageRepository.AddEntityAsync(image, cancel);
                    transaction.Commit();
                }
                catch (Exception) 
                {
                    transaction.Rollback();
                }
            }
            return true;
        }
    }
}
