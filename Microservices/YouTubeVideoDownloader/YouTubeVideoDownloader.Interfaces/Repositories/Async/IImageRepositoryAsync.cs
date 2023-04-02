using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    public interface IImageRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IImage, new()
    {

    }
}
