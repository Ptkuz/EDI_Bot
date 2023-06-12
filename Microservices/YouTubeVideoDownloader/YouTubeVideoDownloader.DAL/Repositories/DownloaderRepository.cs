using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories;
using Gurrex.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    public class DownloaderRepository<T> : EntityRepository<T>, IDownloaderRepository<T>
        where T: Entity, new()
    {
        public DownloaderRepository(DownloaderContext dbContext, ILogger<DownloaderRepository<T>> logger) : base(dbContext, logger)
        {

        }
    }
}
