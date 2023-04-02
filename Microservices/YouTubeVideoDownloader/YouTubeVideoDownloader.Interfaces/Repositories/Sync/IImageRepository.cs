using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    public interface IImageRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}
