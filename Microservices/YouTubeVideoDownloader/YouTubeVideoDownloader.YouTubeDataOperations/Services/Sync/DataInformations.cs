using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.Interfaces.Services.Sync;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Sync
{
    /// <summary>
    /// Информация о видео и аудио
    /// </summary>
    public class DataInformations : DataInformation, IDataInformation<YouTubeVideoInfoResponse>
    {
        /// <summary>
        /// Получить информациб о видео по ссылке
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public YouTubeVideoInfoResponse GetYouTubeVideoInfo(string url)
        {
            //YouTube youTube = YouTube.Default;

            //IEnumerable<YouTubeVideo> videos = youTube
            //    .GetAllVideos(url);

            //YouTubeVideo youTubeVideo = GetYouTubeVideo(videos);
            //MainInfo mainInfo = GetMainInfo(youTubeVideo);

            //IEnumerable<int> audioBitrates = GetEnumerableAudioBitrates(videos);
            //IEnumerable<int> resolutions = GetEnumerableResolutions(videos);
            //IEnumerable<AudioFormat> audioFormats = GetEnumerableAudioFormat(videos);
            //IEnumerable<VideoFormat> videoFormats = GetEnumerableVideoFormat(videos);
            //IEnumerable<int> fps = GetEnumerableFps(videos);

            //YouTubeVideoInfoResponse youTubeVideoInfo = new YouTubeVideoInfoResponse(mainInfo, audioBitrates, resolutions, audioFormats, videoFormats, fps);

            return null;

        }
    }
}
