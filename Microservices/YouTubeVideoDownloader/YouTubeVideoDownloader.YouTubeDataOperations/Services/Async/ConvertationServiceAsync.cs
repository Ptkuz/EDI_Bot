using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Interfaces.Events;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Services.Base;
using Gurrex.Common.Services.Enums;
using Gurrex.Common.Services.Models;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Common.Validations;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Async;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class ConvertationServiceAsync : ProcessOperations, IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>, IResources<AssemblyInfo>
    {
        /// <summary>
        /// Токен отмены
        /// </summary>
        private CancellationToken CancellationToken;

        /// <summary>
        /// Хаб отправки сообщений
        /// </summary>
        public ISenderInfoHubAsync<SenderInfoHubAsync> SenderInfoHubAsync { get; set; } = null!;

        /// <summary>
        /// Контекст хаба
        /// </summary>
        public IHubContext<SenderInfoHubAsync> HubContext { get; set; } = null!;

        public ConvertationServiceAsync(ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync, IHubContext<SenderInfoHubAsync> hubContext) 
        {
            SenderInfoHubAsync = senderInfoHubAsync;
            HubContext = hubContext;
        }

        /// <summary>
        /// Сборка
        /// </summary>
        public AssemblyInfo AssemblyInfo => StaticHelpers.GetAssemblyInfo();

        /// <summary>
        /// Путь до файла ресурсов
        /// </summary>
        public string ResourcesPath
        {
            get => $"{AssemblyInfo.AssemblyName?.Name}.Resources.Services.Async.ConvertationServiceAsync";
        }

        public event IEvents<ProcessEventArgs>.ProcessHandler? OutputDataChanged;

        /// <summary>
        /// Объеденить аудио и видео дорожку
        /// </summary>
        /// <param name="convertationModel">Модель для сервиса конвертации</param>
        /// <param name="assemblyName">Имя сборки</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns></returns>
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

                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "ConvertCommand", AssemblyInfo.Assembly));
                string cmdCommand = ManagerResources.GetResultString(resource, videoFilePath, audioFilePath, convertationModel.Fps, tempraryName);

                ProcessModel processModel = new ProcessModel(appName, AssemblyInfo.AssemblyName?.Name!, directory, cmdCommand, false, true, cancel);

                OutputDataChanged += SendDataSignalR;
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

        protected override void HandleError(object sender, DataReceivedEventArgs e)
        {
            base.HandleError(sender, e);

            string time = "";
            string size;
            if (CurrentData == null)
                return;
            if (CurrentData.Contains("time="))
            {
                time = CurrentData.Substring(CurrentData.IndexOf('t'), 16);
                time = time.Substring(5, 8);
                int fullSeconds = time.ConvertTimeStringToIntSeconds();
                ProcessEventArgs processEventArgs = new ProcessEventArgs(ProcessOutputLevel.Information, fullSeconds.ToString());

                if (!string.IsNullOrEmpty(e.Data) && OutputDataChanged is not null)
                    OutputDataChanged.Invoke(this, processEventArgs, CancellationToken);
            }
        }
        protected override async void HandleOutput(object sender, DataReceivedEventArgs e)
        {
            base.HandleOutput(sender, e);

            string time = "";
            string size;
            if (CurrentData == null)
                return;
            if (CurrentData.Contains("time="))
            {
                time = CurrentData.Substring(CurrentData.IndexOf('t'), 16);
                time = time.Substring(5, 8);
                int fullSeconds = time.ConvertTimeStringToIntSeconds();
                ProcessEventArgs processEventArgs = new ProcessEventArgs(ProcessOutputLevel.Information, fullSeconds.ToString());

                if (!string.IsNullOrEmpty(e.Data) && OutputDataChanged is not null)
                    OutputDataChanged.Invoke(this, processEventArgs, CancellationToken);
            }
        }

        private async Task SendDataSignalR(object sender, ProcessEventArgs data, CancellationToken cancel) 
        {
            await SenderInfoHubAsync.ContextSendInfoAllClientsAsync(HubContext, "ReceiceMergeAsync", cancel, data.Output);
        }

    }
}
