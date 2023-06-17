﻿using Gurrex.Common.Services.Models.Events;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.Extensions.DependencyInjection;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.Interfaces.Services.Sync;
using YouTubeVideoDownloader.YouTubeDataOperations.Models;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Sync;
using Image = YouTubeVideoDownloader.DAL.Entities.Image;

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
        public static IServiceCollection AddDownloaderServices(this IServiceCollection services) => services

            .AddTransient<IDataInformation<YouTubeVideoInfoResponse>, DataInformations>()
            .AddTransient<IDataInformationAsync<YouTubeVideoInfoResponse, SpecificVideoInfoRequest, InfoStreams>, DataInformationsAsync>()
            .AddTransient<IDownloadStreamAsync<InfoStreams, SenderInfoHubAsync, ProcessEventArgs>, DownloadStreamAsync>()
            .AddTransient<ISenderInfoHubAsync<SenderInfoHubAsync>, SenderInfoHubAsync>()
            .AddTransient<IConvertationServiceAsync<SenderInfoHubAsync, ProcessEventArgs>, ConvertationServiceAsync>()
            .AddTransient<IDataBaseServiceAsync<InfoStreams, VideoInfoRequest, YouTubeVideoInfoResponse, MainInfo>, DataBaseServiceAsync>()
            ;
    }
}
