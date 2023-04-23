using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.Interfaces.Services.Sync;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Sync;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    /// <summary>
    /// Регистратор сервисов
    /// </summary>
    public static class ServicesRegistrator
    {
        /// <summary>
        /// Добавить сервисы
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns></returns>
        public static IServiceCollection AddDownloadServices(this IServiceCollection services) => services
            .AddTransient<IDataInformation<YouTubeVideoInfoResponse>, DataInformations>()
            .AddTransient<IDataInformationAsync<YouTubeVideoInfoResponse>, DataInformationsAsync>()
            ;
    }
}
