using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Services.Async;
using YouTubeVideoDownloader.Interfaces.Services.Sync;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Async;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Sync;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddDownloadServices(this IServiceCollection services) => services
            .AddTransient<IDataInformation, DataInformations>()
            .AddTransient<IDataInformationAsync, DataInformationsAsync>()
            ;
    }
}
