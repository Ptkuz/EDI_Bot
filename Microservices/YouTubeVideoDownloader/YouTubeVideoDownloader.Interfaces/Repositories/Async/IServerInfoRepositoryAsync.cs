using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IServerInfo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IServerInfo"/></typeparam>
    public interface IServerInfoRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IServerInfo, new()
    {

    }
}
