using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Enums
{
    internal enum ProgressStatus : int
    {
        Started = 0,
        Progressing = 1,
        Completed = 2,
        Error = 3
    }
}
