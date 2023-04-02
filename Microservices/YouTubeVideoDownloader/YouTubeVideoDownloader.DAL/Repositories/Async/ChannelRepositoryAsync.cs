using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    public class ChannelRepositoryAsync : DbRepositoryAsync<Channel>, IChannelRerositoryAsync<Channel>
    {
        public ChannelRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
