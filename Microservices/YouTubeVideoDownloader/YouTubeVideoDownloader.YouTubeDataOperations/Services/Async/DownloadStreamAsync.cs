using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.SignalR;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Enums;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Async
{
    /// <summary>
    /// Асинхронная работа с потоком
    /// </summary>
    public class DownloadStreamAsync : IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync>
    {
        /// <summary>
        /// Асинхронно скачать поток
        /// </summary>
        /// <returns>True - скачивание завершено успешно, False - Скачивание завершено неудачно</returns>
        public async Task<bool> DownloadAsync(InfoStreams infoStreams, ISenderInfoHubAsync<SenderInfoHubAsync> senderInfoHubAsync, IHubContext<SenderInfoHubAsync> hubContext, CancellationToken cancel)
        {
            YouTubeVideo youTubeAudio = infoStreams.AudioStream;
            Stream audioStream = await youTubeAudio.StreamAsync();
            var audio = DownloadDataAsync(audioStream, infoStreams.AudioFileName, senderInfoHubAsync, TypeData.Audio, hubContext, cancel);

            YouTubeVideo? youTubeVideo = default;
            Stream? videoStream = default;
            Task<bool>? video = default;


            if (infoStreams.VideoStream is not null && infoStreams.VideoFileName is not null)
            {
                youTubeVideo = infoStreams.VideoStream;
                videoStream = await youTubeVideo.StreamAsync();
                video = DownloadDataAsync(videoStream, infoStreams.VideoFileName, senderInfoHubAsync, TypeData.Video, hubContext, cancel);
                await Task.WhenAll(audio, video);
            }
            else
            {
                await DownloadDataAsync(audioStream, infoStreams.AudioFileName, senderInfoHubAsync, TypeData.Audio, hubContext, cancel);
            }
            return true;
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
