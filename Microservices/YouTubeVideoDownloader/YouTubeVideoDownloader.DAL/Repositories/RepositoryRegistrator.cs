using Microsoft.Extensions.DependencyInjection;
using YouTubeVideoDownloader.DAL.Entities;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.DAL.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    /// <summary>
    /// Регистратор репозиториев
    /// </summary>
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
