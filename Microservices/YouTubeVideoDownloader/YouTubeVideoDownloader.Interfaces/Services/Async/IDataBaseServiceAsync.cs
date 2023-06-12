using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Models.Requests;
using YouTubeVideoDownloader.Interfaces.Models.Response;

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
        where MI : class
        where P : class, IYouTubeVideoInfoResponse<MI>, new()
    {

        /// <summary>
        /// Логирование
        /// </summary>
        ILogger Logger { get; set; }

        /// <summary>
        /// Информация о видео
        /// </summary>
        M InfoStream { get; set; }

        IUnitOfWork<A, C, I, S, V, Y> UnitOfWork { get; set; }

        Task<bool> BeforeGetYouTubeInfoAsync(Q videoInfoRequest);

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
