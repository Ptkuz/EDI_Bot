using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Services.Sync
{
    /// <summary>
    /// Получение информации
    /// </summary>
    public interface IDataInformation<T>
    {
        /// <summary>
        /// Получить всю информацию о видео по ссылке
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Вся информация о видео по ссылке</returns>
        T GetYouTubeVideoInfo(string url);
    }
}
