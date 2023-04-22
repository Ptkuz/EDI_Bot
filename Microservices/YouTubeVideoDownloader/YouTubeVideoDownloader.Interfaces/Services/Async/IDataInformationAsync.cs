using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models.Response;

namespace YouTubeVideoDownloader.Interfaces.Services.Async
{
    /// <summary>
    /// Асинхронное получение информации
    /// </summary>
    public interface IDataInformationAsync<T> where T : class
    {
        /// <summary>
        /// Асинхронно получить всю информацию о видео по ссылке
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Вся информация о видео по ссылке</returns>
        Task<IYouTubeVideoInfoResponse> GetYouTubeVideoInfoAsync(string url);
    }
}
