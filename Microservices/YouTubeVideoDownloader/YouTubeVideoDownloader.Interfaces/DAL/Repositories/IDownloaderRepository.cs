using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories
{
    public interface IDownloaderRepository<T> : IEntityRepository<T> 
        where T : class, IEntity, new()
    {

    }
}
