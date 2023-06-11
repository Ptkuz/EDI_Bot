using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IChannel"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IChannel"/></typeparam>
    public interface IChannelRerositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IChannel, new()
    {

    }
}
