using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    public static class RepositoryRegistrator
    {
        /// <summary>
        /// Зарегистрировать репозитории
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryInDB(this IServiceCollection services) => services

            // Репозитории работы с Audio
            .AddScoped<IDownloaderRepository<Audio>, DownloaderRepository<Audio>>()

            // Репозитории работы с Channel
            .AddScoped<IDownloaderRepository<Channel>, DownloaderRepository<Channel>>()

            // Репозитории работы с Image
            .AddScoped<IDownloaderRepository<Image>, DownloaderRepository<Image>>()

            // Репозитории работы с ServerInfo
            .AddScoped<IDownloaderRepository<ServerInfo>, DownloaderRepository<ServerInfo>>()

            // Репозитории работы с Video
            .AddScoped<IDownloaderRepository<Video>, DownloaderRepository<Video>>()

            // Репозитории работы с YouTubeInfo
            .AddScoped<IDownloaderRepository<YouTubeInfo>, DownloaderRepository<YouTubeInfo>>()
            ;
    }
}
