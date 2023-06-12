using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.Interfaces.Models.Services;
using YouTubeVideoDownloader.Interfaces.Services.Base;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронное получение потока
    /// </summary>
    /// <typeparam name="T">Ответ, реализующий интерфейс <see cref="IBaseModel"/></typeparam>
    /// <typeparam name="K">Запрос, реализующий интерфейс <see cref="IBaseModel"/></typeparam>
    /// /// <typeparam name="U">Возвращает информацию о поток</typeparam>
    public interface IDataInformationAsync<T, K, U> where T : class, IBaseModel where K : class, IBaseModel
    {
        /// <summary>
        /// Асинхронно получить всю информацию о видео по ссылке
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Вся информация о видео по ссылке</returns>
        Task<T> GetYouTubeVideoInfoAsync(string url);

        /// <summary>
        /// Асинхронно получить конкретное видео на основе свойств
        /// </summary>
        /// <param name="specificVideoInfoRequest">Свойства видео</param>
        /// <param name="serverSettings">Настройки сервера</param>
        /// <returns>Информация о потоках</returns>
        Task<U> GetSpecisicVideoInfoAsync(K specificVideoInfoRequest, IServerSettings serverSettings);


    }
}
