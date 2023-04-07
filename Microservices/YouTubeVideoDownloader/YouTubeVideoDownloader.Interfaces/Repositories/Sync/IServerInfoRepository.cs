using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IServerInfo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IServerInfo"/></typeparam>
    public interface IServerInfoRepository<T> : IRepositoryEntities<T> where T : class, IServerInfo, new()
    {

    }
}
