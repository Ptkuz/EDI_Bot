using Gurrex.Common.Interfaces.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Models.Requests;
using YouTubeVideoDownloader.Interfaces.Models.Response;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;
using YouTubeVideoDownloader.Interfaces.Services.Base;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    public interface IDataBaseServiceAsync<A, V, C, I, S, Y, M, Q, P, MI>
        where A : class, IAudio, new() 
        where V : class, IVideo, new()
        where C : class, IChannel, new()
        where I : class, IImage, new()
        where S : class, IServerInfo, new()
        where Y : class, IYouTubeInfo, new()
        where M : class, IBaseModel, new()
        where Q : class, IVideoInfoRequest, new()
        where MI: class
        where P : class, IYouTubeVideoInfoResponse<MI>, new()
    {

        /// <summary>
        /// Логирование
        /// </summary>
        ILogger Logger { get;set; }

        /// <summary>
        /// Асинхронный аудио репозиторий
        /// </summary>
        IAudioRepositoryAsync<A> AudioRepositoryAsync { get; set; }

        /// <summary>
        /// Асинхронный репозиторий <see cref="IVideo"/>
        /// </summary>
        IVideoRepositoryAsync<V> VideoRepositoryAsync { get; set; }

        /// <summary>
        /// Асинхронный репозиторий <see cref="IChannel"/>
        /// </summary>
        IChannelRerositoryAsync<C> ChannelRepositoryAsync { get; set; }

        /// <summary>
        /// Асинхронный репозиторий <see cref="IImage"/>
        /// </summary>
        IImageRepositoryAsync<I> ImageRepositoryAsync { get; set; }

        /// <summary>
        /// Асинхронный репозиторий <see cref="IServerInfo"/>
        /// </summary>
        IServerInfoRepositoryAsync<S> ServerInfoRepositoryAsync { get; set; }

        /// <summary>
        /// Асинхронный репозиторий <see cref="IYouTubeInfo"/>
        /// </summary>
        IYouTubeInfoRepositoryAsync<Y> YouTubeInfoRepositoryAsync { get; set; }  

        /// <summary>
        /// Информация о видео
        /// </summary>
        M InfoStream { get; set; }

        /// <summary>
        /// Асинхронные операции с базой данных после получения информации о видео
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - информация успешно добавлена в базу данных, False - информация не добавлена в базу данных, отмена операций</returns>
        Task<bool> AfterGetYouTubeInfoAsync(P response, Q request, CancellationToken cancel);

        /// <summary>
        /// Асинхронные операции с базой данных после получения скачивания видео
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - информация успешно добавлена в базу данных, False - информация не добавлена в базу данных, отмена операций</returns>
        Task<bool> AfterDownloadVideoAsync(CancellationToken cancel);

        /// <summary>
        /// Асинхронные операции с базой данных после скачивания аудио
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - информация успешно добавлена в базу данных, False - информация не добавлена в базу данных, отмена операций</returns>
        Task<bool> AfterDownloadAudioAsync(CancellationToken cancel);
    }
}
