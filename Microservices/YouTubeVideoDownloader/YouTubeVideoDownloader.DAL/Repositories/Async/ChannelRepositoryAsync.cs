using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    public class ChannelRepositoryAsync : DbRepositoryAsync<Channel>, IVideoRepositoryAsync<Channel>
    {
        public ChannelRepositoryAsync(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
