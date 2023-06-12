using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.DAL;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    public class DownloaderRepository<T> : EntityRepository<T>, IDownloaderRepository<T> 
        where T : Entity, new()
    {

        public DownloaderRepository(DbContext dbContext, ILogger<EntityRepository<T>> logger) : base(dbContext, logger)
        {

        }
    }
}
