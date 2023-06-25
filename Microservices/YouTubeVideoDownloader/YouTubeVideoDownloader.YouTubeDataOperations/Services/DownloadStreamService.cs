using Gurrex.Common.Interfaces.Events;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs;
using Gurrex.Web.SignalR.Models;
using Microsoft.AspNetCore.SignalR;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Enums;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    /// <summary>
    /// Асинхронная работа с потоком
    /// </summary>
    public class DownloadStreamService : IDownloadStreamService<InfoStreams>
    {

        /// <summary>
        /// Хаб для передачи статусов клиенту
        /// </summary>
        public ISenderInfoHub<SenderInfoHub> SenderInfoHub { get; set; } = null!;

        /// <summary>
        /// Контекст хаба
        /// </summary>
        public IHubContext<SenderInfoHub> HubContext { get; set; } = null!;

        /// <summary>
        /// Событие изменения прогресса
        /// </summary>
        public event IEvents<ProcessEventArgs>.ProcessHandler? OutputDataChanged;

        public DownloadStreamService(ISenderInfoHub<SenderInfoHub> senderInfoHubAsync, IHubContext<SenderInfoHub> hubContext)
        {
            SenderInfoHub = senderInfoHubAsync;
            HubContext = hubContext;
        }

        /// <summary>
        /// Асинхронно скачать поток
        /// </summary>
        /// <returns>True - скачивание завершено успешно, False - Скачивание завершено неудачно</returns>
        public async Task<bool> DownloadAsync(InfoStreams infoStreams, Predicate<InfoStreams> predicate, CancellationToken cancel)
        {
            try
            {
                YouTubeVideo youTubeAudio = infoStreams.AudioStream;
                Stream audioStream = await youTubeAudio.StreamAsync();
                var audio = DownloadDataAsync(audioStream, infoStreams.AudioFileFullName, SenderInfoHub,
                    (length, status) =>
                    {
                        SignalRMessageModel signalRMessageModel = new SignalRMessageModel();
                        signalRMessageModel.HubConnection = "ReceiveAudioStatusAsync";

                        switch (status)
                        {
                            case ProgressStatus.Started:
                                signalRMessageModel.Message = "Скачивание аудио дорожки началось!";
                                break;
                            case ProgressStatus.Progressing:
                                signalRMessageModel.Message = $"{length}";
                                break;
                            case ProgressStatus.Completed:
                                signalRMessageModel.Message = "Скачивание аудио дорожки закончилось!";
                                break;
                            case ProgressStatus.Error:
                                signalRMessageModel.Message = "Скачивание аудио дорожки завершилось с ошибкой!";
                                break;
                            default:
                                break;
                        }
                        return signalRMessageModel;
                    },
                    HubContext, cancel);

                YouTubeVideo? youTubeVideo = default;
                Stream? videoStream = default;
                Task<bool>? video = default;

                if (predicate(infoStreams))
                {
                    youTubeVideo = infoStreams.VideoStream;
                    videoStream = await youTubeVideo.StreamAsync();
                    video = DownloadDataAsync(videoStream, infoStreams.VideoFileFullName, SenderInfoHub,
                        (length, status) =>
                        {
                            SignalRMessageModel signalRMessageModel = new SignalRMessageModel();
                            signalRMessageModel.HubConnection = "ReceiceVideoStatusAsync";

                            switch (status)
                            {
                                case ProgressStatus.Started:
                                    signalRMessageModel.Message = "Скачивание видео дорожки началось!";
                                    break;
                                case ProgressStatus.Progressing:
                                    signalRMessageModel.Message = $"{length}";
                                    break;
                                case ProgressStatus.Completed:
                                    signalRMessageModel.Message = "Скачивание видео дорожки закончилось!";
                                    break;
                                case ProgressStatus.Error:
                                    signalRMessageModel.Message = "Скачивание видео дорожки завершилось с ошибкой!";
                                    break;
                                default:
                                    break;
                            }
                            return signalRMessageModel;
                        },
                        HubContext, cancel);
                    await Task.WhenAll(audio, video);
                }
                else
                {
                    await Task.WhenAll(audio);
                }

                return true;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        private async Task<bool> DownloadDataAsync(Stream stream, string fileName, ISenderInfoHub<SenderInfoHub> senderInfoHubAsync, Func<long, ProgressStatus, SignalRMessageModel> func, IHubContext<SenderInfoHub> hubContext, CancellationToken cancel)
        {
            var status = ProgressStatus.Started;
            using (stream)
            {
                long length = default;
                byte[] buffer = new byte[8 * 1024];

                using (Stream file = File.Create(fileName))
                {
                    await SendMessageSignalR(senderInfoHubAsync, hubContext, cancel, length, status, func);
                    int len;
                    while ((len = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                        length += len;
                        status = ProgressStatus.Progressing;
                        await SendMessageSignalR(senderInfoHubAsync, hubContext, cancel, length, status, func);
                    }
                }
                status = ProgressStatus.Completed;
                await SendMessageSignalR(senderInfoHubAsync, hubContext, cancel, length, status, func);
            }
            return true;
        }

        private async Task SendMessageSignalR(ISenderInfoHub<SenderInfoHub> senderInfoHub, IHubContext<SenderInfoHub> hubContext, CancellationToken cancel, long length, ProgressStatus progressStatus, Func<long, ProgressStatus, SignalRMessageModel> func)
        {
            var signalRMessageModel = func.Invoke(length, progressStatus);
            await senderInfoHub.ContextSendInfoAllClientsAsync(hubContext, signalRMessageModel.HubConnection, cancel, signalRMessageModel.Message);
        }
    }
}
