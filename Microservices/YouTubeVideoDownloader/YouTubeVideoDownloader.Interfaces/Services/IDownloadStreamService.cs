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

namespace YouTubeVideoDownloader.Interfaces.Services
{
    /// <summary>
    /// Асинхронное скачивание потоков
    /// </summary>
    /// <typeparam name="T">Информация о видео, полученная по ссылке</typeparam>
    public interface IDownloadStreamService<T>
        where T : IBaseModel
    {

        /// <summary>
        /// Асинхронно скачать поток
        /// </summary>
        /// <returns>True - скачивание завершено успешно, False - Скачивание завершено неудачно</returns>
        Task<bool> DownloadAsync(T infoStreams, Predicate<T> predicate, CancellationToken cancel);
    }
}
