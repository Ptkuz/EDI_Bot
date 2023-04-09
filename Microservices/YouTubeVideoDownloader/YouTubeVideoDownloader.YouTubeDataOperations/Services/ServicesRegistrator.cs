using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Interfaces;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddDownloadServices(this IServiceCollection services) => services
            .AddTransient<IDataInformations, DataInformations>()
            ;
    }
}
