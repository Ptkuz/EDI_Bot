using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Sync;

namespace YouTubeVideoDownloader.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="Image"/>
    /// </summary>
    public class ImageRepository : DbRepository<Image>, IImageRepository<Image>
    {
        public ImageRepository(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
