using Gurrex.Common.Helpers;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.UnitOfWork;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Helpers;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;
using Image = YouTubeVideoDownloader.DAL.Entities.Image;
using LibraryImage = SixLabors.ImageSharp.Image;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    public class DataBaseServiceAsync : IDataBaseServiceAsync<InfoStreams, VideoInfoRequest, YouTubeVideoInfoResponse, MainInfo>
    {
        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<DataBaseServiceAsync> _logger;

        private readonly IDownloaderUnitOfWork _unitOfWork;

        public InfoStreams InfoStream { get; set; }

        public DataBaseServiceAsync(IDownloaderUnitOfWork unitOfWork, ILogger<DataBaseServiceAsync> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AfterDownloadAudioAsync(CancellationToken cancel)
        {
            string audioFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(audioFileFullName);

            Audio audio = new Audio(InfoStream.Id, InfoStream.AudioStream.AudioFormat.ToString(), $"{InfoStream.AudioStream.AudioBitrate} kbps");
            ServerInfo serverInfo = new ServerInfo(audioFileFullName, length, audio);
            await _unitOfWork.GetEntityRepository<DownloaderRepository<Audio>, Audio>(typeof(DownloaderRepository<>)).AddEntityAsync(audio, cancel);
            await _unitOfWork.GetEntityRepository<DownloaderRepository<ServerInfo>, ServerInfo>(typeof(DownloaderRepository<>)).AddEntityAsync(serverInfo, cancel);
            return true;
        }

        public async Task<bool> AfterDownloadVideoAsync(CancellationToken cancel)
        {
            string videoFileFullName = InfoStream.FinalFileFullName;
            long length = IOHelpers.GetLengthFile(videoFileFullName);

            YouTubeInfo youTubeInfo = await _unitOfWork.GetEntityRepository<DownloaderRepository<YouTubeInfo>, YouTubeInfo>(typeof(DownloaderRepository<>)).SingleOrDefaultEntityAsync(x => x.Url == DataInformationHelpers.GetSimpleYouTubeUrl(InfoStream.Url));

            if (youTubeInfo is not null)
            {
                Video video = new Video(InfoStream.Id, $"{InfoStream.VideoStream.Format}", $"{InfoStream.VideoStream.Resolution}", $"{InfoStream.VideoStream.Fps}", $"{InfoStream.AudioStream.AudioFormat}", $"{InfoStream.AudioStream.AudioBitrate}", youTubeInfo);
                ServerInfo serverInfo = new ServerInfo(videoFileFullName, length, video);
                await _unitOfWork.GetEntityRepository<DownloaderRepository<Video>, Video>(typeof(DownloaderRepository<>)).AddEntityAsync(video, cancel);
                await _unitOfWork.GetEntityRepository<DownloaderRepository<ServerInfo>, ServerInfo>(typeof(DownloaderRepository<>)).AddEntityAsync(serverInfo, cancel);
                return true;
            }
            return false;

        }

        public async Task<bool> CheckYouTubeInfoAsync(VideoInfoRequest videoInfoRequest)
        {
            YouTubeInfo? youTubeInfo = await _unitOfWork.GetEntityRepository<DownloaderRepository<YouTubeInfo>, YouTubeInfo>(typeof(DownloaderRepository<>))
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

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _unitOfWork.GetEntityRepository<DownloaderRepository<Channel>, Channel>(typeof(DownloaderRepository<>)).AddEntityAsync(channel, cancel);
                    await _unitOfWork.GetEntityRepository<DownloaderRepository<YouTubeInfo>, YouTubeInfo>(typeof(DownloaderRepository<>)).AddEntityAsync(youTubeInfo, cancel);
                    await _unitOfWork.GetEntityRepository<DownloaderRepository<Image>, Image>(typeof(DownloaderRepository<>)).AddEntityAsync(image, cancel);
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
