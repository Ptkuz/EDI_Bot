using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Base
{
    public class BaseResponse : BaseModel
    {
        [DataMember]
        public bool IsSuccess { get; private set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public BaseResponse()
            : base()
        {
            IsSuccess = true;
        }

        public BaseResponse(Exception exception, string errorMessage)
            : base() 
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }
    }
}
