using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    public class AudioRepository : DbRepository<Audio>, IAudioRepository<Audio>
    {
        public AudioRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
