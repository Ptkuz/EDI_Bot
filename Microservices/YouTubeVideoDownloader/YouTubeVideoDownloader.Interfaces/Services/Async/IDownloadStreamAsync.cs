using Gurrex.Common.Interfaces.Events;
using Gurrex.Web.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Services.Base;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронное скачивание потоков
    /// </summary>
    /// <typeparam name="T">Информация о видео, полученная по ссылке</typeparam>
    /// <typeparam name="K">Модель хаба</typeparam>
    /// <typeparam name="U">Событие изменения прогресса</typeparam>
    public interface IDownloadStreamAsync<T, K, U> : IHub<K>, IEvents<U> where K : Hub where U : EventArgs
    {

        /// <summary>
        /// Асинхронно скачать поток
        /// </summary>
        /// <returns>True - скачивание завершено успешно, False - Скачивание завершено неудачно</returns>
        Task<bool> DownloadAsync(T infoStreams, CancellationToken cancel);
    }
}
