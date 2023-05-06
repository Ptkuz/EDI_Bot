using VideoLibrary;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронное получение информации
    /// </summary>
    public interface IDataInformationAsync<T, K> where T : class where K : class
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
        /// <returns>Объект <see cref="YouTubeVideo"/></returns>
        Task<YouTubeVideo> GetSpecisicVideoInfoAsync(K specificVideoInfoRequest);


    }
}
