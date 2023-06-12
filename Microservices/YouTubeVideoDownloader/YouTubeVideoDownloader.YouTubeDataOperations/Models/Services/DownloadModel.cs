using YouTubeVideoDownloader.DAL.Entities;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Services
{
    public class DownloadModel
    {
        public Audio Audio { get; set; }
        public ServerInfo ServerInfo { get; set; }
        public Video Video { get; set; }

        public DownloadModel(ServerInfo serverInfo)
        {
            ServerInfo = serverInfo;
        }

        public DownloadModel(ServerInfo serverInfo, Audio audio)
            : this(serverInfo)
        {
            Audio = audio;
        }

        public DownloadModel(ServerInfo serverInfo, Video video)
         : this(serverInfo)
        {
            Video = video;
        }
    }
}
