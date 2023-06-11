using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IVideo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IVideo"/></typeparam>
    public interface IVideoRepository<T> : IRepositoryEntities<T> where T : class, IVideo, new()
    {

    }
}
