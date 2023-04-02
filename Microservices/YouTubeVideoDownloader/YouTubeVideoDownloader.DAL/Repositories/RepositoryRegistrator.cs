﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.DAL.Repositories.Async;
using YouTubeVideoDownloader.DAL.Repositories.Sync;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryInDB(this IServiceCollection services) => services
            .AddScoped<IChannelRerository<Channel>, ChannelRepository>()
            .AddScoped<IChannelRerositoryAsync<Channel>, ChannelRepositoryAsync>()
            .AddScoped<IVideoRepository<Video>, VideoRepository>()
            .AddScoped<IVideoRepositoryAsync<Video>, VideoRepositoryAsync>()
            .AddScoped<IImageRepository<Image>, ImageRepository>()
            .AddScoped<IImageRepositoryAsync<Image>, ImageRepositoryAsync>()
            ;
    }
}
