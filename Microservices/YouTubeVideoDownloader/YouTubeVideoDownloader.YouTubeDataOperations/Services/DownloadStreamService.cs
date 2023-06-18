using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces.Events;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.SignalR;
using VideoLibrary;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Enums;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Services;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    /// <summary>
    /// Асинхронная работа с потоком
    /// </summary>
    public class DownloadStreamService : IDownloadStreamService<InfoStreams, SenderInfoHubAsync, ProcessEventArgs>
    {

        /// <summary>
        /// Хаб для передачи статусов клиенту
        /// </summary>
        public ISenderInfoHubAsync<SenderInfoHubAsync> SenderInfoHubAsync { get; set; } = null!;

        /// <summary>
        /// Контекст хаба
        /// </summary>
        public IHubContext<SenderInfoHubAsync> HubContext { get; set; } = null!;

        /// <summary>
        /// Событие изменения прогресса
        /// </summary>
        public event IEvents<ProcessEventArgs>.ProcessHandler? OutputDataChanged;

        public DownloadStreamService(ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync, IHubContext<SenderInfoHubAsync> hubContext)
        {
            SenderInfoHubAsync = senderInfoHubAsync;
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
                var audio = DownloadDataAsync(audioStream, infoStreams.AudioFileFullName, SenderInfoHubAsync, TypeData.Audio, HubContext, cancel);

                YouTubeVideo? youTubeVideo = default;
                Stream? videoStream = default;
                Task<bool>? video = default;

                if (predicate(infoStreams))
                {
                    youTubeVideo = infoStreams.VideoStream;
                    videoStream = await youTubeVideo.StreamAsync();
                    video = DownloadDataAsync(videoStream, infoStreams.VideoFileFullName, SenderInfoHubAsync, TypeData.Video, HubContext, cancel);
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

        private async Task<bool> DownloadDataAsync(Stream stream, string fileName, ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync, TypeData typeData, IHubContext<SenderInfoHubAsync> hubContext, CancellationToken cancel)
        {
            using (stream)
            {
                long length = default;
                byte[] buffer = new byte[8 * 1024];

                using (Stream file = File.Create(fileName))
                {
                    int len;
                    while ((len = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                        length += len;

                        switch (typeData)
                        {
                            case TypeData.Audio:
                                await senderInfoHubAsync.ContextSendInfoAllClientsAsync(hubContext, "ReceiveAudioStatusAsync", cancel, $"Скачивание аудио дорожки {fileName} - ({length})");
                                break;
                            case TypeData.Video:
                                await senderInfoHubAsync.ContextSendInfoAllClientsAsync(hubContext, "ReceiceVideoStatusAsync", cancel, $"Скачивание видео дорожки {fileName} - ({length})");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return true;
        }
    }
}
