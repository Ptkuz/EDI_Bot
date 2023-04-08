using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IAudio"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IAudio"/></typeparam>
    public interface IAudioRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IAudio, new()
    {

    }
}
