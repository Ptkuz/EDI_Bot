using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Interfaces
{
    public interface IDataInformations
    {
        void GetInformationByUrl(string url);
    }
}
