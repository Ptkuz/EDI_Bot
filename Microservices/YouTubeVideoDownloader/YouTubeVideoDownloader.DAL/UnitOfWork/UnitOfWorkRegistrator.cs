using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.DAL.UnitOfWork
{
    public static class UnitOfWorkRegistrator
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services

            .AddScoped<IUnitOfWork<Audio, Channel, Image, ServerInfo, Video, YouTubeInfo>, UnitOfWork>()
            ;
    }
}
