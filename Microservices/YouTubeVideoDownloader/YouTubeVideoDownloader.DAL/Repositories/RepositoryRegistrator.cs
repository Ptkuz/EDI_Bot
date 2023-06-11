using Microsoft.Extensions.DependencyInjection;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL.Repositories.Async;
using YouTubeVideoDownloader.DAL.Repositories.Sync;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync;

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
            .AddScoped<IAudioRepository<Audio>, AudioRepository>()
            .AddScoped<IAudioRepositoryAsync<Audio>, AudioRepositoryAsync>()

            // Репозитории работы с Channel
            .AddScoped<IChannelRerository<Channel>, ChannelRepository>()
            .AddScoped<IChannelRerositoryAsync<Channel>, ChannelRepositoryAsync>()

            // Репозитории работы с Image
            .AddScoped<IImageRepository<Image>, ImageRepository>()
            .AddScoped<IImageRepositoryAsync<Image>, ImageRepositoryAsync>()

            // Репозитории работы с ServerInfo
            .AddScoped<IServerInfoRepository<ServerInfo>, ServerInfoRepository>()
            .AddScoped<IServerInfoRepositoryAsync<ServerInfo>, ServerInfoRepositoryAsync>()

            // Репозитории работы с Video
            .AddScoped<IVideoRepository<Video>, VideoRepository>()
            .AddScoped<IVideoRepositoryAsync<Video>, VideoRepositoryAsync>()

            // Репозитории работы с YouTubeInfo
            .AddScoped<IYouTubeInfoRepository<YouTubeInfo>, YouTubeInfoRepository>()
            .AddScoped<IYouTubeInfoRepositoryAsync<YouTubeInfo>, YouTubeInfoRepositoryAsync>()
            ;
    }
}
