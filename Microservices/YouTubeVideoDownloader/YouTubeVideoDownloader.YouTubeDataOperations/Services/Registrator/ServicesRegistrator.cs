using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs;
using Microsoft.Extensions.DependencyInjection;
using YouTubeVideoDownloader.Interfaces.Services;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services.Registrator
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
        public static IServiceCollection AddDownloaderServices(this IServiceCollection services) => services
            .AddTransient<IDataInformationService<GetVideoInfoResponse, DownloadVideoRequest, InfoStreams>, DataInformationsService>()
            .AddTransient<IDownloadStreamService<InfoStreams>, DownloadStreamService>()
            .AddTransient<ISenderInfoHub<SenderInfoHub>, SenderInfoHub>()
            .AddTransient<IConvertationService<SenderInfoHub, ProcessEventArgs>, ConvertationService>()
            .AddTransient<IDataBaseService<InfoStreams, GetVideoInfoRequest, GetVideoInfoResponse, MainInfo, DownloadVideoRequest>, DataBaseServiceAsync>()
            ;
    }
}
