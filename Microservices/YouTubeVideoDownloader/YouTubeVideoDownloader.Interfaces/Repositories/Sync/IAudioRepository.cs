using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IAudio"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IAudio"/></typeparam>
    public interface IAudioRepository<T> : IRepositoryEntities<T> where T : class, IAudio, new()
    {

    }
}
