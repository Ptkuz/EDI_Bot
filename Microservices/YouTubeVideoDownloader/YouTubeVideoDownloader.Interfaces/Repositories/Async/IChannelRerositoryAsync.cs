using Gurrex.Common.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gurrex.Common.Interfaces.Entities;
using YouTubeVideoDownloader.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    /// <summary>
    /// Ассинхронный репозиторий работы с <see cref="IChannel"/>
    /// </summary>
    public interface IChannelRerositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IChannel, new()
    {

    }
}
