using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Sync
{
    /// <summary>
    /// Репозиторий работы с <see cref="IChannel"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IChannel"/></typeparam>
    public interface IChannelRerository<T> : IRepositoryEntities<T> where T : class, IChannel, new()
    {

    }
}
