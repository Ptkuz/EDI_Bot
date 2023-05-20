using Gurrex.Common.Interfaces.Events;
using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Base;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронный сервис конвертации
    /// </summary>
    /// <typeparam name="T">Хаб</typeparam>
    /// <typeparam name="K">Событие изменения данных</typeparam>
    public interface IConvertationServiceAsync<T, K> : IHub<T>, IEvents<K> where T : Hub where K : EventArgs
    {
        /// <summary>
        /// Асинхронно объеденить видео и аудио дорожки
        /// </summary>
        /// <param name="convertationModel">Модель конвертации</param>
        /// <param name="assemblyName">Имя сборки</param>
        /// <param name="cancel">Токен отмены</param>
        Task MergeAudioVideoDataAsync(IConvertationModel convertationModel, string assemblyName, CancellationToken cancel);
    }
}
