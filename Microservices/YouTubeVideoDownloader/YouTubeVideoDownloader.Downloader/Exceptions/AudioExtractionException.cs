using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Downloader.Exceptions
{
    public class AudioExtractionException : Exception
    {
        public AudioExtractionException(string message)
           : base(message)
        { }
    }
}
