using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IYouTubeInfo"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IYouTubeInfo"/></typeparam>
    public interface IYouTubeInfoRepository<T> : IRepositoryEntities<T> where T : class, IYouTubeInfo, new()
    {

    }
}
