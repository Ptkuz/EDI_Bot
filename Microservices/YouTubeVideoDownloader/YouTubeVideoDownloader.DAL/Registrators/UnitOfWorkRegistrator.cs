using Gurrex.Common.DAL;
using Gurrex.Common.Interfaces.DAL;
using Microsoft.Extensions.DependencyInjection;
using YouTubeVideoDownloader.DAL.DownloaderUnitOfWork;
using YouTubeVideoDownloader.Interfaces.DAL.UnitOfWork;

namespace YouTubeVideoDownloader.Registrators
{
    public static class UnitOfWorkRegistrator
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services
            .AddScoped<IDownloaderUnitOfWork, DownloaderUnitOfWork>();
    }
}
