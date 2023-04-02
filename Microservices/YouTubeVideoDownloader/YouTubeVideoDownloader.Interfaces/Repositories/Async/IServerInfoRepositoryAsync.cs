using Gurrex.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    public interface IServerInfoRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IServerInfo, new()
    {

    }
}
