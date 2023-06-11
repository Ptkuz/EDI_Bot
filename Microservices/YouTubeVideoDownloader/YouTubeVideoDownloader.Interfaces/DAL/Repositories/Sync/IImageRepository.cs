using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IImage"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IImage"/></typeparam>
    public interface IImageRepository<T> : IRepositoryEntities<T> where T : class, IImage, new()
    {

    }
}
