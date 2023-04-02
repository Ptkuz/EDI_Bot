using Gurrex.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IServerInfo"/>
    /// </summary>
    public interface IServerInfoRepository<T> : IRepositoryEntities<T> where T : class, IServerInfo, new()
    {

    }
}
