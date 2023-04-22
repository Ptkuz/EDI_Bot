using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Models;

namespace YouTubeVideoDownloader.Interfaces.Services.Sync
{
    /// <summary>
    /// Получение информации
    /// </summary>
    public interface IDataInformation
    {
        /// <summary>
        /// Получить коллекцию объектов, реализующих интерфейс <see cref="IYouTubeVideoInfo"/>, по ссылке
        /// </summary>
        /// <param name="url">Ссылка на видео</param>
        /// <returns>Коллекция объектов <see cref="IYouTubeVideoInfo"/></returns>
        IEnumerable<IYouTubeVideoInfo> GetInformationByUrl(string url);
    }
}
