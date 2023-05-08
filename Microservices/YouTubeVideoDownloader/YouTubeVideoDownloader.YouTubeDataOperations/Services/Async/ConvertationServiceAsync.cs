using Gurrex.Common.Services.Base;
using Gurrex.Common.Services.Models;
using Gurrex.Common.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Async;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class ConvertationServiceAsync : ProcessOperations, IConvertationServiceAsync
    {
        public event IConvertationServiceAsync.ProcessHandler? OutputDataChanged;

        public async Task MergeAudioVideoData(IConvertationModel convertationModel, string assemblyName, CancellationToken cancel)
        {
            try
            {
                assemblyName.CheckStringForNullOrWhiteSpace();
                string directory = @"F:\MyProjects\EDI_Bot\Microservices\YouTubeVideoDownloader\YouTubeVideoDownloader.WebApi\bin\Debug\net7.0";
                string appName = "ffmpeg.exe";
                string cmdCommand =
                    $" -i \"{convertationModel.DataPath}{convertationModel.VideoFileName}\" " +
                    $"-i \"{convertationModel.DataPath}{convertationModel.AudioFileName}\" " +
                    $"-shortest -vf fps={convertationModel.Fps} {convertationModel.DataPath}{convertationModel.FinalFileName}{convertationModel.FileExtention}";

                ProcessModel processModel = new ProcessModel(appName, assemblyName, directory, cmdCommand, false, false, cancel);

                await StartProcessAsync(processModel);

            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }
    }
}
