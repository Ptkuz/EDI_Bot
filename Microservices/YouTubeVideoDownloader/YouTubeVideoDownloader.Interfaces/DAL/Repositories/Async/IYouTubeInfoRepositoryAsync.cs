using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IYouTubeInfo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IYouTubeInfo"/></typeparam>
    public interface IYouTubeInfoRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IYouTubeInfo, new()
    {

    }
}
