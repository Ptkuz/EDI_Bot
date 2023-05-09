using Gurrex.Common.Helpers;
using Gurrex.Common.Services.Base;
using Gurrex.Common.Services.Models;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Common.Validations;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.SignalR;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Async;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class ConvertationServiceAsync : ProcessOperations, IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>
    {
        private CancellationToken CancellationToken;

        public ISenderInfoHubAsync<SenderInfoHubAsync> SenderInfoHubAsync { get; set; }
        public IHubContext<SenderInfoHubAsync> HubContext { get; set; }

        public event IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>.ProcessHandler? OutputDataChanged;

        public async Task MergeAudioVideoDataAsync(IConvertationModel convertationModel, string assemblyName, CancellationToken cancel)
        {
            bool exception = false;

            string? videoFilePath = default;
            string? audioFilePath = default;
            string? tempraryName = default;

            try
            {
                CancellationToken = cancel;
                assemblyName.CheckStringForNullOrWhiteSpace();
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string appName = "ffmpeg.exe";

                IOHelpers.CheckExistDirectory(convertationModel.FilesPath);

                videoFilePath = $"{IOHelpers.PathCombine(true, false, convertationModel.FilesPath, $"{convertationModel.VideoFileName}{convertationModel.VideoFileExnetion}")}";
                audioFilePath = $"{IOHelpers.PathCombine(true, false, convertationModel.FilesPath, $"{convertationModel.AudioFileName}{convertationModel.AudioFileExtention}")}";
                tempraryName = $"{IOHelpers.PathCombine(false, false, convertationModel.FilesPath, $"convert_{convertationModel.VideoFileName}{convertationModel.VideoFileExnetion}")}";

                string cmdCommand =
                    $" -i \"{videoFilePath}\" " +
                    $"-i \"{audioFilePath}\" " +
                    $"-shortest -vf fps={convertationModel.Fps} {tempraryName}";

                ProcessModel processModel = new ProcessModel(appName, assemblyName, directory, cmdCommand, false, false, cancel);

                await StartProcessAsync(processModel);
                IOHelpers.ReplaceFile(tempraryName, convertationModel.FinalFileName);
            }
            catch (OperationCanceledException)
            {
                exception = true;
                IOHelpers.DeleteFile(convertationModel.FinalFileName);
                throw;
            }
            catch (Exception)
            {
                exception = true;
                IOHelpers.DeleteFile(convertationModel.FinalFileName);
                throw;
            }
            finally 
            {
                if (!exception) 
                {
                    audioFilePath.CheckStringForNullOrWhiteSpace();
                    videoFilePath.CheckStringForNullOrWhiteSpace();
                    IOHelpers.DeleteFile(audioFilePath);
                    IOHelpers.DeleteFile(videoFilePath);
                }
            }
        }

    }
}
