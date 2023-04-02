using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    public class ServerInfoRepository : DbRepository<ServerInfo>, IServerInfoRepository<ServerInfo>
    {
        public ServerInfoRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
