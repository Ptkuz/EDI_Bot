using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response
{
    public class DownloadVideoResponse : BaseResponse
    {

        [DataMember]
        public string Message { get; set; }

        public DownloadVideoResponse(string message) 
            : base()
        {
            Message = message;
        }

        public DownloadVideoResponse(Exception exception, string errorMessage) 
            : base(exception, errorMessage)
        {
            
        }
    }
}
