using Gurrex.Common.Services.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Services;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    public interface IConvertationServiceAsync
    {
        delegate void ProcessHandler(object sender, ProcessEventArgs e);
        event ProcessHandler? OutputDataChanged;

        Task MergeAudioVideoData(IConvertationModel convertationModel, string assemblyName, CancellationToken cancel);
    }
}
