using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.Interfaces.Services.Sync;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Sync
{
    public class DataInformations : IDataInformation
    {
        public IEnumerable<IYouTubeVideoInfo> GetInformationByUrl(string url)
        {
            var youTube = YouTube.Default;
            var videos = youTube.GetAllVideos(url);
            var video = videos.FirstOrDefault(x => x.Resolution == 1080);
            return null;

        }
    }
}
