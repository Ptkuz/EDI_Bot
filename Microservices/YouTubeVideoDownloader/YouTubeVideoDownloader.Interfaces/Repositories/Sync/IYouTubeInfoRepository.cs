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
    /// Репозиторий работы с <see cref="IYouTubeInfo"/>
    /// </summary>
    public interface IYouTubeInfoRepository<T> : IRepositoryEntities<T> where T : class, IYouTubeInfo, new()
    {

    }
}
