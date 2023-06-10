using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Requests
{
    public interface IVideoInfoRequest : IBaseModel
    {
        string Url { get; set; }
    }
}
