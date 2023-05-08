using Gurrex.Web.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронное скачивание потоков
    /// </summary>
    /// <typeparam name="T">Информация о видео, полученная по ссылке</typeparam>
    public interface IDownloadStreamAsync<T, K> where T : class where K : Hub
    {
        /// <summary>
        /// Асинхронно скачать поток
        /// </summary>
        /// <returns>True - скачивание завершено успешно, False - Скачивание завершено неудачно</returns>
        Task<bool> DownloadAsync(T infoStreams, ISenderInfoHubAsync<K> senderInfoHubAsync, IHubContext<K> hubContext, CancellationToken cancel);
    }
}
