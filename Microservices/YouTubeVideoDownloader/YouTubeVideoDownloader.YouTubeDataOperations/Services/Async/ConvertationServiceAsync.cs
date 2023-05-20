using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Localization;
using Gurrex.Common.Services.Base;
using Gurrex.Common.Services.Models;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Common.Validations;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.SignalR;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using System.Reflection;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    public class ConvertationServiceAsync : ProcessOperations, IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>, IResources
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

        /// <summary>
        /// Сборка
        /// </summary>
        public Assembly Assembly => StaticHelpers.GetAssemblyInfo().Assembly;

        /// <summary>
        /// Название сборки
        /// </summary>
        public AssemblyName? AssemblyName => StaticHelpers.GetAssemblyInfo().AssemblyName;

        /// <summary>
        /// Путь до файла ресурсов
        /// </summary>
        public string ResourcesPath 
        { 
            get =>  $"{AssemblyName?.Name}.Resources.Services.Async.ConvertationServiceAsync";
        }

        /// <summary>
        /// Событие изменения выходных данных
        /// </summary>
        public event IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>.ProcessHandler? OutputDataChanged;

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

                string resource = ManagerResources.GetString(new Resource(ResourcesPath, "ConvertCommand", Assembly));
                string cmdCommand = ManagerResources.GetResultString(videoFilePath, audioFilePath, convertationModel.Fps, tempraryName);

                ProcessModel processModel = new ProcessModel(appName, AssemblyName?.Name!, directory, cmdCommand, false, false, cancel);

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
