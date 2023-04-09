using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Interfaces;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    public class DataInformations : IDataInformations
    {
        public void GetInformationByUrl(string url)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetAllVideos(url);

        }
    }
}
