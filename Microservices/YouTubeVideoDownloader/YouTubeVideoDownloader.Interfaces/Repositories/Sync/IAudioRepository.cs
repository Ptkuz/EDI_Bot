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
    /// Репозиторий работы с <see cref="IAudio"/>
    /// </summary>
    public interface IAudioRepository<T> : IRepositoryEntities<T> where T : class, IAudio, new()
    {

    }
}
