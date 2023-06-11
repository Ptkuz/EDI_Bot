using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.Interfaces.DAL.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IYouTubeInfo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IYouTubeInfo"/></typeparam>
    public interface IYouTubeInfoRepository<T> : IRepositoryEntities<T> where T : class, IYouTubeInfo, new()
    {

    }
}
