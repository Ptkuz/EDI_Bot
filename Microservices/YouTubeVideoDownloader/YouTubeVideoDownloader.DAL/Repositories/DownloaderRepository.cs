using Gurrex.Common.DAL;
using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Interfaces.DAL;
using Gurrex.Common.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.Interfaces.DAL.Repositories;

namespace YouTubeVideoDownloader.DAL.Repositories
{
    public class DownloaderRepository<T> : EntityRepository<T> where T : Entity, new()
    {
        public DownloaderRepository(DownloaderContext dbContext, ILogger<EntityRepository<Entity>> logger) 
            : base(dbContext, logger)
        {

        }
    }
}
