using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IVideo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IVideo"/></typeparam>
    public interface IVideoRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IVideo, new()
    {

    }
}
