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
    public class YouTubeInfoRepositoryAsync : DbRepositoryAsync<YouTubeInfo>, IYouTubeInfoRepositoryAsync<YouTubeInfo>
    {
        public YouTubeInfoRepositoryAsync(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
