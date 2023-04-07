using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IChannel"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IChannel"/></typeparam>
    public interface IChannelRerositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IChannel, new()
    {

    }
}
