using Gurrex.Common.Interfaces.DAL;
using Gurrex.Common.Interfaces.Entities;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.UnitOfWork;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Models.Requests;
using YouTubeVideoDownloader.Interfaces.Models.Response;

namespace YouTubeVideoDownloader.Interfaces.Services
{
    public interface IDataBaseService<M, Q, P, MI, SI>
        where M : class, IBaseModel, new()
        where Q : class, IGetVideoInfoRequest, new()
        where MI : class
        where P : class, IYouTubeVideoInfoResponse<MI>, new()
        where SI : class, IDownloadVideoRequest, new()
    {


        /// <summary>
        /// Информация о видео
        /// </summary>
        M InfoStream { get; set; }

        Task<bool> CheckYouTubeInfoAsync(Q videoInfoRequest);

        Task<bool> CheckVideoAsync(SI specificVideoInfoRequest);

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
