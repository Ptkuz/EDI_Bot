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
using YouTubeVideoDownloader.DAL.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.UnitOfWork;

namespace YouTubeVideoDownloader.DAL.DownloaderUnitOfWork
{
    public class DownloaderUnitOfWork : UnitOfWork, IDownloaderUnitOfWork
    {
        public DownloaderUnitOfWork(DownloaderContext dbContext, ILogger<DownloaderUnitOfWork> logger, ILogger<EntityRepository<Entity>> logger1) 
            : base(dbContext, logger, logger1)
        {

        }
    }
}
